using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;

namespace IdentityApp.Pages.Identity.Admin
{
    public class DashboardModel : AdminPageModel
    {
        public UserManager<IdentityUser> UserManager { get; set; }
        public DashboardModel(UserManager<IdentityUser> userMgr)
        {
            UserManager = userMgr;
        }
        public int UsersCount { get; set; } = 0;
        public int UsersUnconfirmed { get; set; } = 0;
        public int UsersLockedout { get; set; } = 0;
        public int UsersTwoFactor { get; set; } = 0;

        private readonly string[] emails =
        {
            "alice@example.com", "bob@example.com", "charlie@example.com", "qgobhoza@email.co.za"
        };

        public void OnGet()
        {
            UsersCount = UserManager.Users.Count();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            foreach(IdentityUser existingUser in UserManager.Users.ToList())
            {
                IdentityResult result = await UserManager.DeleteAsync(existingUser);
                result.Process(ModelState);
            }
            foreach(string email in emails)
            {
                IdentityUser userObject = new IdentityUser
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                };
                IdentityResult result = await UserManager.CreateAsync(userObject);
                if (result.Process(ModelState))
                {
                    result = await UserManager.AddPasswordAsync(userObject, "mysecret");
                    result.Process(ModelState);
                }
                result.Process(ModelState);
            }
            if (ModelState.IsValid)
            {
                return RedirectToPage();
            }
            return Page();
        }
    }
}
