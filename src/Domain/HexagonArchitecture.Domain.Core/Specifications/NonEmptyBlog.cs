using HexagonArchitecture.Domain.Interfaces.Paging;

namespace HexagonArchitecture.Domain.Core.Specifications
{

    #region Using

    using System.Linq;
    using HexagonArchitecture.Domain.Common.Specifications;
    using HexagonArchitecture.Domain.Core.Entities;

    #endregion

    public class NonEmptyPost: IdPaging<Post, int>, IQuerySpecification<Post>
    {
        public NonEmptyPost(){ }

        public NonEmptyPost(int page, int take) : base(page, take){ }

        public IQueryable<Post> Apply(IQueryable<Post> query)
        {
            return query.Where(post => post.Content.Any());
        }
    }
}