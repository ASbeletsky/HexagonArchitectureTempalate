using System;
using System.Linq;
using System.Collections.Generic;
using HexagonArchitecture.Domain.Core;
using HexagonArchitecture.Domain.Interfaces.Data;
using HexagonArchitecture.Infrastructure.Components;
using HexagonArchitecture.Infrastructure.Data;
using HexagonArchitecture.Infrastructure.Interfaces;
using HexagonArchitecture.Services.Dto;
using Xunit;

namespace HexagonArchitecture.UnitTests
{
    public class ProjectorTest : IDisposable
    {
        private IModifiableDataSource dataSource = new EfDataSource();
        private readonly Blog blog;
        public ProjectorTest()
        {
            this.blog = new Blog
            {
                Url = "test-blog.com",
                Posts = new List<Post>()
                {
                    new Post(){Title = "title1", Content = "text1"},
                    new Post(){Title = "title2", Content = "text2"}
                }

            };

            dataSource.AddOrUpdate<Blog>(blog);
        }

        [Fact]
        public void CanProjectWithRelatedEntity()
        {
            IProjector projector = new StaticAutoMapper();
            var postsQuery = (dataSource as IQueryableDataSource).Query<Post>().Where(p => p.BlogId == 1);

            var firtsPostDto = projector.Project<Post, PostDto>(postsQuery).FirstOrDefault();

            Assert.True(firtsPostDto != null);
            Assert.Equal(blog.Url, firtsPostDto.BlogUrl);
        }

        public void Dispose()
        {
            dataSource.Delete(blog);
        }
    }
}