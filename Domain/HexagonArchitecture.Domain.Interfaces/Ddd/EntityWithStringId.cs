namespace HexagonArchitecture.Domain.Interfaces.Ddd
{
    public class EntityWithStringId<TKey> : EntityBase<string>
    {
        public override bool Equals(object obj)
        {
            var compateTo = obj as EntityWithStringId<TKey>;

            if (ReferenceEquals(null, compateTo)) return false;
            if (ReferenceEquals(this, compateTo)) return false;
            return !this.IsNew && !compateTo.IsNew && this.Id == compateTo.Id;
        }

        public override int GetHashCode()
        {
            return (this.GetType().GetHashCode() * 907) + this.Id.GetHashCode();
        }
    }
}