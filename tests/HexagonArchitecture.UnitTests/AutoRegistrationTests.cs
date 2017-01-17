using System.Collections.Generic;
using Xunit;
using System.Reflection;
using HexagonArchitecture.Domain.Interfaces.Cqrs;
using HexagonArchitecture.Infrastructure.Components;
using HexagonArchitecture.Mocks;
using HexagonArchitecture.Services.Common.Sqrs.GenericCommands;
using HexagonArchitecture.Services.Common.Sqrs.GenericQueries;

namespace HexagonArchitecture.UnitTests
{
    public class AutoRegistrationTests
    {
        [Fact]
        public void AutoRegistration_MainComponentsSetUp()
        {
            var assembly = this.GetType().GetTypeInfo().Assembly;
            var res = new AutoRegistration().GetComponentMap(assembly, t => t == typeof(TestDependentObject), assembly, t => true);

            Assert.Equal(
                typeof(ProjectionQuery<object, SomeEntity, SomeEntityDto>),
                res[typeof(IQuery<object, IEnumerable<SomeEntityDto>>)]);

            /*Assert.Equal(
                typeof(PagedQuery<int, IdPaging<SomeEntityDto>, SomeEntity, SomeEntityDto>),
                res[typeof(IQuery<IdPaging<SomeEntityDto>, IPagedEnumerable<SomeEntityDto>>)]);*/

            Assert.Equal(
                typeof(GetByIdQuery<int, SomeEntity, SomeEntityDto>),
                res[typeof(IQuery<int, SomeEntityDto>)]);

            Assert.Equal(
                typeof(CreateOrUpdateHandler<int, SomeEntityDto, SomeEntity>),
                res[typeof(ICommandHandler<SomeEntityDto, int>)]);
        }
}