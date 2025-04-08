using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext dbContext = new CarDealerContext();

            //string xmlFilePath = "../../../Datasets/sales.xml";
            //string inputXml = File.ReadAllText(xmlFilePath);

            //string result = ImportSales(dbContext, inputXml);

            string result = GetLocalSuppliers(dbContext);
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

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            string result = string.Empty;

            ICollection<Customer> customers = new List<Customer>();

            ImportCustomerDto[]? customerDtos = XmlHelper
                .Deserialize<ImportCustomerDto[]>(inputXml, "Customers");

            if (customerDtos != null)
            {
                foreach (ImportCustomerDto customerDto in customerDtos)
                {
                    if (!IsValid(customerDto))
                    {
                        continue;
                    }

                    bool isBirthDateValid = DateTime.TryParse(customerDto.BirthDate,
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateTime parsedBirthDate);

                    if (!isBirthDateValid)
                    {
                        continue;
                    }

                    bool isYoungDriverValid = bool.TryParse(customerDto.IsYoungDriver, out bool isYoungDriver);


                    Customer customer = new Customer()
                    {
                        Name = customerDto.Name,
                        BirthDate = parsedBirthDate,
                        IsYoungDriver = isYoungDriver
                    };

                    customers.Add(customer);
                }

                context.Customers.AddRange(customers);
                context.SaveChanges();
                result = $"Successfully imported {customers.Count}";
            }

            return result;
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            string result = string.Empty;

            int[] validCarIds = context
                .Cars
                .Select(c => c.Id)
                .ToArray();

            ICollection<Sale> sales = new List<Sale>();

            ImportSaleDto[]? saleDtos = XmlHelper
                .Deserialize<ImportSaleDto[]>(inputXml, "Sales");

            if (saleDtos != null)
            {
                foreach (ImportSaleDto saleDto in saleDtos)
                {
                    if (!IsValid(saleDto))
                    {
                        continue;
                    }

                    bool isCarIdValid = int.TryParse(saleDto.CarId, out int parsedCarId);
                    bool isCustomerIdValid = int.TryParse(saleDto.CustomerId, out int parsedCustomerId);
                    bool isDiscountValid = int.TryParse(saleDto.Discount, out int parsedDiscount);

                    if ((!isCarIdValid) || (!isCustomerIdValid) || (!isDiscountValid))
                    {
                        continue;
                    }

                    if (!validCarIds.Contains(parsedCarId))
                    {
                        continue;
                    }

                    Sale sale = new Sale()
                    {
                        CarId = parsedCarId,
                        CustomerId = parsedCustomerId,
                        Discount = parsedDiscount
                    };

                    sales.Add(sale);
                }

                context.Sales.AddRange(sales);
                context.SaveChanges();
                result = $"Successfully imported {sales.Count}";
            }

            return result;
        }


        // EXPORT !!!


        public static string GetCarsWithDistance(CarDealerContext context)
        {
            ExportCarsWithDistanceDto[] carsWithDistance = context
                .Cars
                .Where(c => c.TraveledDistance > 2_000_000)
                .Select(c => new ExportCarsWithDistanceDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance.ToString()
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

            string result = XmlHelper
                .Serialize(carsWithDistance, "cars");

            return result;
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            ExportCarsFromMakeBmwDto[] carsFromMakeBmwDtos = context
                .Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .Select(c => new ExportCarsFromMakeBmwDto
                {
                    Id = c.Id.ToString(),
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance.ToString(),
                })
                .ToArray();

            string result = XmlHelper
                .Serialize(carsFromMakeBmwDtos, "cars");

            return result;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            ExportLocalSuppliersDto[] localSuppliersDtos = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new ExportLocalSuppliersDto
                {
                    Id = s.Id.ToString(),
                    Name = s.Name,
                    PartsCount = s.Parts.Count.ToString(),
                })
                .ToArray();

            string result = XmlHelper
                .Serialize(localSuppliersDtos, "suppliers");

            return result;
        }
                


        // VALIDATION !!!


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