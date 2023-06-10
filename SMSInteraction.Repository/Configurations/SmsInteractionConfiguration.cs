using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMSInteraction.Domain;
using SMSInteraction.Enums;

namespace SMSInteraction.Repository.Configurations;

public class SmsInteractionConfiguration : IEntityTypeConfiguration<SmsInteraction>
{
    public void Configure(EntityTypeBuilder<SmsInteraction> builder)
    {
        builder.Property(b => b.Id).IsRequired().ValueGeneratedNever();
        builder.Property(b => b.Enabled).IsRequired();
        builder.Property(b => b.CreationUtcDateTime).IsRequired();
        builder.Property(b => b.Title).IsRequired().HasMaxLength(250);
        builder.Property(b => b.InteractionType).IsRequired().HasDefaultValue(InteractionType.Contest);

        builder.HasDiscriminator(b => b.InteractionType)
            .HasValue<Contest>(InteractionType.Contest)
            .HasValue<Survey>(InteractionType.Survey)
            .IsComplete(false);

        builder.HasMany(b => b.Answers)
            .WithOne(b => b.SmsInteraction)
            .HasForeignKey(a => a.SmsInteractionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(b => b.Lottery)
            .WithOne(l => l.SmsInteraction)
            .HasForeignKey<Lottery>(t => t.SmsInteractionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}