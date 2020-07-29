using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using APS.Areas.Fitness.Models;
using APS.Model;
using APS.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.Extensions.Logging;
using APS.Methods.QueriesExtensions;

namespace APS.Methods.Fitness
{
    public static class Upload
    {
        internal static void Save(IEnumerable<IFormFile> files, IPrincipal User, ILogger _logger)
        {
            if (files != null)
            {
                foreach (var file in files)
                {
                    var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);

                    // Some browsers send file names with full path.
                    // We are only interested in the file name.
                    var fileName = Path.GetFileName(fileContent.FileName.ToString().Trim('"'));


                    using (StreamReader r = new StreamReader(file.OpenReadStream()))
                    {
                        string json = r.ReadToEnd();
                        var items = JsonConvert.DeserializeObject<Root>(json);
                        var sum = items.timelineObjects
                            .Where(x => x.activitySegment != null)
                            .GroupBy(x => new {
                                x.activitySegment.activityType,
                                date = (new DateTime(1970, 1, 1) + TimeSpan.FromMilliseconds(double.Parse(x.activitySegment.duration.startTimestampMs))).Date
                            })
                            .Select(x => new UploadDataVM
                            {
                                User = User.Identity.Name,
                                Date = x.Key.date,
                                ActivityType = x.Key.activityType,
                                Distance = x.Sum(s => s.activitySegment.distance)
                            }).ToList();
                        SaveToDb(sum);
                    }
                    _logger.LogInformation("creating file for fitness." + JsonConvert.SerializeObject(fileName) + " by " + User.Identity.Name);
                }
            }
        }

        private static void SaveToDb(List<UploadDataVM> sum)
        {
            var sumdb = sum.Select(x => new UploadData().Map(x));
            var firstDay = sum.Min(x => x.Date);
            var lastDay = sum.Max(x => x.Date);
            var user = sum.First().User;
            
            using (DBContext db = new DBContext())
            {
                db.UploadData.RemoveRange(db.UploadData.Where(x=>x.Date>= firstDay && x.Date<=lastDay && x.User == user));
                db.UploadData.AddRange(sumdb);

                db.SaveChanges();
            }
        }

        public static void ClearData(ClaimsPrincipal user)
        {
            using (DBContext db = new DBContext())
            {
                db.UploadData.RemoveRange(db.UploadData.Where(x=>x.User == user.Identity.Name));

                db.SaveChanges();
            }
        }
    }
}
