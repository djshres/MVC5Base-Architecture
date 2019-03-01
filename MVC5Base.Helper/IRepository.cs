using MVC5Base.Entities;

namespace MVC5Base.Helper
{
    public interface IRepository<T> : IReadOnlyRepository<T> where T : EntityBase
    {
        T Add(T item, bool saveChanges = true);
        T Update(T item, int id, bool saveChanges = true);
        void Remove(T item, bool saveChanges = true);
        void RemoveById(int id, bool saveChanges = true);
    }
}
