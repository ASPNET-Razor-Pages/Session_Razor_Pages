using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Session_Razor_Pages.Models;

namespace Session_Razor_Pages.Pages
{
    [BindProperties]
    public class Page1Model : PageModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        MockData.MockEmployees employeeService;
        public Page1Model(MockData.MockEmployees empService)

        {
            employeeService = empService;
        }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Employee loggedEmployee = employeeService.GetEmployee(Username, Password);
            if (loggedEmployee != null)
            {
                //using Cookies
                Response.Cookies.Append("MyCookie", loggedEmployee.Name);
                //or adding options
                var cookieOptions = new CookieOptions
                {
                    Expires = DateTime.Now.AddSeconds(30)
                };              
                Response.Cookies.Append("MyCookie", loggedEmployee.Name , cookieOptions);
               
                // Using Sessions (option 1)
                HttpContext.Session.SetString("emp", JsonConvert.SerializeObject(loggedEmployee));

                // or Using Session (Option 2)
                //HttpContext.Session.SetString("name", loggedEmployee.Name);
                //HttpContext.Session.SetInt32("age", loggedEmployee.Age);
                //HttpContext.Session.Set("status", BitConverter.GetBytes(loggedEmployee.IsTemporary));
            }
            return RedirectToPage("Page2");
        }

    }
}
