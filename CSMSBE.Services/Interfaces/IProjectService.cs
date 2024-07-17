using CSMSBE.Infrastructure.Interfaces;
using CSMS.Model.DTO.FilterRequest;
using CSMS.Model.DTO.ProjectDTO;
using CSMS.Model.DTO.SomeTableDTO;
using CSMSBE.Core.Interfaces;
using CSMS.Model.DTO.BaseFilterRequest;
using CSMS.Model;

namespace CSMSBE.Services.Interfaces
{
    public interface IProjectService
    {
        Task<ProjectDTO> CreateProject(CreateProjectDTO dto);
        IQueryable<ProjectDTO> GetLookupProject();
        ProjectDTO GetProjectById(string id);
        Task<IPagedList<ProjectDTO>> FilterProject(ProjectFilterRequest filter);
        ProjectDTO UpdateProject(UpdateProjectDTO dto);
        Task<bool> RemoveProject(int id);
        Task<IList<LookupDTO>> GetLookUpProjectType(IKeywordDto keywordDto);
    }
}
