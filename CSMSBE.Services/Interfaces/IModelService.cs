using CSMS.Model.DTO.BaseFilterRequest;
using CSMS.Model.DTO.FilterRequest;
using CSMS.Model.DTO.IssueDTO;
using CSMS.Model.DTO.ModelDTO;
using CSMS.Model.Issue;
using CSMS.Model.Model;
using CSMSBE.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMSBE.Services.Interfaces
{
    public interface IModelService
    {
        Task<IList<ModelDTO>> GetLookupModel(IKeywordDto keywordDto);
        Task<IPagedList<ModelDTO>> FilterModel(ModelFilterRequest filter);
        ModelDTO GetModelById(string id);
        Task<ModelDTO> CreateModel(CreateModelDTO dto, string userId);
        Task<ModelDTO> UpdateModel(UpdateModelDTO dto, string userId);
        Task<bool> RemoveModel(string id);
    }
}
