using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMSInteraction.Domain;

namespace SMSInteraction.Repository.Configurations;

public class LotteryConfiguration : IEntityTypeConfiguration<Lottery>
{
    public void Configure(EntityTypeBuilder<Lottery> builder)
    {
        builder.Property(l => l.Id).ValueGeneratedNever();
        builder.Property(l => l.WinnerCount).IsRequired();
        builder.Property(l => l.CreationDateTimeUtc).IsRequired();
        builder.HasOne(l => l.SmsInteraction)
            .WithOne(s => s.Lottery)
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(l => l.Winners)
            .WithOne(ua=>ua.Lottery)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);
    }
}