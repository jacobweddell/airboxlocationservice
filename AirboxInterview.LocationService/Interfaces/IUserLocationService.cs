using AirboxInterview.LocationService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirboxInterview.LocationService.Interfaces
{
    public interface IUserLocationService
    {
        /// <summary>
        /// Gets all locations for a given userId
        /// </summary>
        /// <param name="userId">the id of the user</param>
        /// <returns>The LocationDtos representing the locations for the user</returns>
        Task<IEnumerable<UserLocationDto>> GetUserLocationsByUserId(int userId);

        /// <summary>
        /// Gets the location for a given userId
        /// </summary>
        /// <param name="userId">the id of the user</param>
        /// <returns>A LocationDto representing the location for the user</returns>
        Task<UserLocationDto> GetCurrentUserLocationByUserId(int userId);

        /// <summary>
        /// Gets the latest locations for all users
        /// </summary>
        /// <returns>LocationDtos representing the latest locations for all users</returns>
        Task<IEnumerable<UserLocationDto>> GetAllCurrentUserLocations();

        /// <summary>
        /// Gets the user locations that are within the area of the location area given
        /// </summary>
        /// <param name="locationAreaDto">A location dto reprsenting the location area to look in</param>
        /// <returns>LocationDtos representing the latest locations for all users within the specifies area</returns>
        Task<IEnumerable<UserLocationDto>> GetUserLocationWithinArea(LocationAreaDto locationArea);

        /// <summary>
        /// Creates a new entry for user location
        /// </summary>
        /// <param name="userLocationDto">A locationDto representing the user location to create</param>
        /// <returns></returns>
        Task CreateUserLocation(UserLocationDto userLocationDto);
    }
}
