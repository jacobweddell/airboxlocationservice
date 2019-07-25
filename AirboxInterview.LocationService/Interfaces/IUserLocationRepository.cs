using AirboxInterview.LocationService.Dtos;
using AirboxInterview.LocationService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirboxInterview.LocationService.Interfaces
{
    public interface IUserLocationRepository
    {
        /// <summary>
        /// Gets all locations for a given userId
        /// </summary>
        /// <param name="userId">the id of the user</param>
        /// <returns>The locations for the user</returns>
        Task<IEnumerable<UserLocation>> GetUserLocationsByUserId(int userId);

        /// <summary>
        /// Gets the location for a given userId
        /// </summary>
        /// <param name="userId">the id of the user</param>
        /// <returns>The latest location for the user</returns>
        Task<UserLocation> GetCurrentUserLocationByUserId(int userId);

        /// <summary>
        /// Gets the latest locations for all users
        /// </summary>
        /// <returns>the latest locations for all users</returns>
        Task<IEnumerable<UserLocation>> GetAllCurrentUserLocations();

        /// <summary>
        /// Gets the user locations that are within the area of the location area given
        /// </summary>
        /// <param name="locationArea">the location area to look in</param>
        /// <returns></returns>
        Task<IEnumerable<UserLocation>> GetUserLocationWithinArea(LocationAreaDto locationArea);

        /// <summary>
        /// Creates a new entry for user location
        /// </summary>
        /// <param name="userLocation">the user location to create</param>
        /// <returns></returns>
        Task CreateUserLocation(UserLocation userLocation);
    }
}
