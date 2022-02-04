using Ristorante.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.Core.InterfaceRepositorories
{
    public interface IRepositoryUtenti:IRepository<Utente>
    {
        public Utente GetByUsername(string username);   

    }
}
