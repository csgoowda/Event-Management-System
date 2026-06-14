using System;
using System.Collections.Generic;

namespace EventManagementSystem
{
    /// <summary>
    /// Static class representing our in-memory database.
    /// Demonstrates Collections, Generics, and static constructors.
    /// </summary>
    public static class Database
    {
        // Lists representing tables
        public static List<User> Users { get; set; }
        public static List<Event> Events { get; set; }
        public static List<Participant> Participants { get; set; }
        public static List<Registration> Registrations { get; set; }

        // Current session details
        public static string CurrentUsername { get; set; }
        public static string CurrentRole { get; set; }

        // Static constructor to initialize properties
        static Database()
        {
            Users = new List<User>();
            Events = new List<Event>();
            Participants = new List<Participant>();
            Registrations = new List<Registration>();
            CurrentUsername = "";
            CurrentRole = "";
        }

        /// <summary>
        /// Demonstrates Generics: A generic method to filter any list based on a predicate.
        /// </summary>
        public static List<T> FindItems<T>(List<T> source, Predicate<T> match)
        {
            List<T> results = new List<T>();
            foreach (var item in source)
            {
                if (match(item))
                {
                    results.Add(item);
                }
            }
            return results;
        }

        /// <summary>
        /// Populates the lists with initial sample data for demo purposes.
        /// </summary>
        public static void InitializeSampleData()
        {
            // Clear existing data (if any)
            Users.Clear();
            Events.Clear();
            Participants.Clear();
            Registrations.Clear();

            // 1. Add Default Admin (specified in requirements)
            // And a few sample users
            Users.Add(new User("admin", "admin123")); // Admin login
            Users.Add(new User("rahul", "rahul123")); // Sample user
            Users.Add(new User("priya", "priya123")); // Sample user
            Users.Add(new User("amit", "amit123"));   // Sample user

            // 2. Add Sample Events
            Events.Add(new Event(101, "National Tech Symposium", new DateTime(2026, 09, 15), "Main Seminar Hall"));
            Events.Add(new Event(102, "CodeCraft Hackathon", new DateTime(2026, 10, 22), "Computer Lab 3"));
            Events.Add(new Event(103, "Web Development Workshop", new DateTime(2026, 11, 05), "CSE Seminar Hall"));
            Events.Add(new Event(104, "AI & Machine Learning Seminar", new DateTime(2026, 12, 12), "Auditorium 2"));

            // 3. Add Sample Participants (Participant inherits from Person)
            Participants.Add(new Participant(1, "Rahul Sharma", "9876543210"));
            Participants.Add(new Participant(2, "Priya Patel", "8765432109"));
            Participants.Add(new Participant(3, "Amit Verma", "7654321098"));
            Participants.Add(new Participant(4, "Karan Singh", "6543210987"));

            // 4. Add Sample Registrations
            Registrations.Add(new Registration(1, "rahul", "National Tech Symposium", "Approved"));
            Registrations.Add(new Registration(2, "rahul", "CodeCraft Hackathon", "Pending"));
            Registrations.Add(new Registration(3, "priya", "Web Development Workshop", "Approved"));
            Registrations.Add(new Registration(4, "amit", "AI & Machine Learning Seminar", "Rejected"));
        }
    }
}
