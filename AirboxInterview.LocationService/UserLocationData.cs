using AirboxInterview.LocationService.Models;
using System;
using System.Collections.Generic;

namespace AirboxInterview.LocationService
{
    public static class UserLocationData
    {
        public static List<UserLocation> UserLocations = new List<UserLocation>()
        {
            new UserLocation
            {
                TimeStamp = new DateTime(2019, 07, 20, 15, 30, 0),
                UserId = 1,
                Longitude = 1.1,
                Latitude = 0.5
            },
            new UserLocation
            {
                TimeStamp = new DateTime(2019, 07, 20, 14, 30, 0),
                UserId = 2,
                Longitude = 1.6,
                Latitude = 0.7
            },
            new UserLocation
            {
                TimeStamp = new DateTime(2019, 07, 20, 15, 0, 0),
                UserId = 3,
                Longitude = 2.3,
                Latitude = 1.9
            },
            new UserLocation
            {
                TimeStamp = new DateTime(2019, 07, 20, 10, 30, 0),
                UserId = 4,
                Longitude = 3.1,
                Latitude = 3.9
            },
            new UserLocation
            {
                TimeStamp = new DateTime(2019, 07, 20, 16, 30, 0),
                UserId = 5,
                Longitude = 3.9,
                Latitude = 2.1
            },
            new UserLocation
            {
                TimeStamp = new DateTime(2019, 07, 20, 16, 35, 0),
                UserId = 5,
                Longitude = 3.2,
                Latitude = 4.1
            },
            new UserLocation
            {
                TimeStamp = new DateTime(2019, 07, 20, 16, 40, 0),
                UserId = 5,
                Longitude = 3.2,
                Latitude = 3.9
            },
            new UserLocation
            {
                TimeStamp = new DateTime(2019, 07, 20, 15, 30, 0),
                UserId = 6,
                Longitude = 1.7,
                Latitude = 0.2
            },
            new UserLocation
            {
                TimeStamp = new DateTime(2019, 07, 20, 16, 0, 0),
                UserId = 6, 
                Longitude = 1.8,
                Latitude = 0.3
            },
            new UserLocation
            {
                TimeStamp = new DateTime(2019, 07, 20, 16, 30, 0),
                UserId = 6,
                Longitude = 1.9,
                Latitude = 0.9
            },
            new UserLocation
            {
                TimeStamp = new DateTime(2019, 07, 20, 17, 0, 0),
                UserId = 6,
                Longitude = 1.8,
                Latitude = 0.6
            }
        };
    }
}
