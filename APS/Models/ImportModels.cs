using System.Collections.Generic;

namespace APS.Models
{
    public class SourceInfo
    {
        public int deviceTag { get; set; }

    }

    public class StartLocation
    {
        public int latitudeE7 { get; set; }
        public int longitudeE7 { get; set; }
        public SourceInfo sourceInfo { get; set; }

    }

    public class SourceInfo2
    {
        public int deviceTag { get; set; }

    }

    public class EndLocation
    {
        public int latitudeE7 { get; set; }
        public int longitudeE7 { get; set; }
        public SourceInfo2 sourceInfo { get; set; }

    }

    public class Duration
    {
        public string startTimestampMs { get; set; }
        public string endTimestampMs { get; set; }

    }

    public class Activity
    {
        public string activityType { get; set; }
        public double probability { get; set; }

    }

    public class Waypoint
    {
        public int latE7 { get; set; }
        public int lngE7 { get; set; }

    }

    public class WaypointPath
    {
        public List<Waypoint> waypoints { get; set; }

    }

    public class Point
    {
        public int latE7 { get; set; }
        public int lngE7 { get; set; }
        public string timestampMs { get; set; }
        public int accuracyMeters { get; set; }

    }

    public class SimplifiedRawPath
    {
        public List<Point> points { get; set; }

    }

    public class Location
    {
        public int latitudeE7 { get; set; }
        public int longitudeE7 { get; set; }
        public int accuracyMetres { get; set; }

    }

    public class ParkingEvent
    {
        public string timestampMs { get; set; }
        public Location location { get; set; }

    }

    public class ActivitySegment
    {
        public StartLocation startLocation { get; set; }
        public EndLocation endLocation { get; set; }
        public Duration duration { get; set; }
        public int distance { get; set; }
        public string activityType { get; set; }
        public string confidence { get; set; }
        public List<Activity> activities { get; set; }
        public WaypointPath waypointPath { get; set; }
        public SimplifiedRawPath simplifiedRawPath { get; set; }
        public ParkingEvent parkingEvent { get; set; }

    }

    public class SourceInfo3
    {
        public int deviceTag { get; set; }

    }

    public class Location2
    {
        public int latitudeE7 { get; set; }
        public int longitudeE7 { get; set; }
        public string placeId { get; set; }
        public string address { get; set; }
        public string name { get; set; }
        public SourceInfo3 sourceInfo { get; set; }
        public double locationConfidence { get; set; }

    }

    public class Duration2
    {
        public string startTimestampMs { get; set; }
        public string endTimestampMs { get; set; }

    }

    public class OtherCandidateLocation
    {
        public int latitudeE7 { get; set; }
        public int longitudeE7 { get; set; }
        public string placeId { get; set; }
        public double locationConfidence { get; set; }

    }

    public class PlaceVisit
    {
        public Location2 location { get; set; }
        public Duration2 duration { get; set; }
        public string placeConfidence { get; set; }
        public int centerLatE7 { get; set; }
        public int centerLngE7 { get; set; }
        public int visitConfidence { get; set; }
        public List<OtherCandidateLocation> otherCandidateLocations { get; set; }
        public string editConfirmationStatus { get; set; }

    }

    public class TimelineObject
    {
        public ActivitySegment activitySegment { get; set; }
        public PlaceVisit placeVisit { get; set; }

    }

    public class Root
    {
        public List<TimelineObject> timelineObjects { get; set; }

    }


}
