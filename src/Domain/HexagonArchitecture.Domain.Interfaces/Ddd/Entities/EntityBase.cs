namespace HexagonArchitecture.Domain.Interfaces.Ddd.Entities
{
    public class EntityBase<TKey> : IEntity<TKey>
    {
        public TKey Id { get; set; }

        object IHasId.Id => this.Id;

        public bool IsNew
        {
            get { return this.Id.Equals(default(TKey)); }
        }

        public override bool Equals(object obj)
        {
            var compateTo = obj as EntityBase<TKey>;

            if (ReferenceEquals(null, compateTo)) return false;
            if (ReferenceEquals(this, compateTo)) return false;
            return !this.IsNew && !compateTo.IsNew && this.Id.Equals(compateTo.Id);
        }

        public override int GetHashCode()
        {
            return (this.GetType().GetHashCode() * 907) + this.Id.GetHashCode();
        }
    }
}