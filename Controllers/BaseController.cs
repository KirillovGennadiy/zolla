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
    public class BaseController<TEntity, TViewModel> : Controller
        where TEntity: class, IEntity
        where TViewModel: class, IEntity, new()
    {
        protected readonly IBaseService<TEntity, TViewModel> _service;
        public BaseController(IBaseService<TEntity, TViewModel> service)
        {
            _service = service;
        }

        [HttpGet]
        public virtual async Task<ActionResult> Index()
        {
            var model = await _service.GetGridAsync(0);
            return View(model);
        }
        
        [HttpGet]
        public virtual async Task<ActionResult> Grid(int page = 0)
        {
            var model = await _service.GetGridAsync(page);
            return View(model);
        }

        [HttpGet]
        public virtual async Task<ActionResult> CreateOrUpdate(int? id = null)
        {
            var model = await _service.CreateOrUpdate(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> CreateOrUpdate(TViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await _service.CreateOrUpdate(model);
                return RedirectToAction("Grid");
            }
            catch(Exception e)
            {
                return View("ErrorModal", e.Message);
            }
        }

        [HttpPost]
        public virtual async Task<ActionResult> Delete(int id)
        {
            try
            {
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