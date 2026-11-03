namespace EventEase.Models;

public class AttendanceRecord
{
    public int RegistrationId { get; set; }
    public int EventId { get; set; }
    public string AttendeeName { get; set; } = "";
    public string Email { get; set; } = "";
    public DateTime RegisteredAt { get; set; }
    public bool IsPresent { get; set; }
}
