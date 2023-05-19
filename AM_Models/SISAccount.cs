namespace AM_Models
{
    public class SISAccount
    {
        public string SISAccountNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public SISType Type { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
