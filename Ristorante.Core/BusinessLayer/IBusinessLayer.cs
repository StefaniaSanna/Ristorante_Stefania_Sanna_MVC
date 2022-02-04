using Ristorante.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.Core.BusinessLayer
{
    public interface IBusinessLayer
    {
        public List<Piatto> GetAllPiatti();
        public List<Menu> GetAllMenu();
        Utente GetAccount(string name);
        Esito AddPiatto(Piatto piatto);
        Esito UpdatePiatto(int id, string nome, string descrizione, Tipologia tipologia, decimal prezzo);
        Esito EliminaPiatto(int id);
        Esito AggiungiMenu(Menu menu);
        Esito TogliPiattoDalMenu(Piatto piatto);
    }
}
