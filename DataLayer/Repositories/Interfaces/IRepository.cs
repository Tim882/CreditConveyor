namespace CreditConveyor.DbLayer
{
    public interface IRepository<T>
    {
        public Task<List<T>> GetAllAsync();
        public Task<T> GetByIdAsync(Guid id);
        public Task<bool> CreateAsync(T entity);
        public Task<bool> UpdateAsync(T entity);
        public Task<bool> DeleteAsync(Guid id);
    }
}
