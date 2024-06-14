using System.ComponentModel.DataAnnotations;

namespace RNR_WebAPI.Model
{
    public class Breakdown
    {
        [Key]
        public string BreakdownReference { get; set; }
        public string CompanyName { get; set; }
        public string DriverName { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime BreakdownDate { get; set; }
    }
}
