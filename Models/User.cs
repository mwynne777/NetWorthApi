using System.Collections.Generic;
using NetWorthApi.Models.ValueObjects;

namespace NetWorthApi.Models
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; } //This will depend on sec. implementation
        public string Password { get; set; }
    }
}