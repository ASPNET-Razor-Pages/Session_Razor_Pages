using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session_Razor_Pages.Models
{
    public class Employee
    {
      
        public string Name { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int Age { get; set; }

        public bool IsTemporary { get; set; }
    }
}
