using AutoMapper;
using HexagonArchitecture.Domain.Core;
using HexagonArchitecture.Services.Dto;

namespace HexagonArchitecture.Infrastructure.Components
{
    public class MappingContainer: Profile
    {
        public MappingContainer()
        {
            CreateMap<Post, PostDto>().ForMember(dest => dest.BlogUrl, cfg => cfg.MapFrom(src => src.Blog.Url));
        }
    }
}