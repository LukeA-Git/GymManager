namespace GymManager.Domain.Models
{
    public class Member
    {
        public int Id { get; set; }          // internal ID for repo
        public string Name { get; set; } = string.Empty;  
        public int MemberID { get; set; }
        public DateTime EnrollDate { get; set; }

        public void Pay()
        {
            // TODO: implement payment logic
        }
    }
}
