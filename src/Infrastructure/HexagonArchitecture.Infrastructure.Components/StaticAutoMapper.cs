using System.Linq;
using AutoMapper.QueryableExtensions;
using HexagonArchitecture.Infrastructure.Interfaces;
using AM = AutoMapper;
using IMapper = HexagonArchitecture.Infrastructure.Interfaces.IMapper;

namespace HexagonArchitecture.Infrastructure.Components
{
    public class StaticAutoMapper : IMapper, IProjector
    {
        public TDest Map<TSource, TDest>(TSource src)
        {
            return AM.Mapper.Map<TSource, TDest>(src);
        }

        public TDest Map<TSource, TDest>(TSource src, TDest dest)
        {
            return AM.Mapper.Map<TSource, TDest>(src, dest);
        }

        public IQueryable<TReturn> Project<TSource, TReturn>(IQueryable<TSource> queryable)
        {
            return queryable.ProjectTo<TReturn>();
        }
    }
}