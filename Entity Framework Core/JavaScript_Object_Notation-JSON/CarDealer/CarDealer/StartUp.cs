using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext dbContext = new CarDealerContext();

            string inputJson = File.ReadAllText("../../../Datasets/cars.json");

            string result = ImportCars(dbContext, inputJson);

            Console.WriteLine(result);
        }

        public static string ImportSuppliers(CarDealerContext dbContext, string inputJson)
        {
            string result = string.Empty;
            ICollection<Supplier> suppliers = new List<Supplier>();

            ImportSupplierDto[]? supplierDtos = JsonConvert
                .DeserializeObject<ImportSupplierDto[]>(inputJson);

            if (supplierDtos != null)
            {
                foreach (ImportSupplierDto supplierDto in supplierDtos)
                {
                    if (!IsValid(supplierDto))
                    {
                        continue;
                    }

                    bool isImport = false;

                    if (supplierDto.isImporter == "true")
                    {
                        isImport = true;
                    }

                    Supplier supplier = new Supplier()
                    {
                        Name = supplierDto.Name,
                        IsImporter = isImport
                    };

                    suppliers.Add(supplier);
                }

                dbContext.AddRange(suppliers);
                dbContext.SaveChanges();

                result = $"Successfully imported {suppliers.Count}.";
            }
            return result;
        }

        public static string ImportParts(CarDealerContext dbContext, string inputJson)
        {
            string result = string.Empty;

            ICollection<Part> parts = new List<Part>();

            ImportPartDto[]? partDtos = JsonConvert
                .DeserializeObject<ImportPartDto[]>(inputJson);

            if (partDtos != null)
            {
                foreach (ImportPartDto partDto in partDtos)
                {
                    if (!IsValid(partDto))
                    {
                        continue;
                    }

                    bool isPriceValid = decimal.TryParse(partDto.Price, out decimal parsedPrice);
                    bool isQuantityValid = int.TryParse(partDto.Quantity, out int parsedQuantity);
                    bool isSupplierIdValid = int.TryParse(partDto.SupplierId, out int parsedSupplierId);

                    if ((!isPriceValid) || (!isQuantityValid) || (!isSupplierIdValid))
                    {
                        continue;
                    }

                    int[] validSupplierIds = dbContext
                        .Suppliers
                        .Select(p => p.Id)
                        .ToArray();

                    if (!validSupplierIds.Contains(parsedSupplierId))
                    {
                        continue;
                    }

                    Part part = new Part()
                    {
                        Name = partDto.Name,
                        Price = parsedPrice,
                        Quantity = parsedQuantity,
                        SupplierId = parsedSupplierId
                    };

                    parts.Add(part);
                }

                dbContext.AddRange(parts);
                dbContext.SaveChanges();
                result = $"Successfully imported {parts.Count}.";
            }

            return result; 
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            string result = string.Empty;

            ICollection<Car> cars = new List<Car>();

            ImportCarDto[]? carDtos = JsonConvert
                .DeserializeObject<ImportCarDto[]>(inputJson);

            if (carDtos != null)
            {
                foreach (ImportCarDto carDto in carDtos)
                {
                    if (!IsValid(carDto))
                    {
                        continue;
                    }

                    bool isTravelledDistanceValid = int.TryParse(carDto.TraveledDistance, out int parcedDistance);

                    if (!isTravelledDistanceValid)
                    {
                        continue;
                    }

                    ICollection<int> partIds = new List<int>();

                    if (carDto.PartsId == null)
                    {
                        continue;
                    }

                    foreach (string id in carDto.PartsId)
                    {
                        bool isIdValid = int.TryParse(id, out int parsedId);
                        if (isIdValid)
                        {
                            partIds.Add(parsedId);
                        }
                    }

                    Car car = new Car()
                    {
                        Make = carDto.Make,
                        Model = carDto.Model,
                        TraveledDistance = parcedDistance,
                        PartIds = partIds
                    };

                    cars.Add(car);
                }
                //ADD TO CONTEXT
                //SAVE CHANGES

                result = $"Successfully imported {cars.Count}.";
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