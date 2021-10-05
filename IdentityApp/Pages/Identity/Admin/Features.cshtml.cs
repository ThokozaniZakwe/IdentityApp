using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;

namespace IdentityApp.Pages.Identity.Admin
{
    public class FeaturesModel : AdminPageModel
    {
        public FeaturesModel(UserManager<IdentityUser> userMgr)
        {
            UserManager = userMgr;
        }
        public UserManager<IdentityUser> UserManager { get; set; }
        public IEnumerable<(string, string)> Features { get; set; }
        public void OnGet()
        {
            Features = UserManager.GetType().GetProperties()
                        .Where(prop => prop.Name.StartsWith("Supports"))
                        .OrderBy(p => p.Name)
                        .Select(prop => (prop.Name, prop.GetValue(UserManager).ToString()));
        }
    }
}
