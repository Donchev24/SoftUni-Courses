using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
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
            StringBuilder output = new StringBuilder();

            ICollection<Booking> validBookings = new List<Booking>();

            ImportBookingDto[]? bookingDtos = JsonConvert
                .DeserializeObject<ImportBookingDto[]>(jsonString);

            if (bookingDtos != null && bookingDtos.Length > 0)
            {
                foreach (ImportBookingDto bookingDto in bookingDtos)
                {
                    if (!IsValid(bookingDto))
                    {
                        output.AppendLine(ErrorMessage);
                    }

                    bool isDateValid = DateTime
                        .TryParseExact(bookingDto.BookingDate, "yyyy-MM-dd",
                                           CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate);

                    if (!isDateValid)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    Customer customer;
                    TourPackage tourPackage;

                    bool isCustomerExist = context
                        .Customers
                        .Any(c => c.FullName == bookingDto.CustomerName);

                    bool isTourPackageExist = context
                        .TourPackages
                        .Any(tp => tp.PackageName == bookingDto.TourPackageName);

                    if ((!isCustomerExist) || (!isTourPackageExist))
                    {
                        continue;
                    }

                    
                    customer = context
                            .Customers
                            .First(c => c.FullName == bookingDto.CustomerName);

                    tourPackage = context
                        .TourPackages
                        .First(tp => tp.PackageName == bookingDto.TourPackageName);
                    
                    Booking boooking = new Booking()
                    {
                        BookingDate = parsedDate,
                        Customer = customer,
                        TourPackage = tourPackage
                    };

                    validBookings.Add(boooking);
                    string msg = String.Format(SuccessfullyImportedBooking, bookingDto.TourPackageName, parsedDate.ToString("yyyy-MM-dd"));
                    output.AppendLine(msg);
                }

                context.Bookings.AddRange(validBookings);
                context.SaveChanges();
            }

            return output.ToString().TrimEnd();
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
