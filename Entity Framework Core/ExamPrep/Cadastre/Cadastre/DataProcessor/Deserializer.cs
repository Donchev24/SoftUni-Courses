namespace Cadastre.DataProcessor
{
    using Cadastre.Data;
    using Cadastre.Data.Enumerations;
    using Cadastre.Data.Models;
    using Cadastre.Data.Utilities;
    using Cadastre.DataProcessor.ImportDtos;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid Data!";
        private const string SuccessfullyImportedDistrict =
            "Successfully imported district - {0} with {1} properties.";
        private const string SuccessfullyImportedCitizen =
            "Succefully imported citizen - {0} {1} with {2} properties.";

        public static string ImportDistricts(CadastreContext dbContext, string xmlDocument)
        {
            StringBuilder output = new StringBuilder();

            ICollection<District> validDistricts = new List<District>();

            ImportDistrictDto[]? districtDtos = XmlHelper
                .Deserialize<ImportDistrictDto[]>(xmlDocument, "Districts");

            if (districtDtos != null && districtDtos.Length > 0 )
            {
                foreach (ImportDistrictDto districtDto in districtDtos)
                {
                    if (!IsValid(districtDto))
                    {
                        output.Append(ErrorMessage);
                        continue;
                    }

                    if (validDistricts.Any(vd => vd.Name == districtDto.Name))
                    {
                        output.Append(ErrorMessage);
                        continue;
                    }

                    bool isRegionValid = Enum
                        .TryParse<Region>(districtDto.Region, out Region parsedRegion);

                    if (!isRegionValid)
                    {
                        output.Append(ErrorMessage);
                        continue;
                    }

                    District district = new District()
                    {
                        Name = districtDto.Name,
                        PostalCode = districtDto.PostalCode,
                        Region = parsedRegion
                    };

                    ICollection<Property> validProperties = new List<Property>();

                    foreach (ImportDistrictPropertyDto propertyDto in districtDto.Properties)
                    {
                        if (!IsValid(propertyDto))
                        {
                            output.Append(ErrorMessage);
                            continue;
                        }

                        bool isAreaValid = int
                            .TryParse(propertyDto.Area, out int parsedArea);

                        bool isDateOfAcquisitionValid = DateTime
                            .TryParseExact(propertyDto.DateOfAcquisition, "dd/MM/yyyy",
                                           CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate);

                        if ((!isAreaValid) || (!isDateOfAcquisitionValid))
                        {
                            output.AppendLine(ErrorMessage);
                            continue;
                        }

                        if (district.Properties.Any(d => d.PropertyIdentifier == propertyDto.PropertyIdentifier
                                                       || d.Address == propertyDto.Address))
                        {
                            output.AppendLine(ErrorMessage);
                            continue;
                        }

                        Property property = new Property()
                        {
                            PropertyIdentifier = propertyDto.PropertyIdentifier,
                            Area = parsedArea,
                            Details = propertyDto.Details,
                            Address = propertyDto.Address,
                            DateOfAcquisition = parsedDate,
                            District = district
                        };

                        validProperties.Add(property);
                    }

                    district.Properties = validProperties;

                    validDistricts.Add(district);
                    string msgToAppend = String.Format(SuccessfullyImportedDistrict, district.Name, district.Properties.Count);
                    output.AppendLine(msgToAppend);
                }

                dbContext.Districts.AddRange(validDistricts);
                dbContext.SaveChanges();
            }

            return output.ToString().TrimEnd();
        }

        public static string ImportCitizens(CadastreContext dbContext, string jsonDocument)
        {
            StringBuilder output = new StringBuilder();

            ICollection<Citizen> validCitizens = new List<Citizen>();

            ImportCitizenDto[]? citizenDtos = JsonConvert
                .DeserializeObject<ImportCitizenDto[]>(jsonDocument);

            if (citizenDtos != null && citizenDtos.Length > 0)
            {
                foreach (ImportCitizenDto citizenDto in citizenDtos)
                {
                    if (!IsValid(citizenDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isMartialStatusValid = Enum
                        .TryParse<MaritalStatus>(citizenDto.MaritalStatus, out MaritalStatus parsedMartialStatus);

                    bool isBirthDateValid = DateTime
                        .TryParseExact(citizenDto.BirthDate, "dd-MM-yyyy", CultureInfo.InvariantCulture,
                                       DateTimeStyles.None, out DateTime parsedBirthDate);

                    if ((!isMartialStatusValid) || (!isBirthDateValid))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    Citizen citizen = new Citizen()
                    {
                        FirstName = citizenDto.FirstName,
                        LastName = citizenDto.LastName,
                        MaritalStatus = parsedMartialStatus,
                        BirthDate = parsedBirthDate
                    };

                    ICollection<PropertyCitizen> citizenProperties = new List<PropertyCitizen>();

                    foreach (var propertyId in citizenDto.Properties)
                    {
                        Property? property = dbContext
                            .Properties
                            .FirstOrDefault(p => p.Id == propertyId);

                        if (property != null)
                        {
                            PropertyCitizen propertyCitizen = new PropertyCitizen()
                            {
                                CitizenId = citizen.Id,
                                PropertyId = propertyId
                            };

                            citizenProperties.Add(propertyCitizen);
                        }
                    }

                    citizen.PropertiesCitizens = citizenProperties;

                    validCitizens.Add(citizen);
                    string msgToAppend = String.Format(SuccessfullyImportedCitizen, 
                        citizen.FirstName, citizen.LastName, citizen.PropertiesCitizens.Count);
                    output.AppendLine(msgToAppend);
                }

                dbContext.Citizens.AddRange(validCitizens);
                dbContext.SaveChanges();
            }
            return output.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
