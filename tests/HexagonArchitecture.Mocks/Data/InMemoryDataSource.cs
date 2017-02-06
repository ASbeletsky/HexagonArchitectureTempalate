using HexagonArchitecture.Domain.Interfaces.Data;
using HexagonArchitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HexagonArchitecture.Mocks.Data
{
    public class InMemoryDataSource : EfDataSource
    {
        public InMemoryDataSource()
            : base(new BlogsDbContext(new DbContextOptionsBuilder<BlogsDbContext>()
                                         .UseInMemoryDatabase(databaseName: "blogdb")
                                         .Options))
        {
        }
    }
}