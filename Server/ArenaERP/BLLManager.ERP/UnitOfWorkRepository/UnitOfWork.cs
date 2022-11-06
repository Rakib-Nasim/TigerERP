
using Microsoft.EntityFrameworkCore;

namespace ModelClass.ERP.UnitOfWorkRepository
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        protected readonly DbContext _dbContext;

        public UnitOfWork(DbContext dbContext) => _dbContext = dbContext;

        #region Asynchronous
        public async virtual ValueTask DisposeAsync() => _dbContext?.DisposeAsync();
        public async virtual Task<bool> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }


        public async Task BeginTransactionAsync() => await _dbContext.Database.BeginTransactionAsync();

        public async Task CommitTransactionAsync() => await _dbContext.Database.CommitTransactionAsync();

        public async Task RollbackTransactionAsync() => await _dbContext.Database.RollbackTransactionAsync();
        #endregion

        #region Non-Asynchronous
        public virtual void Dispose() => _dbContext?.Dispose();
        public virtual void Save() => _dbContext?.SaveChanges();

       
        #endregion
    }
}
