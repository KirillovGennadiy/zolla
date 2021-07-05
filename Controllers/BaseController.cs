using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Test.DataAccess.Base;
using Test.Services.Interfaces;

namespace Test.Controllers
{
    // Base crud controller
    public class BaseController<TEntity, TViewModel> : Controller
        where TEntity: class, IEntity
        where TViewModel: class, IEntity, new()
    {
        // Basic Crud service that implements basic operations 
        protected readonly IBaseService<TEntity, TViewModel> _service;
        public BaseController(IBaseService<TEntity, TViewModel> service)
        {
            _service = service;
        }

        [HttpGet]
        public virtual async Task<ActionResult> Index()
        {
            // Get TEntity collection 
            var model = await _service.GetGridAsync(0);
            return View(model);
        }
        
        [HttpGet]
        public virtual async Task<ActionResult> Grid(int page = 0)
        {
            // Get TEntity collection related on page number
            var model = await _service.GetGridAsync(page);
            return View(model);
        }

        [HttpGet]
        public virtual async Task<ActionResult> CreateOrUpdate(int? id = null)
        {
            // get Create or update view
            var model = await _service.CreateOrUpdate(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<JsonResult> CreateOrUpdate(TViewModel model)
        {
            // if exist validation errors
            if (!ModelState.IsValid)
            {
                // Map errors to dictionary
                Dictionary<string, string> errors = new Dictionary<string, string>();
                foreach (var state in ModelState.Where(s => s.Value.Errors.Any()))
                {
                    errors.Add(state.Key, string.Join("<br> ", state.Value.Errors.Select(e => !string.IsNullOrEmpty(e.ErrorMessage) ? e.ErrorMessage : e.Exception.Message).ToArray()));
                }

                // return JSON
                return new JsonResult { 
                    Data = new { success = false, errors }, 
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet 
                };
            }

            try
            {
                await _service.CreateOrUpdate(model);
                return new JsonResult { Data = new { success = true }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            catch(Exception e)
            {
                // return JSON
                return new JsonResult { 
                    Data = new { success = false, errors = new Dictionary<string, string> { ["Global"] = e.Message } },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet 
                };
            }
        }

        [HttpPost]
        public virtual async Task<ActionResult> Delete(int id)
        {
            try
            {
                // Delete TEntity and redirect to Grid
                await _service.Delete(id);
                return RedirectToAction("Grid");
            }
            catch (Exception e)
            {
                return View("ErrorModal", e.Message);
            }
        }
    }
}