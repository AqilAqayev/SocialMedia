using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SocalMedia.Business.Dtos.Generic;
using SocalMedia.Business.Services.Abstractions.Generic;
using SocialMedia.Core.Entities.Base;
using SocialMedia.DataAccess.Repositories.Abstraction.Generic;
using System.Linq.Expressions;

namespace SocalMedia.Business.Services.Implementations.Generic;

public class CrudService<TEntity, TCreateDto, TUpdateDto, TDto> : ICrudService<TEntity, TCreateDto, TUpdateDto, TDto>
where TEntity : BaseEntity
where TCreateDto : IDto
where TUpdateDto : IDto
where TDto : IDto
{
    private readonly IRepository<TEntity> _repository;
    private readonly IMapper _mapper;

    public CrudService(IRepository<TEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<TDto> CreateAsync(TCreateDto entity)
    {
        var entityEntry = _mapper.Map<TEntity>(entity);
        await _repository.CreateAsync(entityEntry);
        return _mapper.Map<TDto>(entityEntry);
    }

    public async Task<TDto> DeleteAsync(int id)
    {
        var entity = await _repository.GetAsync(e => e.Id == id);
        if (entity == null) throw new KeyNotFoundException("Entity not found");

         _repository.Delete(entity);
        return _mapper.Map<TDto>(entity);
    }

    public async Task<List<TDto>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, bool enableTracking = true)
    {
        var entitiesQuery = _repository.GetAll(include, enableTracking);

        if (predicate != null)
            entitiesQuery = entitiesQuery.Where(predicate);

        if (orderBy != null)
            entitiesQuery = orderBy(entitiesQuery);

        var entities = await entitiesQuery.ToListAsync();
        var dto = _mapper.Map<List<TDto>>(entities);
        return dto;
    } 

    public async Task<TDto?> GetAsync(int id)
    {
        var entity = await _repository.GetAsync(e => e.Id == id);
        return _mapper.Map<TDto>(entity); ;
    }

    public virtual async Task<TDto?> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null)
    {
        var entity = await _repository.GetAsync(predicate, include);
        return _mapper.Map<TDto>(entity);
    }

    public async Task<TDto> UpdateAsync(TUpdateDto entity)
    {
        var entityEntry = _mapper.Map<TEntity>(entity);
         _repository.Update(entityEntry);
        return _mapper.Map<TDto>(entity);
    }

    
}

