namespace Contracts
{
    public interface IDelete<TEntity>
    {
        void Delete(TEntity entity);
    }
}
