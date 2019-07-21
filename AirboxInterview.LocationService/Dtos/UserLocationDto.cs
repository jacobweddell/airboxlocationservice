using System;
using System.ComponentModel.DataAnnotations;

namespace AirboxInterview.LocationService.Dtos
{
    public class UserLocationDto
    {
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
