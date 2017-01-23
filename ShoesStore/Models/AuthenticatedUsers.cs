using System.Collections.Generic;

namespace ShoesStore.Models
{
    public static class AuthenticatedUsers
    {
        private static List<User> _users = new List<User>
        {
            new User("my_user", "my_password", null, new List<string> { "::1" } )
        };

        public static List<User> Users { get { return _users; } }
    }
}