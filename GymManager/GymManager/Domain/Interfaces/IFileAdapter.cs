namespace GymManager.Domain.Interfaces;

public interface IFileAdapter<T>
{
    void ReadIntoRepository(IRepository<T> repository);
    void WriteFromRepository(IRepository<T> repository);
}