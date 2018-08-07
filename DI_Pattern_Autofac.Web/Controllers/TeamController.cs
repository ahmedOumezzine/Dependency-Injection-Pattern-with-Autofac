
using GRLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DI_Pattern_Autofac.Web.Controllers
{
    public class TeamController : Controller
    {
        private readonly IUnitOfWork repo;

        public TeamController(IUnitOfWork repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var teams = repo.Repository<Team2>().GetAll().ToList();
            repo.GetNonGenericRepository<Team2, TeamRepository>().GetAll();

            return View(teams);
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
        public ActionResult InsertTeam(Team2 team)
        {
            if (ModelState.IsValid)
            {
                repo.Repository<Team2>().Add(team);
                repo.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}