namespace GymManager.Domain.Models
{
    public class EmployeeUser : GymUser
    {
        public override string Role => "Employee";

        public EmployeeUser(int id, string password)
        {
            UserID = id;
            UserPassword = password;
        }
    }
}