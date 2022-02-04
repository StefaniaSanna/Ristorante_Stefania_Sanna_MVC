using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Ristorante.Core.BusinessLayer;
using Ristorante.Core.Entities;
using Ristorante.MVC.Helper;
using Ristorante.MVC.Models;

namespace Ristorante.MVC.Controllers
{
    public class MenuController : Controller
    {
        private readonly IBusinessLayer BL;

        public MenuController(IBusinessLayer bl)
        {
            this.BL = bl;
        }
        public IActionResult Index()
        {
            List<Menu> menu = BL.GetAllMenu();
            List<MenuViewModel> menuViewModel = new List<MenuViewModel>();
            foreach (var m in menu)
            {
                menuViewModel.Add(m.ToMenuViewModel());
            }
            return View(menuViewModel);
        }

        public IActionResult Details(int id)//passo l'id del menu e voglio tutti i piatti con quel menù
        {
            var piatti = BL.GetAllPiatti().Where(p=>p.MenuId == id);
            List<PiattoViewModel> piattiViewModel = new List<PiattoViewModel>();

            foreach (var p in piatti)
            {
                piattiViewModel.Add(p.ToPiattoViewModel());
            }
            return View(piattiViewModel);
        }


        [Authorize(Policy = "Adm")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Policy = "Adm")]
        [HttpPost]
        public IActionResult Create(MenuViewModel menuViewModel)
        {
            if (ModelState.IsValid)
            {
                Menu menu = menuViewModel.ToMenu();
                Esito esito = BL.AggiungiMenu(menu);
                if (esito.IsOk == true)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.MessaggioErrore = esito.Messaggio;
                    return View("ErroriDiBusiness");
                }
            }
            return View(menuViewModel);
        }

        
    }
}
