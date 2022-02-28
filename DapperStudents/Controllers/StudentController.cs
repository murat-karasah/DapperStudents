using DapperStudents.Entities;
using DapperStudents.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperStudents.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository rep;
        public StudentController(IStudentRepository _rep)
        {
            rep = _rep;
        }
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Student model)
        {
            if (ModelState.IsValid)
            {
                rep.Add(model);
                return RedirectToAction("Index","Home");
            }
            return View(model);
        }
        public IActionResult Detay(int?id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = rep.Find(id.GetValueOrDefault());
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        public IActionResult Sil(int? id)
        {
            if (id != null)
            {
                rep.Remove(id.GetValueOrDefault());
            }
            return RedirectToAction("Index","Home");
        }


        public IActionResult Duzenle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = rep.Find(id.GetValueOrDefault());
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost]
        public IActionResult Duzenle(int? id,Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                rep.Update(student);
                return RedirectToAction("Index","Home");
            }
            return View(student);
        }

    }
}
