using Domain.Entities;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class ProjectController : Controller
    {
        ProjectServices ps = new ProjectServices();
        // GET: Project
        public ActionResult Index()
        {

            var getAll = ps.GetAll();

            return View(getAll);
        }

        // GET: Project/Details/5
        public ActionResult Details(int id)
        {
            var pip = ps.GetById(id);
            ProjectViewModel PVM = new ProjectViewModel();
            PVM.ProjectName = pip.ProjectName;
            PVM.Start_Date = pip.Start_Date;
            PVM.End_Date = pip.End_Date;
            PVM.Duration = pip.Duration;
            PVM.Description = pip.Description;

            




            return View(PVM);
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        [HttpPost]
        public ActionResult Create(ProjectViewModel PVM)
        {
             Project P = new Project();
                P.ProjectId = PVM.ProjectId;
                P.ProjectName = PVM.ProjectName;
                P.Description = PVM.Description;
                P.Duration = PVM.Duration;
                P.Start_Date = PVM.Start_Date;
                P.End_Date = PVM.End_Date;
                ps.Add(P);
                ps.Commit();
            return RedirectToAction("index");
           
        }

        public ActionResult CreateTest(ProjectViewModel PVM)
        {
           
            return View();

        }
        // GET: Project/Edit/5
        public ActionResult Edit(int id)
        {
            var pip = ps.GetById(id);
            ProjectViewModel PVM = new ProjectViewModel();
            PVM.ProjectName = pip.ProjectName;
            PVM.Start_Date = pip.Start_Date;
            PVM.End_Date = pip.End_Date;
            PVM.Duration = pip.Duration;

            PVM.Description = pip.Description;
            return View (PVM);

        }

        // POST: Project/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProjectViewModel PVM)
        {
            Project P = ps.GetById(id);

           
           
            P.ProjectName = PVM.ProjectName;
            P.Start_Date = PVM.Start_Date;
            P.End_Date = PVM.End_Date;
            P.Duration = PVM.Duration;
            P.Description = PVM.Description;

            ps.Update(P);
            ps.Commit();
            return RedirectToAction("Index");
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Project/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ProjectViewModel PVM)
        {
            Project p = ps.GetById(id);

            PVM.ProjectId = p.ProjectId;
            PVM.ProjectName = p.ProjectName;
            PVM.Start_Date = p.Start_Date;
            PVM.End_Date = p.End_Date;
            PVM.Duration = p.Duration;
            PVM.Description = p.Description;
            ps.Delete(p);
            ps.Commit();
            


            return RedirectToAction("Index");

        }
    }
}
