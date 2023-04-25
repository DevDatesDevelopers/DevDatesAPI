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

    //static async System.Threading.Tasks.Task InsertGenders(SqlConnection connection)
    //{
    //    var genders = new List<ShortUserInfo> {
    //        new ShortUserInfo { Gender = "Male" },
    //        new ShortUserInfo{ Gender = "Female" },
    //        new ShortUserInfo{ Gender = "Non-binary" }
    //    };

    //    foreach (var gender in genders)
    //    {
    //        try
    //        {
    //            await using var command = new SqlCommand("INSERT INTO Genders (Id, DisplayName, Created, Modified, ModifiedBy) VALUES (/*@id,*/ @displayName, GETDATE(), GETDATE(), 'Admin')", connection);
    //            //command.Parameters.AddWithValue("@id", Guid.NewGuid());
    //            command.Parameters.AddWithValue("@displayName", gender.Gender);
    //            await command.ExecuteNonQueryAsync();
    //            Console.WriteLine($"Inserted gender {gender.Gender}");
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(ex.Message);
    //        }
    //    }
    //}
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
                var id = Guid.NewGuid();

                await using var command = new SqlCommand("INSERT INTO Genders (Id, DisplayName, Created, Modified, ModifiedBy) VALUES (@id, @displayName, GETDATE(), GETDATE(), 'Admin')", connection);
                command.Parameters.AddWithValue("@id", id);
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


    //static async System.Threading.Tasks.Task InsertUsers(SqlConnection connection)
    //{
    //    var genders = new List<int>();

    //    await using (var command = new SqlCommand("SELECT Id FROM Genders", connection))
    //    {
    //        await using var reader = await command.ExecuteReaderAsync();
    //        while (await reader.ReadAsync())
    //        {
    //            genders.Add(reader.GetInt32(0));
    //        }
    //    }

    //    var faker = new Faker();
    //    for (int i = 0; i < 10; i++)
    //    {
    //        //var id = Guid.NewGuid();
    //        var name = faker.Name.FullName();
    //        var dob = faker.Date.Past(50);
    //        var genderId = faker.Random.ArrayElement(genders.ToArray());
    //        var bio = faker.Lorem.Sentence();
    //        var email = faker.Internet.Email();

    //        try
    //        {
    //            await using var command = new SqlCommand("INSERT INTO Users (Id, Name, DateOfBirth, GenderId, Bio, Email, Created, Modified, ModifiedBy) VALUES (/*@id,*/ @name, @dob, @genderId, @bio, @email, GETDATE(), GETDATE(), 'Admin')", connection);
    //            //command.Parameters.AddWithValue("@id", id);
    //            command.Parameters.AddWithValue("@name", name);
    //            command.Parameters.AddWithValue("@dob", dob);
    //            command.Parameters.AddWithValue("@genderId", genderId);
    //            command.Parameters.AddWithValue("@bio", bio);
    //            command.Parameters.AddWithValue("@email", email);
    //            await command.ExecuteNonQueryAsync();
    //            Console.WriteLine($"Inserted user {name}");
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(ex.Message);
    //        }
    //    }
    //}
    static async System.Threading.Tasks.Task InsertUsers(SqlConnection connection)
    {
        var genders = new List<Guid>();

        await using (var command = new SqlCommand("SELECT Id FROM Genders", connection))
        {
            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                genders.Add(reader.GetGuid(0));
            }
        }

        var faker = new Faker();
        for (int i = 0; i < 10; i++)
        {
            var id = Guid.NewGuid();
            var name = faker.Name.FullName();
            var dob = faker.Date.Past(50);
            var genderId = faker.Random.ArrayElement(genders.ToArray());
            var bio = faker.Lorem.Sentence();
            var email = faker.Internet.Email();

            try
            {
                await using var command = new SqlCommand("INSERT INTO Users (Id, Name, DateOfBirth, GenderId, Bio, Email, Created, Modified, ModifiedBy) VALUES (@id, @name, @dob, @genderId, @bio, @email, GETDATE(), GETDATE(), 'Admin')", connection);
                command.Parameters.AddWithValue("@id", id);
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

    static async System.Threading.Tasks.Task InsertResourcesTypes(SqlConnection connection)
    {
        var resourcestypes = new List<Guid>();

        var faker = new Faker();
        for (int i = 0; i < 10; i++)
        {
            var id = Guid.NewGuid();
            var displayName = faker.Name.FullName();

            try
            {
                await using var command = new SqlCommand("INSERT INTO ResourcesTypes (Id, Name, Created, Modified, ModifiedBy) VALUES (@id, @displayName, GETDATE(), GETDATE(), 'Admin')", connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@displayName", displayName);
                await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Inserted resources types.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    static async System.Threading.Tasks.Task InsertResources(SqlConnection connection)
    {
        var resources = new List<Guid>();

        await using (var command = new SqlCommand("SELECT Id FROM ResourcesTypes", connection))
        {
            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                resources.Add(reader.GetGuid(0));
            }
        }

        var faker = new Faker();
        for (int i = 0; i < 10; i++)
        {
            var id = Guid.NewGuid();
            var resourceURI = faker.Internet.Url();
            var resourceTypeId = faker.Random.ArrayElement(resources.ToArray());

            try
            {
                await using var command = new SqlCommand("INSERT INTO ResourcesTypes (Id, ResourceURI, ResourceTypeId) VALUES (@id, @url, @typeId)", connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@url", resourceURI);
                command.Parameters.AddWithValue("@typeId", resourceTypeId);
                await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Inserted resources.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    static async System.Threading.Tasks.Task InsertInterests(SqlConnection connection)
    {
        var faker = new Faker();
        for (int i = 0; i < 10; i++)
        {
            var id = Guid.NewGuid();
            var displayName = faker.Name.FullName();

            try
            {
                await using var command = new SqlCommand("INSERT INTO ResourcesTypes (Id, ResourceURI, ResourceTypeId, Created, Modified, ModifiedBy) VALUES (@id, @name, GETDATE(), GETDATE(), 'Admin')", connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@name", displayName);
                await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Inserted interests.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    static async System.Threading.Tasks.Task InterestsResources(SqlConnection connection)
    {
        var resourcesInsert = new List<Guid>();

        await using (var command = new SqlCommand("SELECT Id FROM Interests", connection))
        {
            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                resourcesInsert.Add(reader.GetGuid(0));
            }
        }

        var resourcesId = new List<Guid>();

        await using (var command = new SqlCommand("SELECT Id FROM Resources", connection))
        {
            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                resourcesId.Add(reader.GetGuid(0));
            }
        }

        var faker = new Faker();
        for (int i = 0; i < 10; i++)
        {
            var interestId = faker.Random.ArrayElement(resourcesInsert.ToArray());
            var resourceId = faker.Random.ArrayElement(resourcesId.ToArray());
            //TODO
            //PRIMARY KEY(InterestId, ResourceId) - how?
            try
            {
                await using var command = new SqlCommand("INSERT INTO ResourcesTypes (InterestId, ResourceId, ResourceTypeId) VALUES (@id, @resourceId)", connection);
                command.Parameters.AddWithValue("@id", interestId);
                command.Parameters.AddWithValue("@resourceId", resourceId);
                await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Inserted resources.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    static async System.Threading.Tasks.Task InterestsUsersResources(SqlConnection connection)
    {
        var users = new List<Guid>();

        await using (var command = new SqlCommand("SELECT Id FROM Users", connection))
        {
            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                users.Add(reader.GetGuid(0));
            }
        }

        var resourcesId = new List<Guid>();

        await using (var command = new SqlCommand("SELECT Id FROM Resources", connection))
        {
            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                resourcesId.Add(reader.GetGuid(0));
            }
        }

        var faker = new Faker();
        for (int i = 0; i < 10; i++)
        {
            var userId = faker.Random.ArrayElement(users.ToArray());
            var resourceId = faker.Random.ArrayElement(resourcesId.ToArray());
            //TODO
            //PRIMARY KEY (UserId, ResourceId), - how?
            try
            {
                await using var command = new SqlCommand("INSERT INTO ResourcesTypes (InterestId, ResourceId, ResourceTypeId) VALUES (@id, @resourceId)", connection);
                command.Parameters.AddWithValue("@id", userId);
                command.Parameters.AddWithValue("@resourceId", resourceId);
                await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Inserted users resources.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    static async System.Threading.Tasks.Task InsertGenderResources(SqlConnection connection)
    {
        var genders = new List<Guid>();

        await using (var command = new SqlCommand("SELECT Id FROM Genders", connection))
        {
            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                genders.Add(reader.GetGuid(0));
            }
        }

        var resourcesId = new List<Guid>();

        await using (var command = new SqlCommand("SELECT Id FROM Resources", connection))
        {
            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                resourcesId.Add(reader.GetGuid(0));
            }
        }

        var faker = new Faker();
        for (int i = 0; i < 10; i++)
        {
            var genderId = faker.Random.ArrayElement(genders.ToArray());
            var resourceId = faker.Random.ArrayElement(resourcesId.ToArray());
           
            try
            {
                await using var command = new SqlCommand("INSERT INTO ResourcesTypes (GenderId, ResourceId, ResourceTypeId) VALUES (@id, @resourceId)", connection);
                command.Parameters.AddWithValue("@id", genderId);
                command.Parameters.AddWithValue("@resourceId", resourceId);
                await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Inserted users resources.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    static async System.Threading.Tasks.Task InsertUserPreferences(SqlConnection connection)
    {
        var users = new List<Guid>();

        await using (var command = new SqlCommand("SELECT Id FROM Users", connection))
        {
            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                users.Add(reader.GetGuid(0));
            }
        }

        var gendersId = new List<Guid>();

        await using (var command = new SqlCommand("SELECT Id FROM Genders", connection))
        {
            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                gendersId.Add(reader.GetGuid(0));
            }
        }

        var faker = new Faker();
        for (int i = 0; i < 10; i++)
        {
            var userId = faker.Random.ArrayElement(users.ToArray());
            var genderId = faker.Random.ArrayElement(gendersId.ToArray());

            try
            {
                await using var command = new SqlCommand("INSERT INTO ResourcesTypes (UserId, GenderId, ResourceTypeId) VALUES (@id, @genderId)", connection);
                command.Parameters.AddWithValue("@id", userId);
                command.Parameters.AddWithValue("@genderId", genderId);
                await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Inserted users resources.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    static async System.Threading.Tasks.Task InsertUsersInterests(SqlConnection connection)
    {
        var users = new List<Guid>();

        await using (var command = new SqlCommand("SELECT Id FROM Users", connection))
        {
            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                users.Add(reader.GetGuid(0));
            }
        }

        var interestsId = new List<Guid>();

        await using (var command = new SqlCommand("SELECT Id FROM Interests", connection))
        {
            await using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                interestsId.Add(reader.GetGuid(0));
            }
        }

        var faker = new Faker();
        for (int i = 0; i < 10; i++)
        {
            var userId = faker.Random.ArrayElement(users.ToArray());
            var interestId = faker.Random.ArrayElement(interestsId.ToArray());

            try
            {
                await using var command = new SqlCommand("INSERT INTO ResourcesTypes (GenderId, ResourceId, ResourceTypeId) VALUES (@id, @resourceId)", connection);
                command.Parameters.AddWithValue("@id", userId);
                command.Parameters.AddWithValue("@resourceId", interestId);
                await command.ExecuteNonQueryAsync();
                Console.WriteLine($"Inserted users resources.");
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