using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminInternPort.Pages
{
    [Authorize]
    public class LogOutModel : PageModel
    {
        private readonly SignInManager<IdentityUser> signInManager;

        public LogOutModel(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await signInManager.SignOutAsync();
            return RedirectToPage("Index");
        }

        public IActionResult OnPostDontLogoutAsync()
        {
            return Page();
        }
    }
}
