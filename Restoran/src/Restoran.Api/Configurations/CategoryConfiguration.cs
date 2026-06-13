using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restoran.Api.Entities;

namespace RestaurantAPI.FluentApies
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Primary Key o'zi avtomatik Id deb tanilgan, lekin aniq ko'rsatish yaxshi praktika
            builder.HasKey(c => c.Id);

            // Name maydoni majburiy va maksimal uzunligi 50 (WI13 talabiga ham mos keladi)
            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(50);
        }
    }
}