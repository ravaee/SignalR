using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SignalR.Context;

namespace SignalR.Pages
{
    public class RegisterModel : PageModel
    {

        public readonly AppDbContext _context;

        [BindProperty]
        public InputModel Input { get; set; }
        public string ReturnUrl { get; set; }

        public RegisterModel(AppDbContext context)
        {
            _context = context;
        }

        public class InputModel
        {
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Username")]
            public string Username { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            try
            {
                var user = await _context.Users.Where(a => a.Username == Input.Username)
                    .Where(a => a.Password == Input.Password)
                    .SingleOrDefaultAsync();

                if(user == null)
                {
                    return RedirectToPage("Error");
                }

                return RedirectToPage("Index");
            }
            catch (Exception e)
            {
                return RedirectToPage("Error");
            }
        }
    }
}
