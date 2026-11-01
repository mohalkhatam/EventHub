namespace EventHub.Models;

public class Badge
{
    public int BadgeId { get; set; }

    public int AttendeeId { get; set; }

    public string CredentialNumber { get; set; } = string.Empty;

    public DateTime IssuedDate { get; set; }

    public BadgeTier Tier { get; set; }

    public Attendee Attendee { get; set; } = null!;
}

public enum BadgeTier
{
    Standard,
    VIP
}
