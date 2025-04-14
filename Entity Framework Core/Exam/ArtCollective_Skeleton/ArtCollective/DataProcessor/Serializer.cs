using System.Xml.Serialization;
using System.Xml;
using ArtCollective.Data;
using Newtonsoft.Json;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using ArtCollective.DataProcessor.ExportDTOs;
using ArtCollective.Data.Models;
using ArtCollective.Data.Utilities;
using ArtCollective.Data.Models.Enums;

namespace ArtCollective.DataProcessor
{
    public class Serializer
    {
        public static string ExportArtistsWithCollaborationsCountAndTheirArtworks(ArtCollectiveDbContext dbContext)
        {
            var artistsToExport = dbContext
                .Artists
                .Select(a => new ExportArtistsWithColDto
                {
                    Username = a.Username,
                    Collaborations = (a.CollaborationsAsArtistOne.Count + a.CollaborationsAsArtistTwo.Count).ToString(),
                    Artworks = a.Artworks
                              .OrderBy(a => a.Id)
                              .Select(aw => new ExportArtistArtworkDto
                              {
                                  Title = aw.Title,
                                  CreatedOn = aw.CreatedOn.ToString("yyyy-MM-dd")
                              })
                              .ToArray()
                })
                .OrderBy(a => a.Username)
                .ToArray();

            string output = XmlHelper
                .Serialize(artistsToExport, "Artists");

            return output;
        }
        public static string ExportGroupsWithFeedbacksChronologically(ArtCollectiveDbContext dbContext)
        {
            var groupsWithFeedbacks = dbContext
                .Groups
                .OrderBy(g => g.StartedOn)
                .Select(g => new
                {
                    Id = g.Id,
                    Title = g.Title,
                    StartedOn = g.StartedOn.ToString("yyyy-MM-dd"),
                    Feedbacks = g.Feedbacks
                                .OrderBy(f => f.GivenOn)
                                .Select(f => new
                                {
                                    Content = f.Content,
                                    GivenOn = f.GivenOn.ToString("yyyy-MM-dd"),
                                    Status = f.Status,
                                    ArtistUsername = f.Artist.Username
                                })
                                .ToArray()

                })
                .ToArray();

            string output = JsonConvert
                .SerializeObject(groupsWithFeedbacks, Newtonsoft.Json.Formatting.Indented);

            return output;
        }
    }
}
