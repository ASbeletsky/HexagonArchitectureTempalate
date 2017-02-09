using AutoMapper;
using HexagonArchitecture.Domain.Core;
using HexagonArchitecture.Domain.Core.Entities;
using HexagonArchitecture.Services.Dto;
using HexagonArchitecture.Services.Dto.Properties;

namespace HexagonArchitecture.Infrastructure.Components
{
    public class MappingContainer: Profile
    {
        public MappingContainer()
        {
            CreateMap<Blog, BlogDto>().ReverseMap();

            CreateMap<Post, PostDto>()
                .ForMember(dest => dest.BlogUrl, cfg => cfg.MapFrom(src => src.Blog.Url))
                .ReverseMap();
        }
    }
}