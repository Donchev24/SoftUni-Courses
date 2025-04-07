using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;
using System.ComponentModel.DataAnnotations;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext dbContext = new CarDealerContext();

            string xmlFilePath = "../../../Datasets/cars.xml";
            string inputXml = File.ReadAllText(xmlFilePath);

            string result = ImportCars(dbContext, inputXml);
            Console.WriteLine(result);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            string result = string.Empty;

            ImportSupplierDto[]? supplierDtos = XmlHelper
                .Deserialize<ImportSupplierDto[]>(inputXml, "Suppliers");

            if (supplierDtos != null)
            {
                ICollection<Supplier> validSuppliers = new List<Supplier>();

                foreach (ImportSupplierDto supplierDto in supplierDtos)
                {
                    if (!IsValid(supplierDto))
                    {
                        continue;
                    }

                    bool isImporterValid = bool.TryParse(supplierDto.IsImporter, out bool isImporter);
                    if (!isImporterValid)
                    {
                        continue;
                    }

                    Supplier supplier = new Supplier()
                    {
                        Name = supplierDto.Name,
                        IsImporter = isImporter
                    };

                    validSuppliers.Add(supplier);

                }

                context.AddRange(validSuppliers);
                context.SaveChanges();
                result = $"Successfully imported {validSuppliers.Count}";
            }
            return result ;
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            string result = string.Empty;

            ICollection<Part> parts = new List<Part>();

            ImportPartDto[]? partDtos = XmlHelper
                .Deserialize<ImportPartDto[]>(inputXml, "Parts");

            if (partDtos != null)
            {
                var validSupplierIds = context
                        .Suppliers
                        .Select(s => s.Id)
                        .ToArray();

                foreach (ImportPartDto partDto in partDtos)
                {
                    if (!IsValid(partDto))
                    {
                        continue;
                    }

                    bool isPriceValid = decimal.TryParse(partDto.Price, out decimal price);
                    bool isQuantityValid = int.TryParse(partDto.Quantity, out int quantity);
                    bool isSupplierIdValid = int.TryParse(partDto.SupplierId, out int supplierId);

                    if ((!isPriceValid) || (!isQuantityValid) || (!isSupplierIdValid))
                    {
                        continue;
                    }

                    if (!validSupplierIds.Contains(supplierId))
                    {
                        continue;
                    }

                    Part part = new Part()
                    {
                        Name = partDto.Name,
                        Price = price,
                        Quantity = quantity,
                        SupplierId = supplierId,
                    };

                    parts.Add(part);
                }
                context.AddRange(parts);
                context.SaveChanges();

                result = $"Successfully imported {parts.Count}";
            }
            return result;
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            string result = string.Empty;

            ICollection<Car> cars = new List<Car>();

            ImportCarDto[]? carDtos = XmlHelper
                .Deserialize<ImportCarDto[]>(inputXml, "Cars");

            if (carDtos != null)
            {
                foreach (ImportCarDto carDto in carDtos)
                {
                    if (!IsValid(carDto))
                    {
                        continue;
                    }

                    bool isDistanceValid = long.TryParse(carDto.TraveledDistance, out long traveledDistance);
                    if (!isDistanceValid)
                    {
                        continue;
                    }

                    List<int> partIds = new List<int>();
                    foreach (ImportCarPartsDto id in carDto.Parts)
                    {
                        bool isPartIdValid = int.TryParse(id.Id, out int parsedId);

                        if (isPartIdValid)
                        {
                            partIds.Add(parsedId);
                        }
                    }

                    Car car = new Car()
                    {
                        Make = carDto.Make,
                        Model = carDto.Model,
                        TraveledDistance = traveledDistance,
                        PartsCars = new List<PartCar>()
                    };

                    Part[] parts = context
                        .Parts
                        .Where(p => partIds.Contains(p.Id))
                        .Distinct()
                        .ToArray();

                    foreach (Part part in parts)
                    {
                        car.PartsCars.Add(new PartCar
                        {
                            Car = car,
                            Part = part
                        });
                    }

                    cars.Add(car);
                }

                context.AddRange(cars);
                context.SaveChanges();
                result = $"Successfully imported {cars.Count}";
            }
            
            return result;
        }

        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator
                .TryValidateObject(dto, validateContext, validationResult, true);

            return isValid;
        }


    }
}