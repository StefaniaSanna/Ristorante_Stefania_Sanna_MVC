using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ristorante.Core.Entities;

namespace Ristorante.EF
{
    public class UtenteConfiguration : IEntityTypeConfiguration<Utente>
    {
        public void Configure(EntityTypeBuilder<Utente> builder)
        {
            builder.ToTable("Utente");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(u => u.Username).IsRequired();
            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.Ruolo).IsRequired();
        }
    }
}