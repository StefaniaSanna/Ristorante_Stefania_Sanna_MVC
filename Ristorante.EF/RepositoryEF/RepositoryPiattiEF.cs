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
    public class RepositoryPiattiEF : IRepositoryPiatti
    {
        private readonly Context ctx;

        public RepositoryPiattiEF(Context context)
        {
            this.ctx = context;

        }
        public Piatto Add(Piatto item)
        {
            ctx.Piatti.Add(item);
            ctx.SaveChanges();
            return item;
        }

        public bool Delete(Piatto item)
        {
            ctx.Piatti.Remove(item);
            ctx.SaveChanges();
            return true;
        }

        public List<Piatto> GetAll()
        {
            return ctx.Piatti.Include(p=>p.Menu).ToList();  
        }

        public Piatto? GetPiattoById(int id)
        {
            return ctx.Piatti.Include(p => p.Menu).FirstOrDefault(p=>p.Id==id);
        }

        public Piatto Update(Piatto item)
        {
            ctx.Piatti.Update(item);
            ctx.SaveChanges();
            return item;
        }
    }

       
}
