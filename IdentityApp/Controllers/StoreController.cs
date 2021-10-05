using IdentityApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityApp.Controllers
{
    [Authorize]
    public class StoreController : Controller
    {
        private ProductDbContext DbContext;

        public StoreController(ProductDbContext context)
        {
            DbContext = context;
        }
        public IActionResult Index()
        {
            return View(DbContext.Products);
        }
    }
}
