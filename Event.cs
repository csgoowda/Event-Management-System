using System;

namespace EventManagementSystem
{
    /// <summary>
    /// Class representing an Event.
    /// </summary>
    public class Event
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string Venue { get; set; }

        public Event(int eventId, string eventName, DateTime eventDate, string venue)
        {
            EventId = eventId;
            EventName = eventName;
            EventDate = eventDate;
            Venue = venue;
        }
    }
}
