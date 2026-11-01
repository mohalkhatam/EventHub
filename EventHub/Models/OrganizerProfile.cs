namespace EventHub.Models;

public class OrganizerProfile
{
    public int OrganizerProfileId { get; set; }

    public int OrganizerId { get; set; }

    public string? Biography { get; set; }

    public string? WebsiteUrl { get; set; }

    public string? LogoUrl { get; set; }

    public Organizer Organizer { get; set; } = null!;
}
