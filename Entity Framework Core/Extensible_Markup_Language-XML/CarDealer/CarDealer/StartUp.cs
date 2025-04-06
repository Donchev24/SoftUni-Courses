using CarDealer.Data;
using CarDealer.Models;
using System.ComponentModel.DataAnnotations;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext dbContext = new CarDealerContext();
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {

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