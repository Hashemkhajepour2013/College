namespace College.Entities.Common
{
    public interface IEntity { }

    public interface IEntity<TKey> : IEntity
    {
        public TKey Id { get; set; }
    }


    public abstract class BaseEntity<TKey> : IEntity<TKey>
    {
        public TKey Id { get; set; }
    }

    public abstract class BaseEntity : BaseEntity<int> { }
}
