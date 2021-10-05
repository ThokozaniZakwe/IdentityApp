using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityApp.Pages
{
    [Authorize(Roles = "Admin")]
    public class AdminModel : PageModel
    {
        public ProductDbContext DbContext { get; set; }
        public AdminModel(ProductDbContext context)
        {
            DbContext = context;
        }

        public IActionResult OnPost(long id)
        {
            Product p = DbContext.Find<Product>(id);
            if(p != null)
            {
                DbContext.Remove(p);
                DbContext.SaveChanges();
            }
            return Page();
        }
    }
}
