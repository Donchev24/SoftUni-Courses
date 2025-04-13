using Cadastre.Data;
using Cadastre.Data.Enumerations;
using Cadastre.Data.Utilities;
using Cadastre.DataProcessor.ExportDtos;
using Newtonsoft.Json;
using System.Net;

namespace Cadastre.DataProcessor
{
    public class Serializer
    {
        public static string ExportPropertiesWithOwners(CadastreContext dbContext)
        {
            DateTime.TryParse("01/01/2000", out DateTime parsedDate);

           var propertiesToExport = dbContext
                .Properties
                .Where(p => p.DateOfAcquisition >= parsedDate)
                .OrderByDescending(p => p.DateOfAcquisition)
                .ThenBy(p => p.PropertyIdentifier)
                .Select(p => new
                {
                    PropertyIdentifier = p.PropertyIdentifier,
                    Area = p.Area,
                    Address = p.Address,
                    DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy"),
                    Owners = p.PropertiesCitizens
                          .Select(p => p.Citizen)
                          .Select(c => new
                          {
                              LastName = c.LastName,
                              MaritalStatus = c.MaritalStatus.ToString(),
                          })
                          .OrderBy(c => c.LastName)
                          .ToArray()
                })
                .ToArray();

            string output = JsonConvert
                .SerializeObject(propertiesToExport, Formatting.Indented);
            return output;
        }

        public static string ExportFilteredPropertiesWithDistrict(CadastreContext dbContext)
        {
            var propertiesLargerThan = dbContext
                .Properties
                .Where(p => p.Area >= 100)
                .OrderByDescending(p => p.Area)
                .ThenBy(p => p.DateOfAcquisition)
                .Select(p => new ExportPropertyLargerThanDto
                {
                    PropertyIdentifier = p.PropertyIdentifier,
                    Area = p.Area.ToString(),
                    DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy"),
                    PostalCode = p.District.PostalCode
                })
                .ToArray();

            string output = XmlHelper
                .Serialize(propertiesLargerThan, "Properties");

            return output;
        }
    }
}
