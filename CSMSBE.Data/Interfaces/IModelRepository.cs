using CSMS.Data.Repository;
using CSMS.Entity.CSMS_Entity;
using CSMS.Entity.Issues;
using CSMS.Model.DTO.BaseFilterRequest;
using CSMS.Model.Issue;
using CSMS.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CSMS.Data.Interfaces
{
    public interface IModelRepository : IBaseRepository<Entity.CSMS_Entity.Model>
    {
        IQueryable<Entity.CSMS_Entity.Model> GetLookupModel(IKeywordDto keywordDto);
        Entity.CSMS_Entity.Model Get(string id);
        Task<Entity.CSMS_Entity.Model> Create(CreateModelDTO dto, string userId);
        Task<Entity.CSMS_Entity.Model> Update(UpdateModelDTO dto, string userId);
        Task<bool> Remove(string id);
    }
}
