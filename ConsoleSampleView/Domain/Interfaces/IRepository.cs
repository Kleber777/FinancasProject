using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IRepository : IDisposable
    {
        void Create<T>(T obj) where T : Entity;
        List<T> Read<T>() where T : Entity;
        T Update<T>(T obj) where T : Entity;
        void Delete<T>(T obj) where T : Entity;
    }
}
