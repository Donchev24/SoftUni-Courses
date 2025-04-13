using Newtonsoft.Json;
using System.Diagnostics;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.Data.Utilities;
using TravelAgency.DataProcessor.ExportDtos;

namespace TravelAgency.DataProcessor
{
    public class Serializer
    {
        public static string ExportGuidesWithSpanishLanguageWithAllTheirTourPackages(TravelAgencyContext context)
        {
            var guidesToExport = context
                .Guides
                .Where(g => g.Language == Data.Models.Enums.Language.Spanish)
                .OrderByDescending(g => g.TourPackagesGuides.Count)
                .ThenBy(g => g.FullName)
                .Select(g => new ExportGuideDto
                {
                    FullName = g.FullName,
                    TourPackages = g.TourPackagesGuides
                          .Select(tpg => tpg.TourPackage)
                          .OrderByDescending(tpg => tpg.Price)
                          .ThenBy (tpg => tpg.PackageName)
                          .Select(tp => new ExportGuideTourPackageDto
                          {
                              Name = tp.PackageName,
                              Description = tp.Description,
                              Price = tp.Price.ToString()
                          })
                          .ToArray()
                          
                })
                .ToArray();

            string output = XmlHelper
               .Serialize(guidesToExport, "Guides");

            return output;
        }

        public static string ExportCustomersThatHaveBookedHorseRidingTourPackage(TravelAgencyContext context)
        {
            var customersToExport = context
                .Customers
                .Where(c => c.Bookings.Any(b => b.TourPackage.PackageName == "Horse Riding Tour"))
                .Select(c => new
                {
                    c.FullName,
                    c.PhoneNumber,
                    Bookings = c.Bookings
                       .Where(t => t.TourPackage.PackageName == "Horse Riding Tour")
                       .OrderBy(c => c.BookingDate)
                       .Select(b => new
                       {
                           TourPackageName = b.TourPackage.PackageName,
                           Date = b.BookingDate.ToString("yyyy-MM-dd")
                       })
                       .ToArray()
                })
                .ToArray()
                .OrderByDescending(c => c.Bookings.Length)
                .ThenBy(c => c.FullName)
                .ToArray();





            string result = JsonConvert
              .SerializeObject(customersToExport, Formatting.Indented);

            return result;
                
                
        }
    }
}
