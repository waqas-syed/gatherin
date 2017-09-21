using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gatherin.Presentation.ViewModels;
using Gatherin.Services;

namespace Gatherin.Presentation.Controllers
{
    /// <summary>
    /// Handles the operations for gathering
    /// </summary>
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

        /// <summary>
        /// GET: Gatherings
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            
            return View();
        }

        /// <summary>
        /// GET: Gatherings/Details/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            return View();
        }

        /// <summary>
        /// GET: Gatherings/Create
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// POST: Gatherings/Create
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
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

        /// <summary>
        /// GET: Gatherings/Edit/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            return View();
        }

        /// <summary>
        /// POST: Gatherings/Edit/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
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

        /// <summary>
        /// GET: Gatherings/Delete/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            return View();
        }

        /// <summary>
        /// POST: Gatherings/Delete/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
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
