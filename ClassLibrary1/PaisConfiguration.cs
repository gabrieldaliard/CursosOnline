// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassLibrary1
{
    // Paises
    public class PaisConfiguration : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.ToTable("Paises", "dbo");
            builder.HasKey(x => x.IdPais).HasName("PK__Paises__FC850A7BF6A97F59").IsClustered();

            builder.Property(x => x.IdPais).HasColumnName(@"IdPais").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.Descripcion).HasColumnName(@"Descripcion").HasColumnType("nvarchar(50)").IsRequired(false).HasMaxLength(50);
        }
    }

}
// </auto-generated>