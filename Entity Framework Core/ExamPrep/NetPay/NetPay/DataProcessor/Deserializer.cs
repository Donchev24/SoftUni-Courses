using NetPay.Data;
using NetPay.Data.Models;
using NetPay.Data.Models.Enums;
using NetPay.Data.Utilities;
using NetPay.DataProcessor.ImportDtos;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
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
            StringBuilder output = new StringBuilder();

            ICollection<Household> households = new List<Household>();

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

        public static string ImportExpenses(NetPayContext context, string jsonString)
        {
            StringBuilder output = new StringBuilder();

            ICollection<Expense> validExpenses = new List<Expense>();

            ImportExpenseDto[]? expenseDtos = JsonConvert
                .DeserializeObject<ImportExpenseDto[]>(jsonString);

            if (expenseDtos != null && expenseDtos.Length > 0 )
            {
                foreach ( ImportExpenseDto expenseDto in expenseDtos )
                {
                    if (!IsValid(expenseDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isExistHouseholdId = context
                        .Households
                        .Any(h => h.Id == expenseDto.HouseholdId);

                    bool isExistServiceId = context
                        .Services
                        .Any(s => s.Id == expenseDto.ServiceId);

                    if ((!isExistHouseholdId) || (!isExistServiceId))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isDueDateValid = DateTime
                        .TryParseExact(expenseDto.DueDate, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                                       DateTimeStyles.None, out DateTime parsedDueDate);

                    bool isPaymentStatusValid = Enum
                        .TryParse<PaymentStatus>(expenseDto.PaymentStatus, out PaymentStatus parsedPaymentStatus);

                    if ((!isDueDateValid) || (!isPaymentStatusValid))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    Expense expense = new Expense()
                    {
                        ExpenseName = expenseDto.ExpenseName,
                        Amount = expenseDto.Amount,
                        DueDate = parsedDueDate,
                        PaymentStatus = parsedPaymentStatus,
                        HouseholdId = expenseDto.HouseholdId,
                        ServiceId = expenseDto.ServiceId
                    };

                    validExpenses.Add(expense);

                    string msg = String.Format(SuccessfullyImportedExpense, expenseDto.ExpenseName, expenseDto.Amount.ToString("f2"));
                    output.AppendLine(msg);
                }

                context.Expenses.AddRange(validExpenses);
                context.SaveChanges();
            }
            return output.ToString().TrimEnd();
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
