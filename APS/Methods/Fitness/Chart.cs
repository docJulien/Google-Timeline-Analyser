using System;
using System.Collections.Generic;
using System.Linq;
using APS.Areas.Fitness.Models;
using APS.Methods.Common;
using APS.Model;
using Kendo.Mvc.Extensions;

namespace APS.Methods.Fitness
{
    enum Sports
    {
        CYCLING,
        WALKING,
        RUNNING,
        HIKING
    }

    enum Transports
    {
        //UNKNOWN_ACTIVITY_TYPE,
        FLYING,
        IN_BUS,
        IN_PASSENGER_VEHICLE,
        IN_SUBWAY,
        IN_TRAIN,
        MOTORCYCLING
    }

    public class Chart
    {
        internal static IEnumerable<ReportDataVM> GetSportData(string userName)
        {
            var sports = Enum.GetValues(typeof(Sports)).OfType<Sports>().Select(x=>x.ToString());

            return CommonMethods.GetQuery<UploadData>()
                .Where(x => sports.Contains(x.ActivityType) && x.User == userName)
                .GroupBy(g => new { g.ActivityType, g.Date.Year, g.Date.Month })
                .Select(x => new ReportDataVM
                {
                    ActivityType = x.Key.ActivityType,
                    Year = x.Key.Year,
                    Month = x.Key.Month,
                    Cycling = x.Sum(s => s.ActivityType == Sports.CYCLING.ToString() ? s.Distance / 1000 : 0),
                    Walking = x.Sum(s => s.ActivityType == Sports.WALKING.ToString() ? s.Distance / 1000 : 0),
                    Running = x.Sum(s => s.ActivityType == Sports.RUNNING.ToString() ? s.Distance / 1000 : 0),
                    Hiking = x.Sum(s => s.ActivityType == Sports.HIKING.ToString() ? s.Distance / 1000 : 0)
                })
                .ToList();
        }
        internal static IEnumerable<TransportDataVM> GetTransportData(string userName)
        {
            var transports = Enum.GetValues(typeof(Transports)).OfType<Transports>().Select(x => x.ToString());

            return CommonMethods.GetQuery<UploadData>()
                .Where(x => transports.Contains(x.ActivityType) && x.User == userName)
                .GroupBy(g => new { g.ActivityType, g.Date.Year, g.Date.Month })
                .Select(x => new TransportDataVM
                {
                    ActivityType = x.Key.ActivityType,
                    Year = x.Key.Year,
                    Month = x.Key.Month,
                    Flying = x.Sum(s => s.ActivityType == Transports.FLYING.ToString() ? s.Distance / 1000 : 0),
                    InBus = x.Sum(s => s.ActivityType == Transports.IN_BUS.ToString() ? s.Distance / 1000 : 0),
                    InPassengerVehicle = x.Sum(s => s.ActivityType == Transports.IN_PASSENGER_VEHICLE.ToString() ? s.Distance / 1000 : 0),
                    InSubway = x.Sum(s => s.ActivityType == Transports.IN_SUBWAY.ToString() ? s.Distance / 1000 : 0),
                    InTrain = x.Sum(s => s.ActivityType == Transports.IN_TRAIN.ToString() ? s.Distance / 1000 : 0),
                    Motorcycling = x.Sum(s => s.ActivityType == Transports.MOTORCYCLING.ToString() ? s.Distance / 1000 : 0)
                })
                .ToList();
        }
    }
}
