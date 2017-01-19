using Xunit;

namespace HexagonArchitecture.UnitTests
{
    public class AutoRegistrationTests
    {
        [Fact]
        public void AutoRegistration_MainComponentsSetUp()
        {
/*            var currentAssembly = this.GetType().GetTypeInfo().Assembly;
            var mocksAssembly = typeof(TestDependentObject).GetTypeInfo().Assembly;
            var res = new AutoRegistration().GetComponentMap(mocksAssembly, t => t == typeof(TestDependentObject), mocksAssembly, t => true);

            Assert.Equal(
                typeof(ProjectionQuery<object, SomeEntity, SomeEntityDto>),
                res[typeof(IQuery<object, IEnumerable<SomeEntityDto>>)]);

            Assert.Equal(
                typeof(PagedQuery<int, IdPaging<SomeEntityDto>, SomeEntity, SomeEntityDto>),
                res[typeof(IQuery<IdPaging<SomeEntityDto>, IPagedEnumerable<SomeEntityDto>>)]);

            Assert.Equal(
                typeof(GetByIdQuery<int, SomeEntity, SomeEntityDto>),
                res[typeof(IQuery<int, SomeEntityDto>)]);

            Assert.Equal(
                typeof(CreateOrUpdateHandler<int, SomeEntityDto, SomeEntity>),
                res[typeof(ICommandHandler<SomeEntityDto, int>)]);*/
        }
    }
}