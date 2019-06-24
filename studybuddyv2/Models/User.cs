using System;
namespace studybuddyv2.Models
{
    public class User
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }

        public User(string email, string token, string password)
        {
            this.Email = email;
            this.Password = password;
            this.Token = token;
        }

        public User(string email, string token)
        {
            this.Email = email;
            this.Token = token;
        }

        public User (string email)
        {
            this.Email = email;
        }
    }
}
