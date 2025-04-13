using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.Data.Utilities;
using TravelAgency.DataProcessor.ImportDtos;

namespace TravelAgency.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedCustomer = "Successfully imported customer - {0}";
        private const string SuccessfullyImportedBooking = "Successfully imported booking. TourPackage: {0}, Date: {1}";

        public static string ImportCustomers(TravelAgencyContext context, string xmlString)
        {
            StringBuilder output = new StringBuilder();

            ICollection<Customer> validCustomers = new List<Customer>();

            ImportCustomerDto[]? customerDtos = XmlHelper
                .Deserialize<ImportCustomerDto[]>(xmlString, "Customers");

            if (customerDtos != null && customerDtos.Length > 0)
            {
                foreach (ImportCustomerDto customerDto in customerDtos)
                {
                    if (!IsValid(customerDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (validCustomers.Any(c => c.FullName == customerDto.FullName
                                            || c.PhoneNumber == customerDto.PhoneNumber
                                            || c.Email == customerDto.Email))
                    {
                        output.AppendLine(DuplicationDataMessage);
                        continue;
                    }

                    Customer customer = new Customer()
                    {
                        FullName = customerDto.FullName,
                        PhoneNumber = customerDto.PhoneNumber,
                        Email = customerDto.Email
                    };

                    validCustomers.Add(customer);

                    string msg = String.Format(SuccessfullyImportedCustomer, customerDto.FullName);

                    output.AppendLine(msg);
                }

                context.Customers.AddRange(validCustomers);
                context.SaveChanges();
            }

            return output.ToString().TrimEnd();
        }

        public static string ImportBookings(TravelAgencyContext context, string jsonString)
        {
            string result = string.Empty;
            return result;
        }

        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);

            foreach (var validationResult in validationResults)
            {
                string currValidationMessage = validationResult.ErrorMessage;
            }

            return isValid;
        }
    }
}
