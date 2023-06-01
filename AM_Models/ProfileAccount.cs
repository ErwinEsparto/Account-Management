namespace AM_Models
{
    public class ProfileAccount
    {
        public SISAccount SISAccount { get; set; }
        public string Username { get; set; }
        public DateTime DateJoined { get; set; }
        public DateTime DateModified { get; set; }
        public string PhotoPath { get; set; }
    }
}