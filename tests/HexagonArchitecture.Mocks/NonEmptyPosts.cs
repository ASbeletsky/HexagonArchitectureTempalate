using System.Linq;
using HexagonArchitecture.Domain.Common.Specifications;
using HexagonArchitecture.Domain.Common.Specifications.Paging;
using HexagonArchitecture.Services.Dto;

namespace HexagonArchitecture.Mocks
{
    public class NonEmptyPosts: IdPaging<PostDto, int>, IQuerySpecification<PostDto>
    {
        public IQueryable<PostDto> Apply(IQueryable<PostDto> query)
        {
            return query.Where(post => post.Content.Any());
        }
    }
}