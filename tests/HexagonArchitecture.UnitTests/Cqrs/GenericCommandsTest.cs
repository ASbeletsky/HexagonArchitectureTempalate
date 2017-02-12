namespace HexagonArchitecture.UnitTests.Cqrs
{
    #region Using

    using HexagonArchitecture.Domain.Interfaces.Data;
    using HexagonArchitecture.Infrastructure.Components;
    using HexagonArchitecture.Infrastructure.Interfaces;
    using System;
    using HexagonArchitecture.Domain.Common.Sqrs.GenericCommandHandlers;
    using HexagonArchitecture.Domain.Core.Entities;
    using HexagonArchitecture.Mocks;
    using HexagonArchitecture.Services.Dto;
    using Xunit;

    #endregion

    public class GenericCommandsTest : IDisposable
    {
        private IModifiableDataSource dataSource;
        private IMapper mapper;

        public GenericCommandsTest()
        {
            dataSource = new InMemoryDataSource();
            mapper = new InstanceAutoMapper();
        }

        [Fact]
        public void CanCreateEntity()
        {
            var postForCreate = new Post() { Title = "title1", Content = "text1" };

            var createPost = new CreateOrUpdateHandler<Post>(dataSource, mapper);
            var createdPostId = (int)createPost.Execute(postForCreate);
            var createdPost = dataSource.Find<Post>(createdPostId);

            Assert.Equal(postForCreate, createdPost);
        }

        [Fact]
        public void CanCreateEntityFromDto()
        {
            var postDtoForCreate = new PostDto() { Title = "title1", Content = "text1" };

            var createPostFromDto = new CreateOrUpdateFromDtoHandler<PostDto, Post>(dataSource, mapper);
            var createdPostId = createPostFromDto.Execute<int>(postDtoForCreate);
            var createdPost = dataSource.Find<Post>(createdPostId);

            Assert.Equal(postDtoForCreate.Title, createdPost.Title);
            Assert.Equal(postDtoForCreate.Content, createdPost.Content);
        }

        [Fact]
        public void CanUpdateEntity()
        {
            int existingPostId = CreateTestPostEntity();
            var postForUpdate = dataSource.Find<Post>(existingPostId);

            var updatePost = new CreateOrUpdateHandler<Post>(dataSource, mapper);
            postForUpdate.Title = "title2";
            updatePost.Execute(postForUpdate);

            var updatedPost = dataSource.Find<Post>(postForUpdate.Id);
            Assert.Equal(postForUpdate.Title, updatedPost.Title);
        }

        [Fact]
        public void CanUpdateEntityFromDto()
        {
            int existingPostId = CreateTestPostEntity();
            var postForUpdateDto = new PostDto() {Id = existingPostId, Title = "title2"};

            var updatePostFromDto = new CreateOrUpdateFromDtoHandler<PostDto, Post>(dataSource, mapper);
            updatePostFromDto.Execute<int>(postForUpdateDto);

            var updatedPost = dataSource.Find<Post>(postForUpdateDto.Id);
            Assert.Equal(postForUpdateDto.Title, updatedPost.Title);
        }

        [Fact]
        public void CanDeleteEntity()
        {
            int existingPostId = CreateTestPostEntity();
            var postForDelte = dataSource.Find<Post>(existingPostId);

            var deletePost = new DeleteHandler<int, Post>(dataSource);
            deletePost.Execute(postForDelte.Id);

            var deletedPost = dataSource.Find<Post>(postForDelte.Id);
            Assert.Equal(null, deletedPost);
        }

        private int CreateTestPostEntity()
        {
            var createCommand = new CreateOrUpdateHandler<Post>(dataSource, mapper);
            var post = new Post() { Title = "title1", Content = "text1" };
            return (int) createCommand.Execute(post);
        }

        public void Dispose()
        {
            new DeleteHandler<int, Post>(dataSource).Execute(id: 1);
            dataSource.Dispose();
        }
    }
}