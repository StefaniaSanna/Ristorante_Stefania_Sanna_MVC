using Ristorante.Core.Entities;

namespace Ristorante.MVC.Models
{
    public class PiattoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public Tipologia Tipologia { get; set; }
        public decimal Prezzo { get; set; }

        public int? MenuId { get; set; }
        public Menu? Menu { get; set; }
    }
}
