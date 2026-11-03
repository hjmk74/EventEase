using System.ComponentModel.DataAnnotations;

namespace EventEase.Models;

public class Event
{
    public int Id { get; set; }

    [Required]
    [StringLength(80, MinimumLength = 3)]
    public string Title { get; set; } = "";

    [Required]
    [StringLength(500, MinimumLength = 10)]
    public string Description { get; set; } = "";

    [Required]
    public string Location { get; set; } = "";

    [Required]
    public DateTime Date { get; set; }

    [Range(1, 10000)]
    public int Capacity { get; set; }

    public string Category { get; set; } = "Community";
    public int RegisteredCount { get; set; }
}
