using AirboxInterview.LocationService.Dtos;
using AirboxInterview.LocationService.Interfaces;
using AirboxInterview.LocationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirboxInterview.LocationService.Services
{
    public class UserLocationService : IUserLocationService
    {
        private readonly IUserLocationRepository _userLocationRepository;

        public UserLocationService(IUserLocationRepository userLocationRepository)
        {
            _userLocationRepository = userLocationRepository;
        }

        public async Task<IEnumerable<UserLocationDto>> GetUserLocationsByUserId(int userId)
        {
            var userLocations = await _userLocationRepository.GetUserLocationsByUserId(userId);

            return userLocations == null ? null : userLocations.Select(ul => new UserLocationDto()
            {
                UserId = ul.UserId,
                Longitude = ul.Longitude,
                Latitude = ul.Latitude,
                TimeStamp = ul.TimeStamp
            });
        }

        public async Task<UserLocationDto> GetLatestUserLocationByUserId(int userId)
        {
            var userLocation = await _userLocationRepository.GetLatestUserLocationByUserId(userId);

            if (userLocation == null)
                return null;

            return userLocation == null ? null : new UserLocationDto
            {
                UserId = userLocation.UserId,
                Longitude = userLocation.Longitude,
                Latitude = userLocation.Latitude,
                TimeStamp = userLocation.TimeStamp
            };
        }

        public async Task<IEnumerable<UserLocationDto>> GetAllLatestUserLocations()
        {
            var userLocations = await _userLocationRepository.GetAllLatestUserLocations();

            return userLocations == null ? null : userLocations.Select(ul => new UserLocationDto()
            {
                UserId = ul.UserId,
                Longitude = ul.Longitude,
                Latitude = ul.Latitude,
                TimeStamp = ul.TimeStamp
            });
        }

        public async Task<IEnumerable<UserLocationDto>> GetUserLocationWithinArea(LocationAreaDto locationArea)
        {
            var userLocations = await _userLocationRepository.GetUserLocationWithinArea(locationArea);

            return userLocations == null ? null :  userLocations.Select(ul => new UserLocationDto()
            {
                UserId = ul.UserId,
                Longitude = ul.Longitude,
                Latitude = ul.Latitude,
                TimeStamp = ul.TimeStamp
            });
        }

        public async Task CreateUserLocation(UserLocationDto userLocationDto)
        {
            var userLocation = new UserLocation()
            {
                UserId = userLocationDto.UserId,
                Longitude = userLocationDto.Longitude,
                Latitude = userLocationDto.Latitude,
                TimeStamp = userLocationDto.TimeStamp
            };

            await _userLocationRepository.CreateUserLocation(userLocation);
        }
    }
}
