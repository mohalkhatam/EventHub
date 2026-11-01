using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventHub.Models;

[Table("EventOrganizers")]
public class Organizer
{
    [Key]
    public int OrganizerId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(150)]
    public string? CompanyName { get; set; }

    public bool IsVerified { get; set; }

    public OrganizerProfile? Profile { get; set; }

    public ICollection<Event> Events { get; } = new List<Event>();
}
