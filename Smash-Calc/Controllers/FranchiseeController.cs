using SmashModels.Franchisee;
using SmashServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages.Html;

namespace Smash_Calc.Controllers
{
    public class FranchiseeController : Controller
    {
        private readonly Guid userId;

        // GET: Franchisee
        public ActionResult Index()
        {
            var service = new FranchiseeServices(userId);
            var model = service.GetFranchisees();
            return View(model);
        }

        //GET: Franchisee
        //Franchisee/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Franchisee
        //Franchisee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddFranchisee model)
        {
            if (ModelState.IsValid)
            {
                var service = CreateFranchiseeService();
                if (service.CreateFranchisee(model))
                {
                    TempData["SaveResult"] = "Your Franchisee has been created.";
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError("", "Franchisee could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreateFranchiseeServices();
            var model = service.GetFranchiseeById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateFranchiseeService();
            var detail = service.GetFranchiseeById(id);
            var model = new FranchiseeEdit
            {
                OwnerFirst = detail.OwnerFirst,
                OwnerLast = detail.OwnerLast,
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FranchiseeEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.FranchiseeId != id)
            {
                ModelState.AddModelError("", "Id Mismatch.");
                return View(model);
            }

            var service = CreateFranchiseeService();
            if (service.UpdateFranchisee(model))
            {
                TempData["SaveResult"] = "Your Franchisee was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Franchisee could not be updated.");
            return View(model);
        }

}
    }
