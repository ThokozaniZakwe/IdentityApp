using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityApp.Pages.Identity
{
    public class PasswordChangeBindingTarget
    {
        [Required]
        public string Current { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required]
        [Compare(nameof(NewPassword))]
        public string ConfirmPassword { get; set; }
    }
    public class UserPasswordChangeModel : UserPageModel
    {
        public UserPasswordChangeModel(UserManager<IdentityUser> userMgr)
        {
            UserManager = userMgr;
        }
        public UserManager<IdentityUser> UserManager { get; set; }
        public async Task<IActionResult> OnPostAsync(PasswordChangeBindingTarget data)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await UserManager.GetUserAsync(User);
                IdentityResult result = await UserManager.ChangePasswordAsync(user, data.Current, data.NewPassword);
                if (result.Process(ModelState))
                {
                    TempData["message"] = "Password Successfully Changed!";
                    return RedirectToPage();
                }
            }
            return Page();
        }
    }
}
