using System.Collections.Generic;
using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;
using HexagonArchitecture.Infrastructure.Interfaces;
using HexagonArchitecture.Mocks;
using HexagonArchitecture.Mocks.Data;
using HexagonArchitecture.Services.Common.Sqrs.GenericQueries;
using Moq;
using Xunit;

namespace HexagonArchitecture.UnitTests.Cqrs.GenericCommands
{

    public class GetByIdQueryTest
    {
        [Fact]
        public void CanGetById()
        {
            var first = new SomeEntity {Id = 1};
            var second = new SomeEntity {Id = 2};
            var entities = new List<IEntity<int>> {first, second};
            var linqProvider = new LinqProvider(entities);
            var projector = new Mock<IProjector>().Object;

            var query = new GetByIdQuery<int, SomeEntity, SomeEntity>(linqProvider, projector);

            Assert.Equal(second, query.Ask(id: 2));
        }
    }
}