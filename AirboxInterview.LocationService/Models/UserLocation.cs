using System;
using System.ComponentModel.DataAnnotations;

namespace AirboxInterview.LocationService.Models
{
    public class UserLocation
    {
        public int UserLocationId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public DateTime TimeStamp { get; set; }
    }
}
