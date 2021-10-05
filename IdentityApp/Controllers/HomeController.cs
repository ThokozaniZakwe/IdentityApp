using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApp.Controllers
{
    public class HomeController: Controller
    {
        private ProductDbContext DbContext;

        public HomeController(ProductDbContext context) => DbContext = context;

        public IActionResult Index() => View(DbContext.Products);
    }
}
