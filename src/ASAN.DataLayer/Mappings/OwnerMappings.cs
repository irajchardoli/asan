using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASAN.DataLayer.Mappings
{
    public class OwnerMappings
    {
        public OwnerMappings(EntityTypeBuilder<ASAN.Entities.Owner> entityBuilder)
        {
            entityBuilder.ToTable("Owners", "ASAN");

            entityBuilder.HasMany(c => c.Estate)
                .WithOne(c => c.Owner)
                .HasForeignKey(c => c.OwnerId);
        }
    }
}