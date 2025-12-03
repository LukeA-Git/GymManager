using System.Collections.Generic;

namespace GymManager.Domain.Interfaces;

/* Every object within the project will have some sort of internal Id
 * for the purposes of query logic.
 * 
 */

public interface IRepository<T>
{
    void Add(T item);
    List<T> GetAll();
    void Clear();
    void Remove(T item);
    void Update(T item);
    public T? FindById(int id);
}