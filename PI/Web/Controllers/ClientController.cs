using Domain.Entities;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models.ViewModels;

namespace Web.Controllers
{
    public class ClientController : Controller
    {

       ClientServices As = new ClientServices();

        // GET: Client
        public ActionResult Index()
        {
            List<ClientViewModel> list = new List<ClientViewModel>();
            var a = As.GetAll();
            foreach (var i in a)
            {
                ClientViewModel Avm = new ClientViewModel();
                Avm.ClientID = i.Clientid;
                Avm.NomComplet = new NomCompletViewModel() { nom = i.NomComplet.Nom, prenom = i.NomComplet.Prenom };
                list.Add(Avm);
            }
            return View(list);
        }

        [HttpPost]
        public ActionResult Index(string recherche)
        {
            List<ClientViewModel> list = new List<ClientViewModel>();
            var a = As.GetAll();
            foreach (var i in a)
            {
                ClientViewModel Avm = new ClientViewModel();
                Avm.ClientID = i.Clientid;
                Avm.NomComplet = new NomCompletViewModel() { nom = i.NomComplet.Nom, prenom = i.NomComplet.Prenom };
                list.Add(Avm);
            }

            if (!String.IsNullOrEmpty(recherche))
            {
                list = list.Where(m => m.NomComplet.nom.Contains(recherche)).ToList();
            }

            return View(list);


        }
        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            var e = As.GetById(id);
            ClientViewModel a = new ClientViewModel();
            a.ClientID = e.Clientid;
            a.Email = e.Email;
            a.NumeroTel = e.PhoneNumber;
            a.NomComplet = new NomCompletViewModel() { nom = e.NomComplet.Nom, prenom = e.NomComplet.Prenom };
            return View(a);
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(ClientViewModel Avm)
        {
            Client a = new Client();
            a.Clientid = Avm.ClientID;
            a.Email = Avm.Email;
            a.PhoneNumber = Avm.NumeroTel;
            a.NomComplet = new NomComplet() { Nom = Avm.NomComplet.nom, Prenom = Avm.NomComplet.prenom };
            As.Add(a);
            As.Commit();
            return RedirectToAction("Index");

        }
        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Client/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
