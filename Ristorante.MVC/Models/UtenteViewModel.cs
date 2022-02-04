using Ristorante.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Ristorante.MVC.Models
{
    public class UtenteViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        public Ruolo Role { get; set; }
        public string ReturnUrl { get; set; }
    }
}
