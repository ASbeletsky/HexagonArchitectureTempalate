using System.Collections.Generic;
using HexagonArchitecture.Domain.Interfaces.Cqrs;

namespace HexagonArchitecture.Mocks
{
    public class TestDependentObject
    {
        public TestDependentObject(//IQuery<IdPaging<SomeEntityDto>, IPagedEnumerable<SomeEntityDto>> pagedQuery,
             IQuery<object, IEnumerable<SomeEntityDto>> projectionQuery,
             IQuery<int, SomeEntityDto> getQuery,
             ICommandHandler<SomeEntityDto, int> createOrUpdateCommandHandler)
        {
        }
    }
}