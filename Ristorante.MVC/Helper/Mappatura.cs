using Ristorante.Core.Entities;
using Ristorante.MVC.Models;

namespace Ristorante.MVC.Helper
{
    public static class Mappatura
    {
        public static PiattoViewModel ToPiattoViewModel(this Piatto piatto)
        {
            return new PiattoViewModel
            {
                Id = piatto.Id,
                Nome = piatto.Nome,
                Descrizione = piatto.Descrizione,
                Tipologia = piatto.Tipologia,
                Prezzo = piatto.Prezzo,
                MenuId = piatto.MenuId,
                Menu = piatto.Menu
            };
        }

        public static Piatto ToPiatto(this PiattoViewModel piattoViewModel)
        {
            return new Piatto
            {
                Id = piattoViewModel.Id,
                Nome = piattoViewModel.Nome,
                Descrizione = piattoViewModel.Descrizione,
                Tipologia = piattoViewModel.Tipologia,
                Prezzo = piattoViewModel.Prezzo,
                Menu = piattoViewModel.Menu,
                MenuId = piattoViewModel.MenuId
            };
        }

        public static MenuViewModel ToMenuViewModel(this Menu menu)
        {
            return new MenuViewModel
            {
                Id = menu.Id,
                Nome = menu.Nome,
                Piatti = menu.piatti
            };
        }

        public static Menu ToMenu(this MenuViewModel menuViewModel)
        {
            return new Menu
            {
                Id = menuViewModel.Id,
                Nome = menuViewModel.Nome,
                piatti = menuViewModel.Piatti
            };
        }

    }
}
