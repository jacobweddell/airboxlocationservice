using System.ComponentModel.DataAnnotations;

namespace AirboxInterview.LocationService.Dtos
{
    public class LocationAreaDto
    {
        [Required]
        public double FromLatitude { get; set; }

        [Required]
        public double FromLongitude { get; set; }

        [Required]
        public double ToLatitude { get; set; }

        [Required]
        public double ToLongitude { get; set; }
    }
}
