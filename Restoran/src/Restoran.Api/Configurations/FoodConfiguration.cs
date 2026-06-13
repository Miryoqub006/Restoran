using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restoran.Api.Entities;

namespace RestaurantAPI.FluentApies
{
    public class FoodConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            // Primary Key
            builder.HasKey(f => f.Id);

            // Name maydoni majburiy va maksimal uzunligi 100
            builder.Property(f => f.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            // Description majburiy bo'lmasligi mumkin, lekin limit qo'yamiz
            builder.Property(f => f.Description)
                   .HasMaxLength(500);

            // Price maydonini decimal(18,2) ko'rinishida sozlash
            builder.Property(f => f.Price)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            // Food -> Category Relationship (Munosabat) sozlash
            builder.HasOne(f => f.Category)          // Har bir Food bitta Category'ga ega
                   .WithMany(c => c.Foods)             // Har bir Category'da ko'plab Food bo'lishi mumkin
                   .HasForeignKey(f => f.CategoryId)  // Tashqi kalit (Foreign Key) - CategoryId
                   .OnDelete(DeleteBehavior.Restrict); // Kategoriya o'chganda taomlar xavfsiz qolishi uchun (ixtiyoriy)
        }
    }
}