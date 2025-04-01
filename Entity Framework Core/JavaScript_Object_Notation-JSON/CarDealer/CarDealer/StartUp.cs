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

            string inputJson = File.ReadAllText("../../../Datasets/suppliers.json");

            string result = ImportSuppliers(dbContext, inputJson);

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