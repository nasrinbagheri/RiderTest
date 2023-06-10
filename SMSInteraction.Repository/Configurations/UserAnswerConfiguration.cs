using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMSInteraction.Domain;

namespace SMSInteraction.Repository.Configurations;

public class UserAnswerConfiguration : IEntityTypeConfiguration<UserAnswer>
{
    public void Configure(EntityTypeBuilder<UserAnswer> builder)
    {
        builder.Property(ua => ua.Id).IsRequired().ValueGeneratedNever();
        ;
        builder.Property(ua => ua.MobileNo).IsRequired().HasMaxLength(20);
        builder.Property(ua => ua.CreationUtcDatetime).IsRequired();
        builder.Property(ua => ua.AnswerId).IsRequired();
        builder.Property(ua => ua.SmsInteractionId).IsRequired();
        builder.HasIndex(ua => new { ua.MobileNo, ua.SmsInteractionId }).IsUnique(true);
        builder.HasOne(ua => ua.Answer)
            .WithMany(a => a.UserAnswers)
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(ua => ua.SmsInteraction)
            .WithMany(a => a.UserAnswers)
            .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(ua => ua.Lottery)
            .WithMany(l => l.Winners)
            .OnDelete(DeleteBehavior.NoAction);
    }
}