using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using latihan1.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace latihan1.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IConfiguration configuration; 
        public LoginModel(IConfiguration configuration)
        {this.configuration = configuration;
        }
        [BindProperty]
        public string UserEmail { get; set; }
        [BindProperty]

        public string Password { get; set;}
        public string Message { get; set; }

        public async Task<IActionResult> OnPostAsync(){
            var user = configuration.GetSection("User").Get<User>();

            if (UserEmail == user.Email)
{             if(Password==user.Password)                   
                    
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, UserEmail),
                        new Claim(ClaimTypes.Role,"admin")
                    };
                    var claimsIdentity = new ClaimsIdentity(claims,
                        CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity));
                    return RedirectToPage("Boostrap1");
                }
                 Message = "Password Salah";
        return Page();
        
        }
        Message = "User Tidak Terdaftar";
        return Page();
        
     }
     public void OnGet()
     {
         
     }
      }
}
