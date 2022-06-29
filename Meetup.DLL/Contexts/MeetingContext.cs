using Meetup.BLL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Meetup.DLL.Contexts;

public class MeetingContext : DbContext
{
    public MeetingContext(DbContextOptions<MeetingContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Meeting> Meetings { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Meeting>().HasKey(meeting => meeting.Id);

        base.OnModelCreating(modelBuilder);
    }
}
