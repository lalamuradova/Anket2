using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anket2.Helpers
{
   public class Questions
    {
        public Questions() { }
        public Questions(string name, string surname, string birthday, string email, string phone)
        {
            Name = name;
            Surname = surname;
            Birthday = birthday;
            Email = email;
            Phone = phone;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birthday { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            return $@"{Name} {Surname}
Birthday: {Birthday}
Email: {Email}
Phone: {Phone}";
        }

    }

    
}
