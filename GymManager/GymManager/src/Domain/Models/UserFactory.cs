namespace GymManager.Domain.Models
{
    public static class UserFactory
    {
        public static GymUser FromCsvLine(string line)
        {
            var parts = line.Split(',');

            int id = int.Parse(parts[0].Trim());
            string password = parts[1].Trim();
            string role = parts[2].Trim();

            return role.ToLower() switch
            {
                "admin" => new AdminUser(id, password),
                "owner" => new OwnerUser(id, password),
                _ => new EmployeeUser(id, password)
            };
        }
    }
}