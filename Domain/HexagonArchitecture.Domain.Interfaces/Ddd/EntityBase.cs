namespace HexagonArchitecture.Domain.Interfaces.Ddd
{
    public class EntityBase<TKey> : IEntity<TKey>
    {
        public TKey Id { get; set; }

        object IEntity.Id => this.Id;

        public bool IsNew
        {
            get { return this.Id.Equals(default(TKey)); }
        }
    }
}