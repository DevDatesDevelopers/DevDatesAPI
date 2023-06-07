using DevDates.DBModel.Data;
using DevDates.DBModel.Data.Models;
using DevDatesAPI;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevDates.API.IntegrationTests
{/*
    public class DevDatesControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public DevDatesControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task TestGetUsers()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/users");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<List<User>>(responseString);
            Assert.NotNull(users);
            Assert.Equal(0, users.Count);
        }

        [Fact]
        public async Task TestAddUser()
        {
            // Arrange
            var client = _factory.CreateClient();

            var userViewModel = new UserViewModel
            {
                Name = "Jane Doe",
                DateOfBirth = new DateTime(1995, 3, 15),
                Gender = Gender.Female,
                Bio = "Ut enim ad minim veniam.",
                Interests = new List<string>
                {
                    "Yoga",
                    "Traveling"
                },
                UsersPreferences = new List<Gender>
                {
                    Gender.Male
                },
                Resources = new List<ResourceViewModel>
                {
                    new ResourceViewModel { ResourceTypeId = 1, ResourceUri = "https://example.com/photo2.jpg" },
                    new ResourceViewModel { ResourceTypeId = 2, ResourceUri = "https://example.com/twitter2" }
                }
            };

            var json = JsonConvert.SerializeObject(userViewModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync("/api/users", content);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var resultUser = JsonConvert.DeserializeObject<User>(responseString);
            Assert.NotEqual(Guid.Empty, resultUser.Id);
            Assert.Equal(userViewModel.Name, resultUser.Name);
            Assert.Equal(userViewModel.DateOfBirth, resultUser.DateOfBirth);
            Assert.Equal(userViewModel.Gender, resultUser.Gender);
            Assert.Equal(userViewModel.Bio, resultUser.Bio);
            Assert.Equal(userViewModel.Interests.Count, resultUser.Interests.Count);
            Assert.Equal(userViewModel.UsersPreferences.Count, resultUser.UsersPreferences.Count);
            Assert.Equal(userViewModel.Resources.Count, resultUser.Resources.Count);
            for (int i = 0; i < userViewModel.Interests.Count; i++)
            {
                Assert.Equal(userViewModel.Interests[i], resultUser.Interests[i].DisplayName);
            }
            for (int i = 0; i < userViewModel.UsersPreferences.Count; i++)
            {
                Assert.Equal(userViewModel.UsersPreferences[i], resultUser.UsersPreferences[i].Gender);
            }
            for (int i = 0; i < userViewModel.Resources.Count; i++)
            {
                Assert.Equal(userViewModel.Resources[i].ResourceTypeId, resultUser.Resources[i].ResourceTypeId);
                Assert.Equal(userViewModel.Resources[i].ResourceUri, resultUser.Resources[i].ResourceUri);
            }
        }

        [Fact]
        public async Task TestGetUserById()
        {
            // Arrange
            var client = _factory.CreateClient();

            var user = new User;


            // add the user to the database
            using (var scope = _factory.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DevDatesDbContext>();
                var user1 = new User
                {
                    Name = "John Smith",
                    DateOfBirth = new DateTime(1990, 1, 1),
                   // Gender = Gender.Male,
                    Bio = "Lorem ipsum dolor sit amet.",
                    Interests = new List<Interest>
                {
                    new Interest { DisplayName = "Hiking" },
                    new Interest { DisplayName = "Cooking" },
              *//*  },
                    UsersPreferences = new List<UserSexualPreference>
                {
                    new UserSexualPreference { Gender = Gender.Female }
                },
                    Resources = new List<Resource>
                {
                    new Resource { ResourceTypeId = 1, ResourceUri = "https://example.com/photo1.jpg" },
                    new Resource { ResourceTypeId = 2, ResourceUri = "https://example.com/twitter1" },
                }
                };*//*

                //context.Users.Add(user1);
               // await context.SaveChangesAsync();

                // Act
                var response = await client.GetAsync($"/api/users/{user1.Id}");

                // Assert
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();
                var resultUser = JsonConvert.DeserializeObject<User>(responseString);
                Assert.NotNull(resultUser);
                Assert.Equal(user1.Id, resultUser.Id);
                Assert.Equal(user1.Name, resultUser.Name);
                Assert.Equal(user1.DateOfBirth, resultUser.DateOfBirth);
                Assert.Equal(user1.Gender, resultUser.Gender);
                Assert.Equal(user1.Bio, resultUser.Bio);
                Assert.Equal(user1.Interests.Count, resultUser.Interests.Count);
                Assert.Equal(user1.UsersPreferences.Count, resultUser.UsersPreferences.Count);
                Assert.Equal(user1.Resources.Count, resultUser.Resources.Count);
               *//* for (int i = 0; i < user1.Interests.Count; i++)
                {
                    Assert.Equal(user1.Interests[i].DisplayName, resultUser.Interests[i].DisplayName);
                }
                for (int i = 0; i < user1.UsersPreferences.Count; i++)
                {
                    Assert.Equal(user1.UsersPreferences[i].Gender, resultUser.UsersPreferences[i].Gender);
                }
                for (int i = 0; i < user1.Resources.Count; i++)
                {
                    Assert.Equal(user1.Resources[i].ResourceTypeId, resultUser.Resources[i].ResourceTypeId);
                    Assert.Equal(user1.Resources[i].ResourceUri, resultUser.Resources[i].ResourceUri);
                }*//*
            }
        }*/
    //}
}