using System.ComponentModel.DataAnnotations;

namespace EventEase.Models;

public class Registration
{
    public int Id { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Please select an event.")]
    public int EventId { get; set; }

    [Required]
    [StringLength(60, MinimumLength = 2)]
    public string FullName { get; set; } = "";

    [Required]
    [EmailAddress]
    public string Email { get; set; } = "";

    [Phone]
    public string? Phone { get; set; }

    public DateTime RegisteredAt { get; set; } = DateTime.Now;
}
