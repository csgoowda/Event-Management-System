namespace EventManagementSystem
{
    /// <summary>
    /// Base class representing a person.
    /// Demonstrates Inheritance, Constructors, and Polymorphism.
    /// </summary>
    public class Person
    {
        // Encapsulated property
        public string Name { get; set; }

        // Parameterized constructor
        public Person(string name)
        {
            Name = name;
        }

        // Virtual method to be overridden in child classes (Polymorphism)
        public virtual string DisplayInfo()
        {
            return "Name: " + Name;
        }
    }
}
