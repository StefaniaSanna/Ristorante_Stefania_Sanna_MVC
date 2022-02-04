using Microsoft.EntityFrameworkCore;
using Ristorante.Core.Entities;
using Ristorante.Core.InterfaceRepositorories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.EF.RepositoryEF
{
    public class RepositoryMenuEF : IRepositoryMenu
    {
        private readonly Context ctx;

        public RepositoryMenuEF(Context context)
        {
            this.ctx = context;

        }

        public Menu Add(Menu item)
        {
            ctx.MenuSet.Add(item);
            ctx.SaveChanges();
            return item;
        }

        public bool Delete(Menu item)
        {
            throw new NotImplementedException();
        }

        public List<Menu> GetAll()
        {
            return ctx.MenuSet.Include(m => m.piatti).ToList();
        }

        public Menu? GetMenuById(int id)
        {
            return ctx.MenuSet.Include(m => m.piatti).FirstOrDefault(m=>m.Id==id);
        }

        public Menu Update(Menu item)
        {
            throw new NotImplementedException();
        }
    }
}
