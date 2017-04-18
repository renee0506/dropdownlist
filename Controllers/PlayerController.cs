using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SportsOrganizer.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsOrganizer.Controllers
{
    public class PlayerController : Controller
    {
        private SportsOrganizerDbContext db = new SportsOrganizerDbContext();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(db.Players.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisPlayer = db.Players.Include(players => players.Team).FirstOrDefault(players => players.PlayerId == id);
            return View(thisPlayer);
        }

        public IActionResult Create()
        {
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Player player)
        {
            db.Players.Add(player);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisPlayer = db.Players.FirstOrDefault(players => players.PlayerId == id);
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "Name");
            return View(thisPlayer);
        }

        [HttpPost]
        public IActionResult Edit(Player player)
        {
            db.Entry(player).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisPlayer = db.Players.FirstOrDefault(players => players.PlayerId == id);
            return View(thisPlayer);
        }

        [HttpPost]
        public IActionResult Delete(Player player)
        {
            db.Players.Remove(player);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
