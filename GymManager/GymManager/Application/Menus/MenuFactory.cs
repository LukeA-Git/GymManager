using GymManager.Domain.Interfaces;

namespace GymManager.Application.Menus
{
    public static class MenuFactory
    {
        public static IMenuStrategy GetMenu(IUser user, GymApp app)
        {
            return user.Role.ToLower() switch
            {
                "admin" => new AdminMenuStrategy(app),
                "owner" => new OwnerMenuStrategy(app),
                _ => new EmployeeMenuStrategy(app)
            };
        }
    }
}