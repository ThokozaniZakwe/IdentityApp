using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityApp.Pages
{
    public class LandingModel : PageModel
    {
        public ProductDbContext DbContext { get; set; }

        public LandingModel(ProductDbContext context)
        {
            DbContext = context;
        }
    }
}
