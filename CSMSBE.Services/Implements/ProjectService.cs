using AutoMapper;
using AutoMapper.QueryableExtensions;
using CSMS.Entity.CSMS_Entity;
using CSMSBE.Core.Extensions;
using CSMSBE.Core.Helper;
using CSMS.Data.Interfaces;
using CSMSBE.Infrastructure.Implements;
using CSMS.Model.DTO.FilterRequest;
using CSMS.Model.DTO.ProjectDTO;
using CSMSBE.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using CSMSBE.Core.Interfaces;
using CSMS.Model;
using CSMS.Model.DTO.BaseFilterRequest;
using CSMS.Data.Implements;
using CSMS.Model.DTO.IssueDTO;

namespace CSMSBE.Services.Implements
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ITypeProjectRepository _typeProjectRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProjectService> _logger;
        public ProjectService(IProjectRepository projectRepository, ITypeProjectRepository typeProjectRepository, IMapper mapper, ILogger<ProjectService> logger)
        {
            _projectRepository = projectRepository;
            _typeProjectRepository = typeProjectRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public ProjectDTO GetProjectById(string id)
        {
            try
            {
                var projectEntity = _projectRepository.Get(id);
                ProjectDTO projectDto = _mapper.Map<ProjectDTO>(projectEntity);
                return projectDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public IQueryable<ProjectDTO> GetLookupProject()
        {
            try
            {
                var result = _projectRepository.GetAll().ProjectTo<ProjectDTO>(_mapper.ConfigurationProvider);
                return result;               
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public async Task<IPagedList<ProjectDTO>> FilterProject(ProjectFilterRequest filter)
        {
            try
            {
                if (filter.PageIndex == 0) filter.PageIndex = Constant.DefaultPageIndex;
                if (filter.PageSize == 0) filter.PageSize = Constant.DefaultPageSize;

                var query = await CreateQuery(filter);

                var totalItemCount = await query.CountAsync();

                var sortedPagedQuery = ApplySortingToQuery(query, filter.Sorting);
                var pagedQuery = sortedPagedQuery.Skip((filter.PageIndex - 1) * filter.PageSize).Take(filter.PageSize);
                
                var resultItems = await pagedQuery.ProjectTo<ProjectDTO>(_mapper.ConfigurationProvider).ToListAsync();

                var pagedList = new PagedList<ProjectDTO>(resultItems, filter.PageIndex, filter.PageSize, totalItemCount);

                return pagedList;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public async Task<IQueryable<Project>> CreateQuery(ProjectFilterRequest filter)
        {
            if (!filter.IsDelete.HasValue)
            {
                filter.IsDelete = false;
            }

            var query = _projectRepository.GetAll()
                .WhereIf(!string.IsNullOrEmpty(filter.Name), x => x.Name.ToLower().Contains(filter.Name.ToLower()))
                .Where(x => x.IsDelete == filter.IsDelete);

            return await Task.FromResult(query);
        }

        private IQueryable<Project> ApplySortingToQuery(IQueryable<Project> query, string sorting)
        {
            if (!string.IsNullOrEmpty(sorting))
            {
                var sortParams = sorting.Split(' ');
                var sortBy = sortParams[0];
                var sortOrder = sortParams.Length > 1 ? sortParams[1] : "asc";

                var parameter = Expression.Parameter(typeof(Project), "x");
                var property = Expression.Property(parameter, sortBy);
                var lambda = Expression.Lambda(property, parameter);

                var methodName = sortOrder.ToLower() == "asc" ? "OrderBy" : "OrderByDescending";
                var resultExpression = Expression.Call(typeof(Queryable), methodName, new Type[] { query.ElementType, property.Type },
                    query.Expression, Expression.Quote(lambda));
                query = query.Provider.CreateQuery<Project>(resultExpression);
            }

            return query;
        }


        public async Task<bool> RemoveProject(int id)
        {
            try
            {
                var result = await _projectRepository.Remove(id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public async Task<ProjectDTO > CreateProject(CreateProjectDTO dto)
        {
            try
            {

                var result = await _projectRepository.Create(dto);
                return _mapper.Map<ProjectDTO>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public ProjectDTO UpdateProject(UpdateProjectDTO dto)
        {
            try
            {
                var result = _projectRepository.Update(dto);
                return _mapper.Map<ProjectDTO>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public async Task<IList<LookupDTO>> GetLookUpProjectType(IKeywordDto keywordDto)
        {
            try
            {
                var provinces = await _typeProjectRepository.GetLookupTypeProject(keywordDto).ToListAsync();
                if (provinces != null)
                {
                    var lookupProvincesDto = await Task.Run(() => provinces.AsParallel().Select(dto => _mapper.Map<LookupDTO>(dto)).ToList());
                    return lookupProvincesDto;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
