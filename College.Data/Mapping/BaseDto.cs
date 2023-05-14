﻿using System.ComponentModel.DataAnnotations;
using AutoMapper;
using College.Data.Mapping;
using College.Entities.Common;

namespace College.MyApi;

public abstract class BaseDto<TDto, TEntity, TKey> : IHaveCustomMapping
    where TDto : class, new()
    where TEntity : class, IEntity<TKey>, new()
{

    public TEntity ToEntity(IMapper mapper)
    {
        return mapper.Map<TEntity>(CastToDerivedClass(mapper, this));
    }

    public TEntity ToEntity(IMapper mapper, TEntity entity)
    {
        return mapper.Map(CastToDerivedClass(mapper, this), entity);
    }

    public static TDto FromEntity(IMapper mapper, TEntity model)
    {
        return mapper.Map<TDto>(model);
    }

    protected TDto CastToDerivedClass(IMapper mapper, BaseDto<TDto, TEntity, TKey> baseInstance)
    {
        return mapper.Map<TDto>(baseInstance);
    }

    public void CreateMappings(Profile profile)
    {
        var mappingExpression = profile.CreateMap<TDto, TEntity>();

        var dtoType = typeof(TDto);
        var entityType = typeof(TEntity);

        foreach (var property in entityType.GetProperties())
        {
            if (dtoType.GetProperty(property.Name) == null)
                mappingExpression.ForMember(property.Name, opt => opt.Ignore());
        }

        CustomMappings(mappingExpression.ReverseMap());
    }

    public virtual void CustomMappings(IMappingExpression<TEntity, TDto> mapping)
    {
    }
}

public abstract class BaseDto<TDto, TEntity> : BaseDto<TDto, TEntity, int>
    where TDto : class, new()
    where TEntity : class, IEntity<int>, new()
{

}