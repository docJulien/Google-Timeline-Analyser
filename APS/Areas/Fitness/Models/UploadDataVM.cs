
using APS.Model;

namespace APS.Areas.Fitness.Models
{
    public sealed class UploadDataVM : UploadData
    {
        public double DistanceKm => ((double)Distance) / 1000;
        public int Year => Date.Year;
        public int Month => Date.Month;
    }
}