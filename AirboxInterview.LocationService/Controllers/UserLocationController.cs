using Microsoft.AspNetCore.Mvc;
using AirboxInterview.LocationService.Interfaces;
using System.Threading.Tasks;
using AirboxInterview.LocationService.Dtos;
using System;
using System.Net;
using System.Linq;

namespace AirboxInterview.LocationService.Controllers
{
    [Route("api/[controller]")]
    public class UserLocationController : Controller
    {
        private readonly IUserLocationService _userLocationService;

        public UserLocationController(IUserLocationService userLocationService)
        {
            _userLocationService = userLocationService;
        }

        // GET api/userlocation/latest
        [HttpGet("latest")]
        public async Task<IActionResult> GetAllLatest()
        {
            try
            {
                var userLocations = (await _userLocationService.GetAllLatestUserLocations()).ToList();

                if (userLocations == null || userLocations.Count == 0)
                    return Ok($"No locations found");

                return Ok(userLocations);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
           
        }

        // GET api/userlocation/5/latest
        [HttpGet("latest/{id}")]
        public async Task<IActionResult> GetLatest(int id)
        {
            try
            {
                var userLocation = await _userLocationService.GetLatestUserLocationByUserId(id);

                 if (userLocation == null)
                    return Ok($"No locations for user: {id} found");

                return Ok(userLocation);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
            
        }

        // GET api/userlocation/5/history
        [HttpGet("history/{id}")]
        public async Task<IActionResult> GetHistory(int id)
        {
            try
            {
                var userLocations = (await _userLocationService.GetUserLocationsByUserId(id)).ToList();

                if (userLocations == null || userLocations.Count == 0)
                    return Ok($"No history for user: {id} found");

                return Ok(userLocations);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET api/userlocation/?fromLongitude=1.5&fromLatitude=2.1
        [HttpGet("area")]
        public async Task<IActionResult> GetWithinArea([FromQuery]LocationAreaDto locationArea)
        {
            try
            {
                var userLocations = (await _userLocationService.GetUserLocationWithinArea(locationArea)).ToList();

                if (userLocations == null || userLocations.Count == 0)
                    return Ok($"No locations found for users within specified area");

                return Ok(userLocations);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // POST api/userlocation
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]UserLocationDto userLocation)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                await _userLocationService.CreateUserLocation(userLocation);

                return Ok("UserLocation Created");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
