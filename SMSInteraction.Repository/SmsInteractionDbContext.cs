using Microsoft.EntityFrameworkCore;
using SMSInteraction.Domain;
using SMSInteraction.Repository.Configurations;

namespace SMSInteraction.Repository;

public class SmsInteractionDbContext : DbContext
{
    public SmsInteractionDbContext()
    {
    }

    public SmsInteractionDbContext(DbContextOptions<SmsInteractionDbContext> options) : base(options)
    {
    }

    public DbSet<SmsInteraction> SmsInteractions { get; set; }
    public DbSet<Contest> Contests { get; set; }
    public DbSet<Survey> Surveys { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<UserAnswer> UserAnswers { get; set; }
    public DbSet<Lottary> Lottaries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new SmsInteractionConfiguration().Configure(modelBuilder.Entity<SmsInteraction>());
        new ContestConfiguration().Configure(modelBuilder.Entity<Contest>());
        new SurveyConfiguration().Configure(modelBuilder.Entity<Survey>());
        new AnswerConfiguration().Configure(modelBuilder.Entity<Answer>());
        new UserAnswerConfiguration().Configure(modelBuilder.Entity<UserAnswer>());
        new LottaryConfiguration().Configure(modelBuilder.Entity<Lottary>());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "server=.;Database=test; User Id=sa; Password=Test@123456789; Trusted_Connection=false; MultipleActiveResultSets=true;TrustServerCertificate=true");
    }
}