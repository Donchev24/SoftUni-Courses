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

            string inputJson = File.ReadAllText("../../../Datasets/customers.json");

            string result = ImportCustomers(dbContext, inputJson);

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

                    if (carDto.PartsId == null)
                    {
                        continue;
                    }

                    ICollection<int> partIds = new List<int>();

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
                        PartsCars = new List<PartCar>()
                    };

                    var parts = context
                        .Parts
                        .Where(p => partIds.Contains(p.Id))
                        .ToArray();

                    foreach (Part part in parts)
                    {
                        car.PartsCars.Add(new PartCar { Car = car, Part = part });
                    }

                    cars.Add(car);
                }
                context.AddRange(cars);
                context.SaveChanges();

                result = $"Successfully imported {cars.Count}.";
            }
            return result;
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            string result = string.Empty;

            ICollection<Customer> customers = new List<Customer>();

            ImportCustomerDto[]? customerDtos = JsonConvert
                .DeserializeObject<ImportCustomerDto[]>(inputJson);

            if (customerDtos != null)
            {
                foreach (ImportCustomerDto customerDto in customerDtos)
                {
                    if (!IsValid(customerDto))
                    {
                        continue;
                    }

                    bool isBirthDateValid = DateTime.TryParse(customerDto.BirthDate, out  DateTime BirthDate);
                    if (!isBirthDateValid)
                    {
                        continue;
                    }

                    bool isYoungDriver = false;
                    if (customerDto.IsYoungDriver == "true")
                    {
                        isYoungDriver = true;
                    }

                    Customer customer = new Customer
                    {
                        Name = customerDto.Name,
                        BirthDate = BirthDate,
                        IsYoungDriver = isYoungDriver
                    };

                    customers.Add(customer);
                }

                context.AddRange(customers);
                context.SaveChanges();
                result = $"Successfully imported {customers.Count}.";
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