using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMSInteraction.Domain;

namespace SMSInteraction.Repository.Configurations;

public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        builder.Property(a => a.Id).IsRequired().UseIdentityColumn();
        builder.Property(a => a.Code).IsRequired().HasMaxLength(100);
        builder.Property(a => a.Description).IsRequired().HasMaxLength(250);
        builder.Property(a => a.Priority).IsRequired();
        builder.Property(a => a.Enabled).IsRequired().HasDefaultValue(true);
        builder.Property(e => e.SmsInteractionId).IsRequired();
    }
}