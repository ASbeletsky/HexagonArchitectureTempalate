using System.Collections.Generic;
using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;

namespace HexagonArchitecture.Domain.Core.Entities
{    
    public class Blog : EntityBase<int>
    {
        public Blog()
        {
            this.Posts = new HashSet<Post>();
        }

        public string Url { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
