namespace EventManagementSystem
{
    /// <summary>
    /// Class representing a user account in the system.
    /// </summary>
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
