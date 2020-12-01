using Session_Razor_Pages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session_Razor_Pages.MockData
{
    public class MockEmployees
    {
       
            private readonly List<Employee> Employees;
            public MockEmployees()
            {
                Employees = new List<Employee>();
                Employees.Add( new Employee() {  Username = "moal", Name = "Mohammed", Password = "moal", Age=45, IsTemporary=true  });
                Employees.Add( new Employee() {  Username = "sali", Name = "Salida", Password = "sali" , Age=21, IsTemporary=false});
            }
           
            public Employee GetEmployee(string un, string pw)
            {
                if (un != null && pw != null)
                {
                    foreach (var s in Employees)
                    {
                        if (s.Username == un && s.Password == pw)
                        {
                         return s;
                        }
                    }
                }
                return null;
            }
        }
    }

