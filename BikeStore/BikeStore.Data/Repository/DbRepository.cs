namespace BikeStore.Data.Repository
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using BikeStore.Data.Repository.Contracts;
    using Microsoft.EntityFrameworkCore;

    public class DbRepository<T> : IDbRepository<T> where T : class
    {
        private readonly DbContext dbContext;

        public DbRepository(DbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentException("An instance of DbContext is required to use this repository.", nameof(dbContext));

        }

        public void Add(T entity) => this.dbContext.Set<T>().Add(entity);

        public IQueryable<T> All(Expression<Func<T, object>> propertyNavigationPath) => this.dbContext.Set<T>().Include(propertyNavigationPath);

        public IQueryable<T> All() => this.dbContext.Set<T>();

        public void Delete(T entity) => this.dbContext.Set<T>().Remove(entity);

        public T GetById<TIdType>(TIdType id) => this.dbContext.Set<T>().Find(id);

        public void Save() => this.dbContext.SaveChanges();
    }
}
