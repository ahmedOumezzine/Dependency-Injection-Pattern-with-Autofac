using DI_Pattern_Autofac.Core.Interfaces;
using DI_Pattern_Autofac.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DI_Pattern_Autofac.Web.Controllers
{
    public class TeamController : Controller
    {
        private IRepository repo;
        public TeamController(IRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var teams = repo.GetAll<Team>().ToList();
 
            return View(teams);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpGet]
        public ActionResult InsertTeam()
        {
            return View();
        }

        public ActionResult TeamDetails(int id)
        {
            ViewBag.TeamId = id;
            return View();
        }

        [HttpPost]
        public ActionResult InsertTeam(Team team)
        {
            if (ModelState.IsValid)
            {
                repo.Insert<Team>(team);
                repo.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}