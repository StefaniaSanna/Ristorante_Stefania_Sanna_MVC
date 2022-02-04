using Ristorante.Core.Entities;
using Ristorante.Core.InterfaceRepositorories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.Core.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {
        private readonly IRepositoryUtenti _utentiRepo;
        private readonly IRepositoryPiatti _piattiRepo;
        private readonly IRepositoryMenu _menuRepo;

        public MainBusinessLayer(IRepositoryUtenti utenti, IRepositoryMenu menu, IRepositoryPiatti piatti)
        {
            _utentiRepo = utenti;
            _piattiRepo = piatti;
            _menuRepo = menu;

        }

       

        public Esito AddPiatto(Piatto piatto)
        {
            Piatto piattoEsistente = _piattiRepo.GetPiattoById(piatto.Id);
            if (piattoEsistente == null)
            {
                _piattiRepo.Add(piatto);
                return new Esito { Messaggio = $"Piatto aggiunto correttamente", IsOk = true };
            }
            return new Esito { Messaggio = $"Impossibile aggiungere il piatto", IsOk = false };

        }

        public Esito AggiungiMenu(Menu menu)
        {
            Menu menuEsistente = _menuRepo.GetMenuById(menu.Id);
            if (menuEsistente == null)
            {
                _menuRepo.Add(menu);
                return new Esito { Messaggio = $"Menù aggiunto correttamente", IsOk = true };
            }
            return new Esito { Messaggio = $"Impossibile aggiungere il menù", IsOk = false };
        }

        public Esito EliminaPiatto(int id)
        {
            var piattoEsistente = _piattiRepo.GetPiattoById(id);
            if (piattoEsistente == null)
            {
                return new Esito { Messaggio = "Nessun piatto corrispondente all'id inserito", IsOk = false };
            }
            _piattiRepo.Delete(piattoEsistente);
            return new Esito { Messaggio = "Piatto eliminato correttamente", IsOk = true };
        }

        public Utente GetAccount(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return null;
            }
            return _utentiRepo.GetByUsername(username);
        }

        public List<Menu> GetAllMenu()
        {
            return _menuRepo.GetAll();
        }

        public List<Piatto> GetAllPiatti()
        {
            return _piattiRepo.GetAll();
        }

        public Esito TogliPiattoDalMenu(Piatto piatto)
        {
           
            var piattoTrovato = _piattiRepo.GetPiattoById(piatto.Id);
            if(piattoTrovato != null)
            {
                var menu = _menuRepo.GetAll().FirstOrDefault(m=>m.Id==piatto.MenuId);
                if(menu != null)
                {
                    menu.piatti.Remove(piattoTrovato);
                    piattoTrovato.MenuId = null;
                    return new Esito { Messaggio = "Piatto tolto dal menù correttamente", IsOk = true };
                }
                return new Esito { Messaggio = "Menù non trovato", IsOk = false };
                //compila ma non torna!
            }
            return new Esito { Messaggio = "Piatto non trovato", IsOk = false };
        }

        public Esito UpdatePiatto(int id, string nome, string descrizione, Tipologia tipologia, decimal prezzo)
        {
            var piatto = _piattiRepo.GetPiattoById(id);
            if (piatto == null)
            {
                return new Esito { Messaggio = "Id inesistente", IsOk = false };
            }
            piatto.Nome = nome;
            piatto.Descrizione = descrizione;
            piatto.Tipologia = tipologia;
            piatto.Prezzo = prezzo;

            _piattiRepo.Update(piatto);
            return new Esito { Messaggio = "Piatto aggiornato correttamente", IsOk = true };
        }
    }
}
