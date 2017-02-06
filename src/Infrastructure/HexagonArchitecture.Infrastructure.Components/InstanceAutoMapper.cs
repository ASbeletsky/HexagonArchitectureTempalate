using System;
using System.Linq;
using AutoMapper.QueryableExtensions;
using HexagonArchitecture.Infrastructure.Interfaces;
using AM = AutoMapper;
using IMapper = HexagonArchitecture.Infrastructure.Interfaces.IMapper;

namespace HexagonArchitecture.Infrastructure.Components
{
    public class InstanceAutoMapper : IMapper, IProjector
    {
        public AM.IConfigurationProvider Configuration { get; private set; }
        public AM.IMapper Instance { get; private set; }

        private static Action<AM.IMapperConfigurationExpression> _configMapper = (cfg) =>
        {
            cfg.AddProfiles("HexagonArchitecture.Infrastructure.Components");
        };


        public InstanceAutoMapper(bool skipConfigurationValidation = false)
            : this(new AM.MapperConfiguration(_configMapper), skipConfigurationValidation)
        {

        }

        public InstanceAutoMapper(AM.IConfigurationProvider configuration, bool skipConfigurationValidation = false)
        {
            Configuration = configuration;

            if (!skipConfigurationValidation)
            {
                configuration.AssertConfigurationIsValid();
            }

            Instance = configuration.CreateMapper();
        }

        public TDest Map<TSource, TDest>(TSource src)
        {
            return this.Instance.Map<TSource, TDest>(src);
        }

        public TDest Map<TSource, TDest>(TSource src, TDest dest)
        {
            return this.Instance.Map<TSource, TDest>(src, dest);
        }

        public IQueryable<TReturn> Project<TSource, TReturn>(IQueryable<TSource> queryable)
        {
            return queryable.ProjectTo<TReturn>(Configuration);
        }
    }
}