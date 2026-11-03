using EventEase.Models;

namespace EventEase.Services;

public class AttendanceService
{
    private EventService eventService;
    private Dictionary<int, bool> attendance = new Dictionary<int, bool>();

    public AttendanceService(EventService eventService)
    {
        this.eventService = eventService;
    }

    public List<AttendanceRecord> GetForEvent(int eventId)
    {
        List<AttendanceRecord> records = new List<AttendanceRecord>();

        foreach (Registration registration in eventService.GetRegistrations(eventId))
        {
            bool present = false;
            attendance.TryGetValue(registration.Id, out present);

            records.Add(new AttendanceRecord
            {
                RegistrationId = registration.Id,
                EventId = registration.EventId,
                AttendeeName = registration.FullName,
                Email = registration.Email,
                RegisteredAt = registration.RegisteredAt,
                IsPresent = present
            });
        }

        return records;
    }

    public void SetAttendance(int registrationId, bool isPresent)
    {
        attendance[registrationId] = isPresent;
    }
}
