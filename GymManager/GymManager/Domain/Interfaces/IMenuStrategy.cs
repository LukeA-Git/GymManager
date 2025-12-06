namespace GymManager.Domain.Interfaces
{
    public interface IMenuStrategy
    {
        void ShowMenu();
        bool HandleChoice(string choice);
    }
}