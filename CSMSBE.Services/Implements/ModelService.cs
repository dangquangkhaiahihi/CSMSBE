using AutoMapper;
using CSMS.Data.Implements;
using CSMS.Data.Interfaces;
using CSMS.Entity.CSMS_Entity;
using CSMS.Entity.Issues;
using CSMS.Model.DTO.BaseFilterRequest;
using CSMS.Model.DTO.FilterRequest;
using CSMS.Model.DTO.IssueDTO;
using CSMS.Model.DTO.ModelDTO;
using CSMS.Model.Model;
using CSMSBE.Core.Extensions;
using CSMSBE.Core.Helper;
using CSMSBE.Core.Interfaces;
using CSMSBE.Infrastructure.Implements;
using CSMSBE.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CSMSBE.Services.Implements
{
    public class ModelService : IModelService
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ModelService> _logger;
        public ModelService(IModelRepository modelRepository, IMapper mapper, ILogger<ModelService> logger)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IPagedList<ModelDTO>> FilterModel(ModelFilterRequest filter)
        {
            try
            {
                if (filter.PageIndex == 0) filter.PageIndex = Constant.DefaultPageIndex;
                if (filter.PageSize == 0) filter.PageSize = Constant.DefaultPageSize;

                var query = await CreateQuery(filter);

                var totalItemCount = await query.CountAsync();

                var sortedPagedQuery = ApplySortingToQuery(query, filter.Sorting);
                var pagedQuery = sortedPagedQuery.Include(i => i.Project).Skip((filter.PageIndex - 1) * filter.PageSize).Take(filter.PageSize);
                var resultItems = await pagedQuery
                        .Select(i => new ModelDTO
                        {
                            Id = i.Id,
                            Name = i.Name,
                            Type = i.Type,
                            Level = i.Level,
                            Description = i.Description,
                            SpeckleBranchId = i.SpeckleBranchId,
                            ProjectID = i.ProjectID,
                            ProjectName = i.Project.Name,                           
                            CreatedDate = (DateTime)i.CreatedDate,
                            CreatedBy = i.CreatedBy,
                            ModifiedDate = (DateTime)i.ModifiedDate,
                            ModifiedBy = i.ModifiedBy,
                            IsDelete = i.IsDelete,
                        })
                        .Where(i => i.IsDelete == false)
                        .ToListAsync();

                var pagedList = new PagedList<ModelDTO>(resultItems, filter.PageIndex, filter.PageSize, totalItemCount);

                return pagedList;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }
        public async Task<IQueryable<Model>> CreateQuery(ModelFilterRequest filter)
        {
            if (!filter.IsDelete.HasValue)
            {
                filter.IsDelete = false;
            }
            var query = _modelRepository.GetAll()
                .WhereIf(!string.IsNullOrEmpty(filter.Name), x => x.Name.ToLower().Contains(filter.Name.ToLower()))
                .WhereIf(!string.IsNullOrEmpty(filter.Type), x => x.Type.ToLower().Contains(filter.Type.ToLower()))            
                .WhereIf(!string.IsNullOrEmpty(filter.Description), x => x.Description.ToLower().Contains(filter.Description.ToLower()))
                .WhereIf(!string.IsNullOrEmpty(filter.ProjectName), x => x.Project.Name.ToLower().Contains(filter.ProjectName.ToLower()));

            return await Task.FromResult(query);
        }

        private IQueryable<Model> ApplySortingToQuery(IQueryable<Model> query, string sorting)
        {
            if (!string.IsNullOrEmpty(sorting))
            {
                var sortParams = sorting.Split(' ');
                var sortBy = sortParams[0];
                var sortOrder = sortParams.Length > 1 ? sortParams[1] : "asc";

                var parameter = Expression.Parameter(typeof(Model), "x");
                var property = Expression.Property(parameter, sortBy);
                var lambda = Expression.Lambda(property, parameter);

                var methodName = sortOrder.ToLower() == "asc" ? "OrderBy" : "OrderByDescending";
                var resultExpression = Expression.Call(typeof(Queryable), methodName, new Type[] { query.ElementType, property.Type },
                    query.Expression, Expression.Quote(lambda));
                query = query.Provider.CreateQuery<Model>(resultExpression);
            }

            return query;
        }
        public async Task<IList<ModelDTO>> GetLookupModel(IKeywordDto keywordDto)
        {
            try
            {
                var models = await _modelRepository.GetLookupModel(keywordDto).ToListAsync();
                if (models != null)
                {
                    var modelsDto = _mapper.Map<List<ModelDTO>>(models);
                    return modelsDto;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public ModelDTO GetModelById(string id)
        {
            try
            {
                var result = _mapper.Map<ModelDTO>(_modelRepository.Get(id));
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<ModelDTO> CreateModel(CreateModelDTO dto, string userId)
        {
            try
            {

                var result = await _modelRepository.Create(dto, userId);
                return _mapper.Map<ModelDTO>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<ModelDTO> UpdateModel(UpdateModelDTO dto, string userId)
        {
            try
            {
                var updatedEntity = await _modelRepository.Update(dto, userId);
                var issueDto = _mapper.Map<ModelDTO>(updatedEntity);
                issueDto.ProjectName = updatedEntity.Project.Name;
                return issueDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public async Task<bool> RemoveModel(string id)
        {
            try
            {
                var result = await _modelRepository.Remove(id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
