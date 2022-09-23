using SmashModels.Franchise;
using SmashModels.Franchisee;
using SmashServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Smash_Calc.Controllers
{
    public class FranchiseController : Controller
    {
        private readonly Guid userId;
        
        // GET: Franchise
        public ActionResult Index()
        {
            var service = new FranchiseServices(userId);
            var model = service.GetFranchises();

            return View(model);
        }

        //GET: Franchise
        //Franchise/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Franchise
        //Franchise/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddFranchise model)
        {
            if (ModelState.IsValid)
            {
                var service = CreateFranchiseService();
                if (service.CreateFranchise(model))
                {
                    TempData["SaveResult"] = "Your Franchise has been created.";
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError("", "Franchise could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreateFranchiseService();
            var model = service.GetFranchiseById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateFranchiseService();
            var detail = service.GetFranchiseById(id);
            var model = new EditFranchise
            {
                FranchiseName = detail.FranchiseName,
                State = detail.State,
                Zips = detail.Zips,
                YearlySmashes = detail.YearlySmashes,
                XferStation = detail.XferStation,
                DistanceBetweenClients = detail.DistanceBetweenClients,
                DistanceToHauler = detail.DistanceToHauler,
                DistanceToLandfill = detail.DistanceToLandfill,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditFranchise model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.FranchiseeId != id)
            {
                ModelState.AddModelError("", "Id Mistmatch.");
                return View(model);
            }

            var service = CreateFranchiseService();
            if (service.UpdateFranchise(model))
            {
                TempData["SaveResult"] = "Your Franchise was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Franchise could not be updated.");
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteFranchise(int id)
        {
            var service = CreateFranchiseService();
            service.DeleteFranchise(id);
            TempData["SaveResult"] = "Your Franchise was deleted.";

            return RedirectToAction("Index");
        }

        private FranchiseServices CreateFranchiseService()
        {
            var service = new FranchiseServices(userId);
            return service;
        }
    }
}