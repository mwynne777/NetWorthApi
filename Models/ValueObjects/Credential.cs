namespace NetWorthApi.Models.ValueObjects
{
    public class Credential
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Credential(string uName, string pWord)
        {
            //Some Error Checking
            this.Username = uName;
            this.Password = pWord;
        }
    }
}