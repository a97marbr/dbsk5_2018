using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dbsk5_2018.Models;

namespace dbsk5_2018.Controllers
{
    public class HomeController : Controller
    {
        private StudentsModel sm = new StudentsModel("wwwlab.iki.his.se-dbsk");

        public IActionResult Index()
        {
            ViewBag.AllStudentsTable = sm.GetAllStudents();
            return View();
        }

        public IActionResult DeleteStudent(int id)
        {
            sm.DeleteStudent(id);
            return RedirectToAction("Index");
        }

        //
        // GET: /Home/ResetDB/

        public IActionResult ResetDB()
        {
            sm.ResetDB();
            return RedirectToAction("Index");
        }
    }
}
