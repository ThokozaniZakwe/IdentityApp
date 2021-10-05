﻿using IdentityApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private ProductDbContext DbContext;
        public AdminController(ProductDbContext context)
        {
            DbContext = context;
        }
        public IActionResult Index()
        {
            return View(DbContext.Products);
        }

        [HttpGet]
        public IActionResult Create() => View("Edit", new Product());

        [HttpGet]
        public IActionResult Edit(long id)
        {
            Product p = DbContext.Find<Product>(id);
            if(p != null)
            {
                return View("Edit", p);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Save(Product p)
        {
            DbContext.Update(p);
            DbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {
            Product p = DbContext.Find<Product>(id);
            if(p != null)
            {
                DbContext.Remove(p);
                DbContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));

        }
    }
}
