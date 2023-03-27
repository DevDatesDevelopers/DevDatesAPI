using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MockData
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateFBirth { get; set; }
        public string GenderSelection { get; set; }
        public string Bio { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string ModifiedBy { get; set; }

        
        public override string ToString()
        {
            return System.Text.Json.JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}
