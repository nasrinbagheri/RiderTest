using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SMSInteraction.Domain;

namespace SMSInteraction.Repository.Configurations;

public class LottaryConfiguration : IEntityTypeConfiguration<Lottary>
{
    public void Configure(EntityTypeBuilder<Lottary> builder)
    {
        builder.Property(l => l.Id).UseIdentityColumn().IsRequired();
        builder.Property(l => l.WinnerCount).IsRequired();
        builder.Property(l => l.CreationDateTimeUtc).IsRequired();
        builder.HasOne(l => l.SmsInteraction).WithOne(s => s.Lottary);
        builder.HasMany(l => l.Winners).WithOne(ua=>ua.Lottary).IsRequired(false);
    }
}