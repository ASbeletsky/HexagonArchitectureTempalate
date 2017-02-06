using HexagonArchitecture.Domain.Core;
using HexagonArchitecture.Services.Common.Specifications;
using Xunit;

namespace HexagonArchitecture.UnitTests
{
    public class SpecificationTests
    {
        private Post _post = new Post() {Id = 10};

        [Fact]
        public void ExpressionSpecification_IsSatisfiedBy_Success()
        {
            var spec = new ExpressionSpecification<Post>(x => x.Id == 10);
            Assert.True(spec.IsSatisfiedBy(_post));
        }

        [Fact]
        public void IdSpecification_IsSatisfiedBy_Success()
        {
            var spec = new IdSpecification<int, Post>(10);
            Assert.True(spec.IsSatisfiedBy(_post));
        }
    }
}