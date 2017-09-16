using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gatherin.Presentation.ViewModels;
using Gatherin.Services;

namespace Gatherin.Presentation.Controllers
{
    public class GatheringsController : Controller
    {
        private IGatheringService _gatheringService;

        /// <summary>
        /// Initialize the Gatherings controller
        /// </summary>
        /// <param name="gatheringService"></param>
        public GatheringsController(IGatheringService gatheringService)
        {
            _gatheringService = gatheringService;
        }

        // GET: Gatherings
        public ActionResult Index()
        {
            
            return View();
        }

        // GET: Gatherings/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Gatherings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gatherings/Create
        [HttpPost]
        public ActionResult Create(CreateGatheringFormModel collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Gatherings/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Gatherings/Edit/5
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

        // GET: Gatherings/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Gatherings/Delete/5
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
