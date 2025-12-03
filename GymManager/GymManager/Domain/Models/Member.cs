namespace GymManager.Domain.Models
{
    public class Member
    {
        public int Id { get; set; }          // internal ID for repo
        public string Name { get; set; } = string.Empty;  
        public DateTime EnrollDate { get; set; }

        public Member(int id, string name, DateTime enrollDate)
        {
            Id = id;
            Name = name;
            EnrollDate = enrollDate;
        }
        
        public static Member FromCsv(string line)
        {
            var parts = line.Split(',');
            return new Member(
                int.Parse(parts[0].Trim()),
                parts[1].Trim(),
                DateTime.Parse(parts[2].Trim())
            );
        }

        public void Pay()
        {
            // TODO: implement payment logic, for now, will use desktop notification
        }
    }
}
