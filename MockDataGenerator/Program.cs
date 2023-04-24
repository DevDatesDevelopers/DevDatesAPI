using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Bogus;
using DevDates.Model.ViewModels;

class Program
{
    static async System.Threading.Tasks.Task Main(string[] args)
    {
        var connectionString = "Server=devdates.database.windows.net;Database=DevDatesDB;User Id=class;Password=DevDatesPublic123;";

        using var connection = new SqlConnection(connectionString);
        await connection.OpenAsync();

        Console.WriteLine("Connected to the database");

        await InsertGenders(connection);
        await InsertUsers(connection);

        Console.WriteLine("Finished generating mock data");
    }

    static async System.Threading.Tasks.Task InsertGenders(SqlConnection connection)
    {
        var genders = new List<ShortUserInfo> {
            new ShortUserInfo { Gender = "Male" },
            new ShortUserInfo{ Gender = "Female" },
            new ShortUserInfo{ Gender = "Non-binary" }
        };

        foreach (var gender in genders)
        {
            try
            {
                await using var command = new SqlCommand("INSERT INTO Genders (DisplayName, Created, Modified, ModifiedBy) VALUES (@displayName, GETDATE(), GETDATE(), 'Admin')", connection);
                command.Parameters.AddWithValue("@displayName", gender.Gender);
                await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Inserted gender {gender.Gender}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    static async System.Threading.Tasks.Task InsertUsers(SqlConnection connection)
    {
        var genders = new List<int>();

        await using (var command = new SqlCommand("SELECT Id FROM Genders", connection))
        {
            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                genders.Add(reader.GetInt32(0));
            }
        }

        var faker = new Faker();
        for (int i = 0; i < 10; i++)
        {
            var name = faker.Name.FullName();
            var dob = faker.Date.Past(50);
            var genderId = faker.Random.ArrayElement(genders.ToArray());
            var bio = faker.Lorem.Sentence();
            var email = faker.Internet.Email();

            try
            {
                await using var command = new SqlCommand("INSERT INTO Users (Name, DateOfBirth, GenderId, Bio, Email, Created, Modified, ModifiedBy) VALUES (@name, @dob, @genderId, @bio, @email, GETDATE(), GETDATE(), 'Admin')", connection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@dob", dob);
                command.Parameters.AddWithValue("@genderId", genderId);
                command.Parameters.AddWithValue("@bio", bio);
                command.Parameters.AddWithValue("@email", email);
                await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Inserted user {name}");
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
//A valid connection string to a Microsoft SQL Server database.fied database with the required columns.
//The necessary .NET libraries are installed and available on your system to compile and run the code.