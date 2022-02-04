﻿using Ristorante.Core.Entities;
using Ristorante.Core.InterfaceRepositorories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.EF.RepositoryEF
{
    public class RepositoryUtentiEF : IRepositoryUtenti
    {
        private readonly Context ctx;

        public RepositoryUtentiEF(Context context)
        {
            this.ctx = context;

        }
        public Utente Add(Utente item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Utente item)
        {
            throw new NotImplementedException();
        }

        public List<Utente> GetAll()
        {
            throw new NotImplementedException();
        }

        public Utente? GetByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return null;
            }
            return ctx.Utenti.FirstOrDefault(x => x.Username == username);
        }

        public Utente Update(Utente item)
        {
            throw new NotImplementedException();
        }
    }
}
