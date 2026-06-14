namespace EventManagementSystem
{
    /// <summary>
    /// Class representing an administrator, inheriting from User.
    /// Demonstrates class-based inheritance and specialized user levels.
    /// </summary>
    public class Admin : User
    {
        public Admin(string username, string password) : base(username, password)
        {
        }
    }
}
