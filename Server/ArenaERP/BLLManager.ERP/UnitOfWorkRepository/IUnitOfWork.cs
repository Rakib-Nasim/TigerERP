namespace ModelClass.ERP.UnitOfWorkRepository
{
    public interface IUnitOfWork : IAsyncDisposable, IDisposable
    {
        Task <bool> SaveAsync();
        void Save();
        public Task BeginTransactionAsync();
        public Task CommitTransactionAsync();
        public Task RollbackTransactionAsync();
    }
}
