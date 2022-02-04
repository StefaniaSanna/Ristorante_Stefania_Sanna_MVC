using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ristorante.Core.Entities;

namespace Ristorante.EF
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menu");
            builder.HasKey(m => m.Id);
            builder.Property(m=>m.Nome).IsRequired();

            //relazioni

            builder.HasMany(m=>m.piatti).WithOne(p=>p.Menu).HasForeignKey(p=>p.MenuId);
        }
    }
}