﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Test.Models;
using Test.Services.Interfaces;
using Test.ViewModels;

namespace Test.Controllers
{
    public class OrderController : BaseController<Order, OrderViewModel>
    {
        private readonly IOrderService _orderService;
        public OrderController(
            IBaseService<Order, OrderViewModel> service,
            IOrderService orderService
            ) : base(service)
        {
            _orderService = orderService;
        }


        [HttpGet]
        public virtual async Task<ActionResult> GridByReferenceId(int id, int page = 0)
        {
            var model = await _orderService.GetOrdersByReferenceIdAsync(id, page);
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> CreateOrUpdateByReferenceId(int referenceId, int? id = null)
        {
            var model = await _orderService.CreateOrUpdateByReferenceId(referenceId, id);
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateOrUpdateByReferenceId(OrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await _service.CreateOrUpdate(model);
                return RedirectToAction("GridByReferenceId", new { id = model.ClientId });
            }
            catch (Exception e)
            {
                return View("ErrorModal", e.Message);
            }
        }

    }
}