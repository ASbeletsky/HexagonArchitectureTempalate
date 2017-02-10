using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using Autofac;
using HexagonArchitecture.Domain.Common.Sqrs.GenericQueries;
using HexagonArchitecture.Domain.Interfaces.Cqrs;
using HexagonArchitecture.Domain.Interfaces.Ddd.Entities;
using HexagonArchitecture.Infrastructure.Interfaces;
using HexagonArchitecture.Services.Dto;

namespace HexagonArchitecture.Infrastructure.Components
{
    public class TypeRegistrator
    {
        private readonly IDictionary<Type, IDictionary<Type, Type>> _typeAssociationDictionary = new Dictionary<Type, IDictionary<Type, Type>>();

        public void RegisterQueriesToModel(Type modelType)
        {
            var typeInfo = modelType.GetTypeInfo();
            bool isAggregate = typeInfo.IsAssignableFrom(typeof(IAggregateRoot));
            if (isAggregate)
            {
                var keyType = modelType.GetProperty("Id").GetType();
                var getById = typeof(GetByIdQuery<,>).MakeGenericType(keyType, modelType);
                var getAggregate = typeof(IQuery<,>).MakeGenericType(keyType, modelType);
                var typeQueries = new Dictionary<Type, Type> {{getAggregate, getById}};
                this._typeAssociationDictionary.Add(modelType, typeQueries);
            }

            var dtoFor = typeInfo.GetCustomAttribute<DtoForAttribute>();
            bool isDto = typeInfo.IsAssignableFrom(typeof(DtoBase<>)) && dtoFor!= null;
            if (isDto)
            {
                var keyType = modelType.GetProperty("Id").GetType();
                var getById = typeof(GetByIdQuery<,,>).MakeGenericType(keyType, modelType, dtoFor.EntityType);
                var getAggregate = typeof(IQuery<,>).MakeGenericType(keyType, modelType, dtoFor.EntityType);

                var projection = typeof(ProjectionQuery<,,>).MakeGenericType(keyType, modelType, dtoFor.EntityType);
            }



        }
    }
}