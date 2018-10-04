namespace BikeStore.Data.Repository.Contracts
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IDbRepository<T>
    {
        void Add(T entity);

        IQueryable<T> All(Expression<Func<T, object>> propertyNavigationPath);

        IQueryable<T> All();

        T GetById<TIdType>(TIdType id);

        void Delete(T entity);

        void Save();
    }
}
