
using System.Collections.Generic;
using System.Linq;
using HexagonArchitecture.Domain.Core;
using HexagonArchitecture.Domain.Interfaces.Data;
using HexagonArchitecture.Infrastructure.Components;
using HexagonArchitecture.Infrastructure.Interfaces;
using HexagonArchitecture.Mocks.Data;
using HexagonArchitecture.Services.Common.Specifications;
using HexagonArchitecture.Services.Common.Sqrs.GenericCommandHandlers;
using HexagonArchitecture.Services.Common.Sqrs.GenericQueries;
using HexagonArchitecture.Services.Dto;
using HexagonArchitecture.Services.Dto.Properties;
using Xunit;

namespace HexagonArchitecture.UnitTests.Cqrs
{

    public class GenericQuriesTest
    {
        private readonly IQueryableDataSource dataSource;
        private IProjector projector;

        public GenericQuriesTest()
        {
            dataSource = new InMemoryDataSource();
            projector = new InstanceAutoMapper();
            IntitializeDataSource();
        }

        [Fact]
        public void CanGetById()
        {
            var getPosts = new GetByIdQuery<int, Post, PostDto>(dataSource, projector);
            var postDto = getPosts.Ask(id: 1);
            Assert.Equal(postDto.Id, 1);
            Assert.Equal(postDto.Title, "title1");
        }

        [Fact]
        public void CanAskBySpecification()
        {
            var bestBlogRule = new ExpressionSpecification<Blog>(blog => blog.Posts.Count > 2);
            var getBestBlogs = new ProjectionQuery<ExpressionSpecification<Blog>, Blog, BlogDto>(dataSource, projector);

            var bestBlogs = getBestBlogs.Ask(bestBlogRule);

            Assert.True(bestBlogs.Count() == 1);
            Assert.Equal(bestBlogs.FirstOrDefault().Id, 1);
        }

        [Fact]
        public void CanMakePaginationQuery()
        {
            var nonEmptyPosts = new ExpressionSpecification<Post>(post => post.Content.Any());
            var query = new PagedQuery<int, ExpressionSpecification<Post>, Post, PostDto>(dataSource, projector);

        }

        private void IntitializeDataSource()
        {
            var blog = new Blog() {Url = "test-url"};
            var posts = new List<Post>()
            {
                new Post {Title = "title1", Content = "text1", Blog = blog},
                new Post {Title = "title2", Content = "text2", Blog = blog},
                new Post {Title = "title3", Content = "text3", Blog = blog},
            };
            new CreateOrUpdateHandler<Blog>((IModifiableDataSource) dataSource, (IMapper) projector).Execute(blog);
            blog.Posts = posts;
            new CreateOrUpdateHandler<Blog>((IModifiableDataSource) dataSource, (IMapper) projector).Execute(blog);
        }

        private void CleanDataSource()
        {

        }
    }
}