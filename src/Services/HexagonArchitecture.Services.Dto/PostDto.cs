using HexagonArchitecture.Domain.Core.Entities;
using HexagonArchitecture.Infrastructure.Interfaces;

namespace HexagonArchitecture.Services.Dto
{
    [DtoFor(typeof(Post))]
    public class PostDto : DtoBase<int>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string BlogUrl { get; set; }
    }
}