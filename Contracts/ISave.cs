namespace Contracts
{
    public interface ISave<TEntity>
    {
        void Save(TEntity entity);
    }
}
