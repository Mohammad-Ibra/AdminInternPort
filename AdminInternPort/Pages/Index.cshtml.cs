using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminInternPort.AuthModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdminInternPort.Pages
{
    public class LogInModel : PageModel
    {
        [BindProperty]
        public LogIn Model { get; set; }
        private readonly SignInManager<IdentityUser> SignInManager;

        public LogInModel(SignInManager<IdentityUser> signInManager)
        {
            this.SignInManager = signInManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var identityResult = await SignInManager.PasswordSignInAsync(Model.Email, Model.Password, Model.RememberMe, false);
                if (identityResult.Succeeded)
                {
                    if (returnUrl == null || returnUrl == "/")
                    {
                        return RedirectToPage("Programs/Index");
                    }
                    else
                    {
                        return RedirectToPage(returnUrl);
                    }
                    
                }

                ModelState.AddModelError("", "Username or Password incorrect!");
            }
            return Page();
        }
    }
}
