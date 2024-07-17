using CSMS.Entity.CSMS_Entity;
using CSMS.Model.DTO.FilterRequest;
using CSMS.Model.DTO.ProjectDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMS.Data.Interfaces
{
    public interface IProjectRepository
    {
        Task<Project> Create(CreateProjectDTO table);
        IQueryable<Project> GetAll();
        Task<Project> Get(string id);
        IQueryable<Project> GetAll(ProjectFilterRequest filter);
        Task<Project> Update(UpdateProjectDTO table);
        Task<bool> Remove(int id);
    }
}
