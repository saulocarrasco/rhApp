namespace RhApp.Model
{
    public enum UserRole
    {
        Empleyee = 1,
        Candidate = 2,
        Rh = 3
    }
    public class UserCredential : IBaseInterface
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public UserRole UserRole { get; set; }
        public ObjectStatus Status { get; set; }
    }
}