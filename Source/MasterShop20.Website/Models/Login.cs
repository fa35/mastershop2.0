namespace MasterShop20.Website.Models
{
    public class Login
    {
        public string MailAddress { get; set; }
        public string Password { get; set; }
    }

    public class Registration
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Street { get; set; }
        public string HouseNr { get; set; }
        public string PostalCode { get; set; }
        public string Place { get; set; }
        public string MailAddress { get; set; }
        public string Password { get; set; }
    }
}