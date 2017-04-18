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
    public class TeamController : Controller
    {
        private SportsOrganizerDbContext db = new SportsOrganizerDbContext();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(db.Teams.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisTeam = db.Teams.Include(Teams => Teams.Players).FirstOrDefault(teams => teams.TeamId == id);
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "Name");
            return View(thisTeam);
        }

        [HttpPost] 
        public IActionResult Details(Player player)
        {
            var newTeamId = this.Request.Form["TeamId"];
            player.TeamId = Int32.Parse(newTeamId);
            db.Entry(player).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            ViewBag.DivisionId = new SelectList(db.Divisions, "DivisionId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Team team)
        {
            db.Teams.Add(team);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisTeam = db.Teams.FirstOrDefault(teams => teams.TeamId == id);
            return View(thisTeam);
        }

        [HttpPost]
        public IActionResult Delete(Team team)
        {
            db.Teams.Remove(team);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisTeam = db.Teams.FirstOrDefault(teams => teams.TeamId == id);
            ViewBag.DivisionId = new SelectList(db.Divisions, "DivisionId", "Name");
            return View(thisTeam);
        }

        [HttpPost]
        public IActionResult Edit(Team team)
        {
            db.Entry(team).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
