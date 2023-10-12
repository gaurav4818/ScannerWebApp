namespace ScannerWebApp.Models
{
    public class UserCredentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; } = false;
    }

}
