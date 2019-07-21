using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using AirboxInterview.LocationService.Models;
using AirboxInterview.LocationService.Repositories;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace AirboxInterview.LocationService.Tests
{
    [TestClass]
    public class UserLocationTests
    {
        [TestMethod]
        public async Task CreateUserLocation_Saves_To_Database()
        {
            var options = new DbContextOptionsBuilder<UserLocationContext>()
                .UseInMemoryDatabase(databaseName: "CreateUserLocation_Saves_To_Database")
                .Options;

            using (var context = new UserLocationContext(options))
            {
                var repository = new UserLocationRepository(context);

                await repository.CreateUserLocation(UserLocationData.UserLocations[0]);

                Assert.AreEqual(1, context.UserLocation.Count());
                Assert.AreEqual(1, context.UserLocation.Single().UserId);

            }
        }

        [TestMethod]
        public async Task GetAllLatestUserLocations_Returns_Correct_Number()
        {
            var options = new DbContextOptionsBuilder<UserLocationContext>()
                .UseInMemoryDatabase(databaseName: "GetAllLatestUserLocations_Saves_To_Database")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new UserLocationContext(options))
            {
                context.UserLocation.Add(UserLocationData.UserLocations[0]);
                context.UserLocation.Add(UserLocationData.UserLocations[1]);
                context.UserLocation.Add(UserLocationData.UserLocations[2]);
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new UserLocationContext(options))
            {
                var repository = new UserLocationRepository(context);
                var result = (await repository.GetAllLatestUserLocations()).ToList();
                Assert.AreEqual(3, result.Count());
            }
        }

        [TestMethod]
        public async Task GetLatestUserLocationByUserId_Returns_Correct_UserLocation_DateTime()
        {
            var options = new DbContextOptionsBuilder<UserLocationContext>()
                .UseInMemoryDatabase(databaseName: "GetLatestUserLocationByUserId_Returns_Correct_UserLocation_DateTime")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new UserLocationContext(options))
            {
                context.UserLocation.Add(UserLocationData.UserLocations[4]);
                context.UserLocation.Add(UserLocationData.UserLocations[5]);
                context.UserLocation.Add(UserLocationData.UserLocations[6]);
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new UserLocationContext(options))
            {
                var repository = new UserLocationRepository(context);
                var result = (await repository.GetLatestUserLocationByUserId(5));

                const string format = "dd/mm/yyyy HH:mm:ss";

                Assert.AreEqual(new DateTime(2019, 07, 20, 16, 40, 0).ToString(format), result.TimeStamp.ToString(format));
            }
        }

        [TestMethod]
        public async Task GetLatestUserLocationByUserId_Where_Not_Exists_Returns_Null()
        {
            var options = new DbContextOptionsBuilder<UserLocationContext>()
                .UseInMemoryDatabase(databaseName: "GetLatestUserLocationByUserId_Where_Not_Exists_Returns_Null")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new UserLocationContext(options))
            {
                context.UserLocation.Add(UserLocationData.UserLocations[0]);
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new UserLocationContext(options))
            {
                var repository = new UserLocationRepository(context);
                var result = (await repository.GetLatestUserLocationByUserId(2));
                Assert.IsNull(result);
            }
        }

        [TestMethod]
        public async Task GetUserLocationWithinArea_Return_Correct_Results()
        {
            var options = new DbContextOptionsBuilder<UserLocationContext>()
                .UseInMemoryDatabase(databaseName: "GetUserLocationWithinArea_Return_Correct_Results")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new UserLocationContext(options))
            {
                context.UserLocation.AddRange(UserLocationData.UserLocations);
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new UserLocationContext(options))
            {
                var repository = new UserLocationRepository(context);
                var result = (await repository.GetUserLocationWithinArea(
                    new Dtos.LocationAreaDto
                    {
                        FromLatitude = 3.0,
                        FromLongitude = 3.0,
                        ToLatitude = 4.0,
                        ToLongitude = 4.0
                    })).ToList();

                Assert.AreEqual(2, result.Count);
                Assert.IsNotNull(result.Where(ul => ul.UserId == 4));
                Assert.IsNotNull(result.Where(ul => ul.UserId == 5));
            }
        }

    }
}
