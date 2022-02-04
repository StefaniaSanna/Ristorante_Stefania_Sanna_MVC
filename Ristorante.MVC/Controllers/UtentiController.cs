using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Ristorante.Core.BusinessLayer;
using Ristorante.MVC.Models;
using System.Security.Claims;

namespace Ristorante.MVC.Controllers
{
    public class UtentiController : Controller
    {
        private readonly IBusinessLayer BL;
        public UtentiController(IBusinessLayer bl)
        {
            BL = bl;
        }
        public IActionResult Login(string returnUrl = "/") 
        {

            return View(new UtenteViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(UtenteViewModel utenteViewModel)
        {
            if (utenteViewModel == null) 
            {
                return View();               
            }

            var utente = BL.GetAccount(utenteViewModel.Username); 

            if (utente != null && ModelState.IsValid)
            {
                
                if (utente.Password == utenteViewModel.Password)
                {                   
                    var claim = new List<Claim>{
                        new Claim(ClaimTypes.Name, utente.Username),
                        new Claim(ClaimTypes.Role, utente.Ruolo.ToString())
                    };
                    
                    var properties = new AuthenticationProperties
                    {
                        RedirectUri = utenteViewModel.ReturnUrl,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1),
                    };

                    var clainIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync( 
                          CookieAuthenticationDefaults.AuthenticationScheme,
                          new ClaimsPrincipal(clainIdentity),
                          properties);
                    return Redirect("/");
                }

                else
                {
                    ModelState.AddModelError(nameof(utenteViewModel.Password), "Password errata");
                    return View(utenteViewModel);
                }
            }
            else
            {
                return View(utenteViewModel);
            }
            return View();

        }

        
        public IActionResult Forbidden() => View(); 


        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync(); 
            return Redirect("/");

        }
    }
}
