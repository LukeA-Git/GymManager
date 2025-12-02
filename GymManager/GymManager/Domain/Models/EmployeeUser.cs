using GymManager.Domain.Models;

namespace GymManager.Domain.Models
{
    public class EmployeeUser : GymUser
    {
        public EmployeeUser()
        {
            Role = "Employee";

            // Employees can only send general requests
            CanAdjustPerm = false;
            CanReqAudit = false;
            CanRequest = true;
        }
    }
}