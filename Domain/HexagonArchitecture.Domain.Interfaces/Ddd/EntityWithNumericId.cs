namespace HexagonArchitecture.Domain.Interfaces.Ddd
{
    public class EntityWithNumericId<TKey> : EntityBase<int>
    {
        public override bool Equals(object obj)
        {
            var compateTo = obj as EntityWithNumericId<TKey>;

            if (ReferenceEquals(null, compateTo)) return false;
            if (ReferenceEquals(this, compateTo)) return false;
            return !this.IsNew && !compateTo.IsNew && this.Id == compateTo.Id;
        }

        public override int GetHashCode()
        {
            return this.GetType().GetHashCode() * 907 + Id;
        }
    }
}