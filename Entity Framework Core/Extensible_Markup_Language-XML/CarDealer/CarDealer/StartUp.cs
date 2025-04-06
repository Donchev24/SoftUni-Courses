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

            string xmlFilePath = "../../../Datasets/parts.xml";
            string inputXml = File.ReadAllText(xmlFilePath);

            string result = ImportParts(dbContext, inputXml);
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