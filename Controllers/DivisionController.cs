using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsOrganizer.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsOrganizer.Controllers
{
    public class DivisionController : Controller
    {
        // GET: /<controller>/
        private SportsOrganizerDbContext db = new SportsOrganizerDbContext();
        public IActionResult Index()
        {
            return View(db.Divisions.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisDivision = db.Divisions.FirstOrDefault(divisions => divisions.DivisionId == id);
            return View(thisDivision);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Division division)
        {
            db.Divisions.Add(division);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
