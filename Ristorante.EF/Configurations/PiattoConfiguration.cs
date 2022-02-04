using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ristorante.Core.Entities;

namespace Ristorante.EF
{
    public class PiattoConfiguration : IEntityTypeConfiguration<Piatto>
    {
        public void Configure(EntityTypeBuilder<Piatto> builder)
        {
            builder.ToTable("Piatto");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).IsRequired();
            builder.Property(p => p.Descrizione).IsRequired();
            builder.Property(p => p.Tipologia).IsRequired();
            builder.Property(p => p.Prezzo).HasPrecision(6,2).IsRequired();
            

            //relazioni

            builder.HasOne(p=>p.Menu).WithMany(m=>m.piatti).HasForeignKey(p=>p.MenuId);

        }
    }
}