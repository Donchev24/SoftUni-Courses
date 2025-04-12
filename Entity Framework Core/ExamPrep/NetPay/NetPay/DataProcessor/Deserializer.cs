using NetPay.Data;
using NetPay.Data.Models;
using NetPay.Data.Utilities;
using NetPay.DataProcessor.ImportDtos;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NetPay.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedHousehold = "Successfully imported household. Contact person: {0}";
        private const string SuccessfullyImportedExpense = "Successfully imported expense. {0}, Amount: {1}";

        public static string ImportHouseholds(NetPayContext context, string xmlString)
        {
            ICollection<Household> households = new List<Household>();

            StringBuilder output = new StringBuilder();

            ImportHouseholdDto[]? householdDtos = XmlHelper
                .Deserialize<ImportHouseholdDto[]>(xmlString, "Households");


            if (householdDtos != null && householdDtos.Length > 0)
            {
                foreach (ImportHouseholdDto householdDto in householdDtos)
                {
                    if (!IsValid(householdDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isDuplicate = households
                        .Any(h => h.ContactPerson == householdDto.ContactPerson 
                               || h.Email == householdDto.Email
                               || h.PhoneNumber == householdDto.PhoneNumber
                        );

                    //bool isExistInDb = context
                    //    .Households
                    //    .Any(h => h.ContactPerson == householdDto.ContactPerson
                    //           || h.Email == householdDto.Email
                    //           || h.PhoneNumber == householdDto.PhoneNumber);

                    if (isDuplicate)
                    {
                        output.AppendLine(DuplicationDataMessage);
                        continue;
                    }

                    Household household = new Household()
                    {
                        ContactPerson = householdDto.ContactPerson,
                        Email = householdDto.Email,
                        PhoneNumber = householdDto.PhoneNumber
                    };

                    households.Add(household);

                    string toAppend = String.Format(SuccessfullyImportedHousehold, householdDto.ContactPerson);
                    output.AppendLine(toAppend);
                }

                context.Households.AddRange(households);
                context.SaveChanges();
            }

            return output.ToString().TrimEnd();
        }

        public static string ImportExpenses(NetPayContext context, string jsonString) //////////
        {
            throw new NotImplementedException();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

            foreach(var result in validationResults)
            {
                string currvValidationMessage = result.ErrorMessage;
            }

            return isValid;
        }
    }
}
