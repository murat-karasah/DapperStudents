using DapperStudents.Entities;
using DapperStudents.Models;
using DapperStudents.Repository;
using DapperStudents.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DapperStudents.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentRepository rep;
        public HomeController(IStudentRepository _rep)
        {
            rep = _rep;
        }

      
        public IActionResult Index(string name = null, int? age1 = null, int? age2 = null)
        {
           
            var student = rep.GetFilter(name, age1, age2);
          
            return View(student);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
