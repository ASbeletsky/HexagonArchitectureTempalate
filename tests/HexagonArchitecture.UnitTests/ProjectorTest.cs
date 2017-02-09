namespace HexagonArchitecture.UnitTests
{
    #region Using

    using System;
    using System.Linq;
    using HexagonArchitecture.Domain.Interfaces.Data;
    using HexagonArchitecture.Infrastructure.Components;
    using HexagonArchitecture.Infrastructure.Interfaces;
    using HexagonArchitecture.Services.Dto;
    using HexagonArchitecture.Domain.Core.Entities;
    using HexagonArchitecture.Mocks;
    using Xunit;

    #endregion

    public class ProjectorTest : IDisposable
    {
        private IModifiableDataSource dataSource = new InMemoryDataSource();
        private readonly Blog blog;
        public ProjectorTest()
        {
            this.blog = new Blog
            {
                Url = "test-blog.com"
            };

            dataSource.AddOrUpdate<Blog>(blog);
            this.blog.Posts.Add(new Post(){Title = "title1", Content = "text1"});
            this.blog.Posts.Add(new Post(){Title = "title2", Content = "text2"});
            dataSource.SaveChanges();
        }

        [Fact]
        public void CanProjectWithRelatedEntity()
        {
            IProjector projector = new InstanceAutoMapper();
            var postsQuery = (dataSource as IQueryableDataSource).Query<Post>().Where(p => p.BlogId == 1);

            var firtsPostDto = projector.Project<Post, PostDto>(postsQuery).FirstOrDefault();

            Assert.True(firtsPostDto != null);
            Assert.Equal(blog.Url, firtsPostDto.BlogUrl);
        }

        public void Dispose()
        {
            dataSource.Delete(blog);
            dataSource.SaveChanges();
        }
    }
}