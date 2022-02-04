using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ristorante.Core.BusinessLayer;
using Ristorante.Core.Entities;
using Ristorante.MVC.Helper;
using Ristorante.MVC.Models;

namespace Ristorante.MVC.Controllers
{
    public class PiattiController : Controller
    {
        private readonly IBusinessLayer BL;

        public PiattiController(IBusinessLayer bl)
        {
            this.BL = bl;
        }
        public IActionResult Index()
        {
            var piatti = BL.GetAllPiatti();
            List<PiattoViewModel> piattiViewModel = new List<PiattoViewModel>();
            foreach (var piatto in piatti)
            {
                piattiViewModel.Add(piatto.ToPiattoViewModel());
            }
            return View(piattiViewModel);
        }

        [Authorize(Policy = "Adm")]
        public IActionResult Create()
        {
            LoadViewBag();
            return View();
        }

        [Authorize(Policy = "Adm")]
        [HttpPost]
        public IActionResult Create(PiattoViewModel piattoViewModel)
        {
            if (ModelState.IsValid)
            {
                Piatto piatto = piattoViewModel.ToPiatto();
                Esito esito = BL.AddPiatto(piatto);
                if (esito.IsOk)
                {

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.MessaggioErrore = esito.Messaggio;
                    return View("ErroriDiBusiness");

                }
                return View(piattoViewModel);
            }
            return View(piattoViewModel);
        }

        [Authorize(Policy = "Adm")]
        public IActionResult Edit(int id)
        {
            var piatto = BL.GetAllPiatti().FirstOrDefault(p => p.Id == id);
            var piattoViewModel = piatto.ToPiattoViewModel();
            return View(piattoViewModel);
        }

        [Authorize(Policy = "Adm")]
        [HttpPost]
        public IActionResult Edit(PiattoViewModel piattoViewModel)
        {
            if (ModelState.IsValid)
            {
                var piatto = piattoViewModel.ToPiatto();
                Esito esito = BL.UpdatePiatto(piatto.Id, piatto.Nome, piatto.Descrizione, piatto.Tipologia, piatto.Prezzo);
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
            return View(piattoViewModel);

        }

        [Authorize(Policy = "Adm")]
        public IActionResult Delete(int id)
        {
            var piatto = BL.GetAllPiatti().FirstOrDefault(p => p.Id == id);
            var piattoViewModel = piatto.ToPiattoViewModel();
            return View(piattoViewModel);

        }

        [Authorize(Policy = "Adm")]
        [HttpPost]
        public IActionResult Delete(PiattoViewModel piattoViewModel)
        {

            var piatto = piattoViewModel.ToPiatto();
            var esito = BL.EliminaPiatto(piatto.Id);
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




        private void LoadViewBag()
        {

            ViewBag.Tipologia = new SelectList(new[]
            {
                new{Value="1", Text="Secondo"},
                new{Value="2", Text="Contorno"},
                new{Value="3", Text="Dolce"}
            }.OrderBy(x => x.Value), "Value", "Text");
        }


        [Authorize(Policy = "Adm")]
        public IActionResult Decouple(int id)
        {
            var piatto = BL.GetAllPiatti().FirstOrDefault(p => p.Id == id);
            var piattoViewModel = piatto.ToPiattoViewModel();
            return View(piattoViewModel);
        }

        [Authorize(Policy = "Adm")]
        [HttpPost]
        public IActionResult Decouple(PiattoViewModel piattoViewModel)
        {

            var piatto = piattoViewModel.ToPiatto();
            Esito esito = BL.TogliPiattoDalMenu(piatto);
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
    }
}
