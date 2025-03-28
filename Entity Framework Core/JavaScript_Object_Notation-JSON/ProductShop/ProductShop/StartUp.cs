using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.ComponentModel.DataAnnotations;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext dbContext = new ProductShopContext();

            string jsonString = File.ReadAllText("../../../Datasets/users.json");
            string result = ImportUsers(dbContext, jsonString);

            Console.WriteLine(result);
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            string result = string.Empty;

            ImportUserDto[]? userDtos = JsonConvert
                .DeserializeObject<ImportUserDto[]>(inputJson);

            if (userDtos != null)
            {
                ICollection<User> usersToAdd= new List<User>();

                foreach (ImportUserDto userDto in userDtos)
                {
                    if (!IsValid(userDto))
                    {
                        continue;
                    }

                    int? userAge = null;
                    if (userDto.Age != null)
                    {
                        bool isAgeValid = int.TryParse(userDto.Age, out int parsedAge);
                        if (!isAgeValid)
                        {
                            continue;
                        }

                        userAge = parsedAge;
                    }

                    User user = new User()
                    {
                        FirstName = userDto.FirstName,
                        LastName = userDto.LastName,
                        Age = userAge
                    };

                    usersToAdd.Add(user);
                }

                context.AddRange(usersToAdd);
                context.SaveChanges();

                result = $"Successfully imported {usersToAdd.Count}";
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