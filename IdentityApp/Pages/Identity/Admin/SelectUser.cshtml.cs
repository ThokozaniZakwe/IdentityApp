using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;

namespace IdentityApp.Pages.Identity.Admin
{
    public class SelectUserModel : AdminPageModel
    {
        public SelectUserModel(UserManager<IdentityUser> userMgr)
        {
            UserManager = userMgr;
        }
        public UserManager<IdentityUser> UserManager { get; set; }
        public IEnumerable<IdentityUser> Users { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Label { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Callback { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Filter { get; set; }
        public void OnGet()
        {
            Users = UserManager.Users.Where(u => Filter == null || u.Email.Contains(Filter)).OrderBy(u => u.Email).ToList();
        }

        public IActionResult OnPost() => RedirectToPage(new { Filter, Callback });
    }
}
