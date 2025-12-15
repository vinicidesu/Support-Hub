using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("Tickets");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(t => t.Description)
                .IsRequired();
            builder.Property(t => t.Status)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(t => t.CreatedAt)
                .IsRequired();
            builder.Property(t => t.UpdatedAt)
                .IsRequired();
        }
    }
}
