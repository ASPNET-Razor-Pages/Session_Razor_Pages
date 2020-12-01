using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Session_Razor_Pages.Models;

namespace Session_Razor_Pages
{
    public class Page2Model : PageModel
    {
        public Employee Employee { get; set; } = new Employee();
        public string CookieValue { get; set; }


        public void OnGet()
        {
            //using Cookies
            CookieValue = Request.Cookies["MyCookie"];

            //Using Session (option 1)
            if (HttpContext.Session.GetString("emp") != null)
            {
                Employee = JsonConvert.DeserializeObject<Employee>(HttpContext.Session.GetString("emp"));
            }   
            
            //Uisng Session (option 2)

            //if (HttpContext.Session.GetString("name") != null)
            //{
            //    Employee.Name = HttpContext.Session.GetString("name");
            //}

            //if (HttpContext.Session.GetString("age") != null)
            //{
            //    Employee.Age = (Int32)HttpContext.Session.GetInt32("age");
            //}

            //if (HttpContext.Session.GetString("status") != null)
            //{
            //    Employee.IsTemporary = BitConverter.ToBoolean(HttpContext.Session.Get("status"));
            //}


        }
    }
}