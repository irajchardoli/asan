using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASAN.DataLayer.Mappings
{
    public class EstateMappings
    {
        public EstateMappings(EntityTypeBuilder<ASAN.Entities.Estate> entityBuilder)
        {
            entityBuilder.ToTable("Estates", "ASAN");

            entityBuilder.HasAlternateKey(c => new { c.Number });

            entityBuilder.HasOne(c => c.Owner)
                .WithMany(c => c.Estate)
                .HasForeignKey(c => c.OwnerId);
        }
    }
}