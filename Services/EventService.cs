using EventEase.Models;

namespace EventEase.Services;

public class EventService
{
    private List<Event> events = new List<Event>
    {
        new Event
        {
            Id = 1,
            Title = "Design and Innovation Meetup",
            Description = "An evening of creative ideas, talks and networking.",
            Location = "Baghdad Innovation Hub",
            Date = DateTime.Today.AddDays(7).AddHours(17),
            Capacity = 80,
            Category = "Technology"
        },
        new Event
        {
            Id = 2,
            Title = "Community Startup Forum",
            Description = "Meet founders and learn about building new products.",
            Location = "Al-Mansour Conference Center",
            Date = DateTime.Today.AddDays(12).AddHours(10),
            Capacity = 120,
            Category = "Business"
        },
        new Event
        {
            Id = 3,
            Title = "Frontend Workshop",
            Description = "A practical workshop about responsive web interfaces.",
            Location = "University of Baghdad",
            Date = DateTime.Today.AddDays(18).AddHours(14),
            Capacity = 35,
            Category = "Education"
        }
    };

    private List<Registration> registrations = new List<Registration>();
    private int nextRegistrationId = 1;

    public List<Event> GetAll()
    {
        return events.OrderBy(e => e.Date).ToList();
    }

    public Event? GetById(int id)
    {
        return events.FirstOrDefault(e => e.Id == id);
    }

    public List<Registration> GetRegistrations(int eventId)
    {
        return registrations.Where(r => r.EventId == eventId).ToList();
    }

    public bool IsEmailRegistered(int eventId, string email)
    {
        return registrations.Any(r =>
            r.EventId == eventId &&
            r.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
    }

    public (bool Success, string Message, Registration? Registration) Register(Registration registration)
    {
        Event? selectedEvent = GetById(registration.EventId);

        if (selectedEvent == null)
        {
            return (false, "Please select an event.", null);
        }

        if (IsEmailRegistered(registration.EventId, registration.Email))
        {
            return (false, "This email is already registered for this event.", null);
        }

        if (selectedEvent.RegisteredCount >= selectedEvent.Capacity)
        {
            return (false, "This event is full.", null);
        }

        registration.Id = nextRegistrationId;
        nextRegistrationId++;
        registration.RegisteredAt = DateTime.Now;

        registrations.Add(registration);
        selectedEvent.RegisteredCount++;

        return (true, "Registration completed successfully!", registration);
    }
}
