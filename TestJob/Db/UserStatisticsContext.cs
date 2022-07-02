using Microsoft.EntityFrameworkCore;
using TestJob.Entyties;

namespace TestJob.Contexts;

public sealed class UserStatisticsContext : DbContext
{
    public DbSet<RequestStatus> RequestStatuses { get; set; }
    public DbSet<UserStatistics> UserStatistics { get; set; }

    public UserStatisticsContext(DbContextOptions<UserStatisticsContext> options)
        : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RequestStatus>()
            .HasKey(rs => rs.Id);
        modelBuilder.Entity<RequestStatus>()
            .HasOne(rs => rs.UserStatistics)
            .WithMany(us => us.RequestStatuses)
            .HasForeignKey(key => key.UserStatisticsId);

        modelBuilder.Entity<UserStatistics>()
            .HasKey(us => us.Id);
        modelBuilder.Entity<UserStatistics>().HasData(
            new UserStatistics {Id = Guid.NewGuid(), CountSignIn = 12},
            new UserStatistics {Id = Guid.NewGuid(), CountSignIn = 5},
            new UserStatistics {Id = Guid.NewGuid(), CountSignIn = 103},
            new UserStatistics {Id = Guid.NewGuid(), CountSignIn = 7});
        base.OnModelCreating(modelBuilder);
    }
}