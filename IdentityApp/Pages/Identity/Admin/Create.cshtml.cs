using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using IdentityApp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityApp.Pages.Identity.Admin
{
    public class CreateModel : AdminPageModel
    {
        public CreateModel(UserManager<IdentityUser> userMgr, IdentityEmailService emailService)
        {
            UserManager = userMgr;
            EmailService = emailService;
        }
        public UserManager<IdentityUser> UserManager { get; set; }
        public IdentityEmailService EmailService { get; set; }

        [BindProperty(SupportsGet = true)]
        [EmailAddress]
        public string Email { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = Email,
                    Email = Email,
                    EmailConfirmed = true
                };

                IdentityResult result = await UserManager.CreateAsync(user);
                if (result.Process(ModelState))
                {
                    await EmailService.SendPasswordRecoveryEmail(user, "/Identity/User/AccountComplete");
                    TempData["message"] = "Account Created!";
                    return RedirectToPage();
                }
            }
            return Page();
        }
    }
}
