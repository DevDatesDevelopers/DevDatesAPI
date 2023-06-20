using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDates.Model.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       // public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public string SexualInterest { get; set; }
        public List<string> Interests { get; set; }
    }
}
