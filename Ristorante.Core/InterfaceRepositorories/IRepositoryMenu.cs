using Ristorante.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.Core.InterfaceRepositorories
{
    public interface IRepositoryMenu:IRepository<Menu>
    {
        public Menu GetMenuById(int id);
    }
}
