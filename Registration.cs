namespace EventManagementSystem
{
    /// <summary>
    /// Class representing a user's registration for an event.
    /// </summary>
    public class Registration
    {
        public int RegistrationId { get; set; }
        public string Username { get; set; }
        public string EventName { get; set; }
        public string Status { get; set; } // "Pending", "Approved", "Rejected"

        public Registration(int registrationId, string username, string eventName, string status)
        {
            RegistrationId = registrationId;
            Username = username;
            EventName = eventName;
            Status = status;
        }
    }
}
