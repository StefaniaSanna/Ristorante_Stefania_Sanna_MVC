using Ristorante.Core.Entities;

namespace Ristorante.MVC.Models
{
    public class MenuViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Piatto> Piatti { get; set; } = new List<Piatto>();
    }
}
