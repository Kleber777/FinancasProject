using Domain.Entities;
using Domain.Interfaces;

namespace Data.Repositories
{
    public class Repository : IRepository
    {
        public Repository()
        {

        }
        protected readonly FinancasDbContext _context;
        protected Repository(FinancasDbContext context)
        {
            _context = context;
        }

        #region inherit crud
        public void Create<T>(T obj) where T : Entity
        {
            throw new NotImplementedException();
        }
        public List<T> Read<T>() where T : Entity
        {
            return _context.Set<T>().ToList();
        }

        public T Update<T>(T obj) where T : Entity
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T obj) where T : Entity
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion


    }
}
