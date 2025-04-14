using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using ArtCollective.Data;
using ArtCollective.Data.Models;
using ArtCollective.Data.Models.Enums;
using ArtCollective.Data.Utilities;
using ArtCollective.DataProcessor.ImportDTOs;
using Newtonsoft.Json;

namespace ArtCollective.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format.";
        private const string DuplicatedData = "Data is duplicated.";
        private const string SuccessfullyImportedFeedbackEntity = "Successfully imported feedback (Given on: {0}, Status: {1})";
        private const string SuccessfullyImportedArtworkEntity = "Successfully imported artwork (Artist: {0}, Created on: {1})";

        public static string ImportFeedbacks(ArtCollectiveDbContext dbContext, string xmlString)
        {
            StringBuilder output = new StringBuilder();

            ICollection<Feedback> validFeedbacks = new List<Feedback>();

            ImportFeedbackDto[]? feedbackDtos = XmlHelper
                .Deserialize<ImportFeedbackDto[]>(xmlString, "Feedbacks");

            if (feedbackDtos != null && feedbackDtos.Length > 0 )
            {
                foreach(ImportFeedbackDto feedbackDto in feedbackDtos)
                {
                    if (!IsValid(feedbackDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isGiveOnValid = DateTime
                        .TryParseExact(feedbackDto.GivenOn, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                         DateTimeStyles.None, out DateTime parsedGiveOnDate);

                    bool isStatusValid = Enum
                        .TryParse<Status>(feedbackDto.Status, out Status parsedStatus);

                    if ((!isStatusValid) || (!isGiveOnValid))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isGroupIdValid = int
                        .TryParse(feedbackDto.GroupId, out int parsedGroupId);
                    bool isArtistIdValid = int
                        .TryParse(feedbackDto.ArtistId, out int parsedArtistId);

                    if ((!isArtistIdValid) || (!isGroupIdValid)) 
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isGroupIdExist = dbContext
                        .Groups
                        .Any(g => g.Id == parsedGroupId);

                    bool isArtistIdExist = dbContext
                        .Artists
                        .Any(a => a.Id == parsedArtistId);

                    if ((!isArtistIdExist) || (!isGroupIdExist))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isFeedBackExistInGroup = dbContext
                        .Groups
                        .Where(g => g.Id == parsedGroupId)
                        .Any(g => g.Feedbacks.Any(f => f.Content == feedbackDto.Content
                                                    && f.GivenOn == parsedGiveOnDate
                                                    && f.Status == parsedStatus
                                                    && f.ArtistId == parsedArtistId));

                    bool isFeedbackExistInValidGroup = validFeedbacks
                        .Any(f => f.Content == feedbackDto.Content
                                                    && f.GivenOn == parsedGiveOnDate
                                                    && f.Status == parsedStatus
                                                    && f.ArtistId == parsedArtistId);

                    if (isFeedBackExistInGroup || isFeedbackExistInValidGroup)
                    {
                        output.AppendLine(DuplicatedData);
                        continue;
                    }

                    Feedback feedback = new Feedback()
                    {
                        Content = feedbackDto.Content,
                        GivenOn = parsedGiveOnDate,
                        Status = parsedStatus,
                        ArtistId = parsedArtistId,
                        GroupId = parsedGroupId
                    };

                    validFeedbacks.Add(feedback);
                    string msgToImport = String.Format(SuccessfullyImportedFeedbackEntity, feedback.GivenOn.ToString("yyyy-MM-dd"), feedback.Status.ToString());
                    output.AppendLine(msgToImport);

                }
                dbContext.Feedbacks.AddRange(validFeedbacks);
                dbContext.SaveChanges();
            }

            return output.ToString().TrimEnd();
        }

        public static string ImportArtworks(ArtCollectiveDbContext dbContext, string jsonString)
        {
            StringBuilder output = new StringBuilder();

            ICollection<Artwork> validArtworks = new List<Artwork>();

            ImportArtworkDto[]? artworkDtos = JsonConvert
                .DeserializeObject<ImportArtworkDto[]>(jsonString);

            if (artworkDtos != null && artworkDtos.Length > 0)
            {
                foreach (ImportArtworkDto artworkDto in artworkDtos)
                {
                    if (!IsValid(artworkDto))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isCreatedOnValid = DateTime
                        .TryParseExact(artworkDto.CreatedOn, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                                                             DateTimeStyles.None, out DateTime parsedCreatedOn);

                    bool isArtistIdValid = int
                        .TryParse(artworkDto.ArtistId, out int parsedArtistId);

                    if ((!isCreatedOnValid) || (!isArtistIdValid))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isArtistIdExist = dbContext
                        .Artists
                        .Any(a => a.Id == parsedArtistId);

                    if (!isArtistIdExist)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isArtworkExist = validArtworks
                        .Any(a => a.Title == artworkDto.Title
                                          && a.ArtistId == parsedArtistId);

                    if (isArtworkExist)
                    {
                        output.AppendLine(DuplicatedData);
                        continue;
                    }

                    Artwork artwork = new Artwork()
                    {
                        Title = artworkDto.Title,
                        Description = artworkDto.Description,
                        CreatedOn = parsedCreatedOn,
                        ArtistId = parsedArtistId,
                    };

                    Artist artist = dbContext
                        .Artists
                        .First(a => a.Id == parsedArtistId);

                    validArtworks.Add(artwork);
                    string msgToAppend = String.Format(SuccessfullyImportedArtworkEntity, artist.Username, artwork.CreatedOn.ToString("yyyy-MM-dd"));
                    output.AppendLine(msgToAppend);
                }

                dbContext.Artworks.AddRange(validArtworks);
                dbContext.SaveChanges();
            }

            return output.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            ValidationContext validationContext = new ValidationContext(dto);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            List<string> errorMessages = new List<string>();
            bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

            errorMessages = validationResults.Select(r => r.ErrorMessage!).ToList();

            return isValid;
        }
    }
}
