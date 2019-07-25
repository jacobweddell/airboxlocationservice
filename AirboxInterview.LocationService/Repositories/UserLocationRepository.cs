using AirboxInterview.LocationService.Dtos;
using AirboxInterview.LocationService.Interfaces;
using AirboxInterview.LocationService.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirboxInterview.LocationService.Repositories
{
    public class UserLocationRepository : IUserLocationRepository
    {
        private readonly UserLocationContext _context;
        private readonly DbSet<UserLocation> _dbSet;

        public UserLocationRepository(UserLocationContext context)
        {
            _context = context;
            _dbSet = _context.Set<UserLocation>();
        }

        public async Task<IEnumerable<UserLocation>> GetUserLocationsByUserId(int userId)
        {
            return await _dbSet.Where(ul => ul.UserId == userId).ToListAsync();
        }

        public async Task<UserLocation> GetCurrentUserLocationByUserId(int userId)
        {
            return await _dbSet.OrderByDescending(ul => ul.TimeStamp).FirstOrDefaultAsync(ul => ul.UserId == userId);
        }

        public async Task<IEnumerable<UserLocation>> GetAllCurrentUserLocations()
        {
            return await _dbSet.GroupBy(ul => ul.UserId).Select(group => group.OrderByDescending(ul => ul.TimeStamp).First()).ToListAsync();
        }

        public async Task<IEnumerable<UserLocation>> GetUserLocationWithinArea(LocationAreaDto locationArea)
        {
            var result = _dbSet.GroupBy(ul => ul.UserId).Select(group => group.OrderByDescending(ul => ul.TimeStamp).First()).
                Where(ul => ul.Latitude > locationArea.FromLatitude
                && ul.Longitude > locationArea.FromLongitude
                && ul.Latitude < locationArea.ToLatitude
                && ul.Longitude < locationArea.ToLongitude).ToListAsync();

            return await result;
        }

        public async Task CreateUserLocation(UserLocation userLocation)
        {
            await _dbSet.AddAsync(userLocation);
            await _context.SaveChangesAsync();
        }

    }
}
