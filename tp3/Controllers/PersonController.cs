using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System;
using tp3.Models;

namespace tp3.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult View(int id)
        {
            Debug.WriteLine("ID: " + id.ToString());
            Person? p = Personal_info.GetPerson(id);
            if (p != null)
            {
                ViewBag.person = p;
                return View();
            }
            ViewBag.error = "Not found";
            return View("ErrorAction");
        }

        public IActionResult All()
        {
            List<Person> res = Personal_info.GetAllPerson();

            return View(res);
        }

        public IActionResult Search()
        {
            return View();
        }
    }
}
