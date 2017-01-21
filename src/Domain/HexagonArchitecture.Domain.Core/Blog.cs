using System.Collections.Generic;
using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;

namespace HexagonArchitecture.Domain.Core
{    
    public class Blog : EntityBase<int>
    {
        public string Url { get; set; }

        public List<Post> Posts { get; set; }
    }
}
