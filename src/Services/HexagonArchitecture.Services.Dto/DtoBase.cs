using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;

namespace HexagonArchitecture.Services.Dto
{
    public class DtoBase<TKey> : IHasId<TKey>
    {
        public TKey Id { get; set; }
        object IHasId.Id => this.Id;
    }
}