using System.Collections.Generic;
namespace DIO.Series.Interfaces
{
    public interface IRepository<T>
    {
        List<T> List();
        T ReturnById(int id);
        void Add(T entity);
        void Delete(int id);
        void Update(int id, T entity);
        int NextId();
    }
}