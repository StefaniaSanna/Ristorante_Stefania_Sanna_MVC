using Microsoft.EntityFrameworkCore;
using Ristorante.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ristorante.EF
{
    public class Context:DbContext
    {
        public DbSet<Utente> Utenti { get; set; }
        public DbSet<Piatto> Piatti { get; set; }
        public DbSet<Menu> MenuSet { get; set; }


        public Context()
        {
                
        }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RistoranteDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Utente>(new UtenteConfiguration());
            modelBuilder.ApplyConfiguration<Piatto>(new PiattoConfiguration());
            modelBuilder.ApplyConfiguration<Menu>(new MenuConfiguration());
        }

    }
}
