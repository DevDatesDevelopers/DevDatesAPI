using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using Bogus;
using DevDates.Model.ViewModels;
using Microsoft.VisualBasic;

class Program
{
    static void Main(string[] args)
    {

        DevDates.DBModel.Data.DevDatesDbContext context = new DevDates.DBModel.Data.DevDatesDbContext();

        Console.WriteLine("Connected to the database");

        InsertUserInterest(context);


        // Add
        await InsertResourcesTypes(connection);
        await InsertResources(connection);
        await InsertInterests(connection);
        await InterestsResources(connection);
        await InterestsUsersResources(connection);
        await InsertGenderResources(connection);
        await InsertUserPreferences(connection);
        await InsertUsersInterests(connection);

        Console.WriteLine("Finished generating mock data");
    }

    static void InsertGenders(DevDates.DBModel.Data.DevDatesDbContext context)
    {
        string[] genders = { "Male", "Female", "Non-Binary" };

        foreach (var gender in context.Genders.ToArray())
        {
            Console.WriteLine(gender);
        }

        foreach (var gender in genders)
        {
            try
            {
                context.Genders.Add(new DevDates.DBModel.Data.Models.Gender { DisplayName = gender });
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
    static void InsertUsers(DevDates.DBModel.Data.DevDatesDbContext context)
    {
        List<DevDates.DBModel.Data.Models.User> users = new List<DevDates.DBModel.Data.Models.User>();

        users.Add(new DevDates.DBModel.Data.Models.User { Name = "Ivan", DateOfBirth = DateTime.Now, GenderId = 0 });
        users.Add(new DevDates.DBModel.Data.Models.User { Name = "Viktor", DateOfBirth = DateTime.Now, GenderId = 2 });
        users.Add(new DevDates.DBModel.Data.Models.User { Name = "Petkanla", DateOfBirth  = DateTime.Now, GenderId = 1 });
        foreach (var user in users)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }
    }

    static void InsertInterests(DevDates.DBModel.Data.DevDatesDbContext context)
    {
        List<DevDates.DBModel.Data.Models.Interest> interests = new List<DevDates.DBModel.Data.Models.Interest>();

        interests.Add(new DevDates.DBModel.Data.Models.Interest { DisplayName = "Tennis" });
        interests.Add(new DevDates.DBModel.Data.Models.Interest { DisplayName  ="Gaming" });

        foreach (var item in interests)
        {
            context.Interests.Add(item);
            context.SaveChanges();
        }
    }
    static void InsertUserPreferences(DevDates.DBModel.Data.DevDatesDbContext context)
    {
        List<DevDates.DBModel.Data.Models.UsersPreference> interests = new List<DevDates.DBModel.Data.Models.UsersPreference>();
        interests.Add(new DevDates.DBModel.Data.Models.UsersPreference { UserId = 1 , GenderId = 1});
        interests.Add(new DevDates.DBModel.Data.Models.UsersPreference { UserId = 2, GenderId = 2});

        foreach (var item in interests)
        {
            try
            {
                context.UsersPreferences.Add(item);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }

    static void InsertUserInterest(DevDates.DBModel.Data.DevDatesDbContext context)
    {
        List<DevDates.DBModel.Data.Models.User> interests = new List<DevDates.DBModel.Data.Models.UsersPreference>();
        interests.Add(new DevDates.DBModel.Data.Models.UsersPreference { UserId = 1, GenderId = 1 });
        interests.Add(new DevDates.DBModel.Data.Models.UsersPreference { UserId = 2, GenderId = 2 });

        foreach (var item in interests)
        {
            try
            {
                context.UsersPreferences.Add(item);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}


//Check these

//Access to the specified database with appropriate permissions to create tables and insert data.
//The required tables Genders and Users exist in the specified database with the required columns.
//The required tables Genders and Users exist in the specified database with the required columns.
//The necessary .NET libraries are installed and available on your system to compile and run the code.