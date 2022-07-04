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
            new UserStatistics {Id = Guid.Parse("792EEB2A-2E20-4C6F-A88C-B36546AA4185"), CountSignIn = 12},
            new UserStatistics {Id = Guid.Parse("67D1EC5D-34A0-4913-9771-98F9401C68B1"), CountSignIn = 5},
            new UserStatistics {Id = Guid.Parse("43B201EF-A43D-4733-80B3-3BF19EBDC637"), CountSignIn = 103},
            new UserStatistics {Id = Guid.Parse("85008C65-7D37-4F87-ACBE-E34E4AE71561"), CountSignIn = 7});
        base.OnModelCreating(modelBuilder);
    }
}