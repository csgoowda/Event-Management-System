namespace EventManagementSystem
{
    /// <summary>
    /// Child class representing a participant, inheriting from Person.
    /// Demonstrates Inheritance, Constructor Chaining, and Polymorphism (overriding).
    /// </summary>
    public class Participant : Person
    {
        public int ParticipantId { get; set; }
        public string PhoneNumber { get; set; }

        // Constructor chaining using the base keyword
        public Participant(int participantId, string name, string phoneNumber) : base(name)
        {
            ParticipantId = participantId;
            PhoneNumber = phoneNumber;
        }

        // Overridden method displaying detailed participant info (Polymorphism)
        public override string DisplayInfo()
        {
            return string.Format("Participant ID: {0} | Name: {1} | Phone: {2}", ParticipantId, Name, PhoneNumber);
        }
    }
}
