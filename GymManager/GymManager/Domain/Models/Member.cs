using System;

namespace GymManager.Domain.Models
{
    public class Member
    {
        public int Id { get; set; }          // internal ID for repo
        public string Name { get; set; }
        public DateTime EnrollDate { get; set; }

        public Member(int id, string name, DateTime enrollDate)
        {
            Id = id;
            Name = name;
            EnrollDate = enrollDate;
        }
        
        public static Member FromCsvLine(string line)
        {
            var parts = line.Split(',');
            return new Member(
                int.Parse(parts[0].Trim()),
                parts[1].Trim(),
                DateTime.Parse(parts[2].Trim())
            );
        }
        
        public string ToCsvLine()
        {
            return $"{Id},{Name},{EnrollDate:yyyy-MM-dd}";
        }
        
        public override string ToString()
        {
            return $"Member ID: {Id}, Name: {Name}, Enrolled: {EnrollDate:yyyy-MM-dd}";
        }

        public void Pay()
        {
            // TODO: implement payment logic, for now, prints 'paid"
            Console.WriteLine($"[WIP] {Name} paid");
        }
    }
}
