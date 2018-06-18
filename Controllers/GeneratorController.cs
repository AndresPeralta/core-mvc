using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using core_mvc.Models;
using System.IO;
using Newtonsoft.Json.Linq;

namespace core_mvc.Controllers
{
    public class GeneratorController : Controller
    {
        public IActionResult Index()
        {           
            StreamReader file = new StreamReader("./wwwroot/data/DATA.json");
            var jString = file.ReadToEnd();
            var jsonArray = JArray.Parse(jString);

           var Generator = new Generator{                           
                Name = "Mockaroo",
                Url= "https://mockaroo.com/",
                Users = new List<User>(), 
           };
           foreach (JObject item in jsonArray)
           {
               var User = new User{
                   FirstName =item.GetValue("FirstName").ToString(),
                   LastName = item.GetValue("LastName").ToString(),
                   Email = item.GetValue("email").ToString(),
                   Avatar = item.GetValue("picture").ToString(),
                   Gender = item.GetValue("gender").ToString(),                   
               };
               Generator.Users.Add(User);
           }
           return View(Generator);

        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
      
    }

}