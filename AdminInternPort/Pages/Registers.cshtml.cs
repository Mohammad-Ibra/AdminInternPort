using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AdminInternPort.AuthModel;
using AdminInternPort.Models;
using Microsoft.AspNetCore.Identity;

namespace AdminInternPort.Pages.Registers
{
    public class RegistersModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        [BindProperty]
        public AuthModel.Register RegisterModel { get; set; }

        public RegistersModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = RegisterModel.UserName,
                    Email = RegisterModel.UserName,
                };

                var result = await userManager.CreateAsync(user, RegisterModel.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToPage("/Programs/Index");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return Page();
        }
        public void OnGet()
        {
        }
    }
}
