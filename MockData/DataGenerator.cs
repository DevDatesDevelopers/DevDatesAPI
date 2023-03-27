using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MockData.Person;

namespace MockData
{
    public class DataGenerator
    {
        
        public static Faker<Person> GetPersonGenerator()
        {
            return new Faker<Person>()
                .RuleFor(e => e.FirstName, f => f.Name.FirstName())
                .RuleFor(e => e.LastName, f => f.Name.LastName())
                .RuleFor(e => e.DateFBirth, f => f.Person.DateOfBirth)
                .RuleFor(e => e.GenderSelection, f => f.Person.Gender.ToString())
                .RuleFor(e => e.Bio, f => f.Lorem.Paragraph(1))
                .RuleFor(e => e.Email, (f, e) => f.Internet.Email(e.FirstName, e.LastName))
                /*.RuleFor(e => e.Created, f => f.PickRandom)*/
                .RuleFor(e => e.Modified, f => f.Date.Recent())
                .RuleFor(e => e.ModifiedBy, (f, e) => f.Name.FirstName());

        }
        public static readonly List<Person> Persons = new List<Person>();
        public const int NumOfPeople = 7;
        public static void ResultData()
        {
            var generated = GetPersonGenerator();
            var generatedU = generated.Generate(NumOfPeople);
            Persons.AddRange(generatedU);
        }
    }
}
