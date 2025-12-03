namespace GymManager.Domain.Interfaces;

public interface IFileReaderAdapter<T>
{
    void ReadIntoRepository(IRepository<T> repository);
}