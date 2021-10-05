using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityApp.Pages.Identity
{
    public class IndexModel : UserPageModel
    {
        public IndexModel(UserManager<IdentityUser> userMgr)
        {
            UserManager = userMgr;
        }
        public UserManager<IdentityUser> UserManager { get; set; }
        public string Email { get; set; } = "No Email";
        public string Phone { get; set; } = "No Phone";
        
        public async Task OnGetAsync()
        {
            IdentityUser CurrentUser = await UserManager.GetUserAsync(User);
            Email = CurrentUser?.Email ?? "(No Email Address)";
            Phone = CurrentUser?.PhoneNumber ?? "(No Phone Number)";
        }
    }
}
