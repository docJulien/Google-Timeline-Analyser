using System;
using System.ComponentModel.DataAnnotations;

namespace APS.Model
{
    public class UploadData
    {
        [Key]
        public int Id { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }
        public string ActivityType { get; set; }
        public int Distance { get; set; }
    }
}
