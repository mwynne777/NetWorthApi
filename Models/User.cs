using System.Collections.Generic;
using NetWorthApi.Models.ValueObjects;

namespace NetWorthApi.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Credential Credentials { get; set; } //This will depend on sec. implementation
        public List<Asset> Assets { get; set; }
        public List<Liability> Liabilities { get; set; }
    }
}