using EventHub.Data.Configurations;
using EventHub.Models;
using Microsoft.EntityFrameworkCore;

namespace EventHub.Data;

public class EventHubContext : DbContext
{
    public EventHubContext(DbContextOptions<EventHubContext> options)
        : base(options)
    {
    }

    public DbSet<Organizer> Organizers => Set<Organizer>();

    public DbSet<OrganizerProfile> OrganizerProfiles => Set<OrganizerProfile>();

    public DbSet<Event> Events => Set<Event>();

    public DbSet<Attendee> Attendees => Set<Attendee>();

    public DbSet<Badge> Badges => Set<Badge>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OrganizerProfileConfiguration());

        modelBuilder.Entity<Event>(builder =>
        {
            builder.HasKey(eventEntity => eventEntity.EventId);

            builder.Property(eventEntity => eventEntity.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(eventEntity => eventEntity.Description)
                .IsRequired()
                .HasMaxLength(4000);

            builder.Property(eventEntity => eventEntity.StartDate)
                .IsRequired();

            builder.Property(eventEntity => eventEntity.EndDate);

            builder.Property(eventEntity => eventEntity.MaximumAttendees)
                .IsRequired();

            builder.HasOne(eventEntity => eventEntity.Organizer)
                .WithMany(organizer => organizer.Events)
                .HasForeignKey(eventEntity => eventEntity.OrganizerId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Badge>(builder =>
        {
            builder.HasKey(badge => badge.BadgeId);

            builder.Property(badge => badge.CredentialNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(badge => badge.CredentialNumber)
                .IsUnique();

            builder.Property(badge => badge.IssuedDate)
                .IsRequired();

            builder.Property(badge => badge.Tier)
                .IsRequired();

            builder.HasOne(badge => badge.Attendee)
                .WithOne(attendee => attendee.Badge)
                .HasForeignKey<Badge>(badge => badge.AttendeeId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        base.OnModelCreating(modelBuilder);
    }
}
