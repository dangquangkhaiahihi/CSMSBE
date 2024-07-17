using AutoMapper;
using CSMS.Model.DTO.BaseFilterRequest;
using CSMS.Model;
using CSMSBE.Core.Helper;
using CSMSBE.Core.Resource;
using CSMSBE.Core;
using CSMSBE.Services.Implements;
using CSMSBE.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CSMS.Model.DTO.FilterRequest;
using CSMS.Model.DTO.IssueDTO;
using CSMSBE.Core.Interfaces;
using CSMS.Model.DTO.ModelDTO;
using CSMS.Model.Issue;
using CSMS.Model.Model;

namespace CSMSBE.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IModelService _modelService;
        private readonly IMapper _mapper;
        private readonly IWorkerService _workerService;
        public ModelController(IModelService modelService, IMapper mapper, IWorkerService workerService)
        {
            _mapper = mapper;
            _workerService = workerService;
            _modelService = modelService;
        }
        [HttpGet("GetLookup")]
        //[RequiresPermission(RoleHelper.Action.View, RoleHelper.Screen.IssueManagment)]
        public async Task<ActionResult<ResponseItem<LookupDTO>>> GetLookupModel([FromQuery] KeywordDto? keywordDto)
        {
            try
            {
                var issuesDto = await _modelService.GetLookupModel(keywordDto);
                //CreateLogHistory(ActionEnum.VIEW.GetHashCode(), "GetLookUpRole");
                return Ok(new ResponseData() { Content = _mapper.Map<List<LookupDTO>>(issuesDto) });
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new ResponseData()
                    {
                        Content = null,
                        Err = new ResponseErrorData(ErrorTypeConstant.UnableHandleException, $"{StringMessage.ErrorMessages.ErrorProcess} {ex}")
                    }
                );
            }
        }
        [HttpGet("Filter")]
        //[RequiresPermission(RoleHelper.Action.View, RoleHelper.Screen.IssueManagment)]
        public async Task<ActionResult<ResponseItem<IPagedList<ModelDTO>>>> GetFilteredData([FromQuery] ModelFilterRequest filter)
        {
            try
            {
                filter.ValidateInput();
                var results = await _modelService.FilterModel(filter);
                //CreateLogHistory(ActionEnum.VIEW.GetHashCode(), "GetFilteredData");
                return Ok(new ResponseData() { Content = results });
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new ResponseData()
                    {
                        Content = null,
                        Err = new ResponseErrorData(ErrorTypeConstant.UnableHandleException, $"{StringMessage.ErrorMessages.ErrorProcess} {ex}")
                    }
                );
            }
        }
        [HttpGet("GetById/{id}")]
        //[RequiresPermission(RoleHelper.Action.View, RoleHelper.Screen.Project)]
        public ActionResult<ResponseItem<ModelDTO>> Get(string id)
        {
            try
            {
                var result = _modelService.GetModelById(id);
                //CreateLogHistory(ActionEnum.VIEW.GetHashCode(), "GetByIdProject");
                return Ok(new ResponseData() { Content = result });
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new ResponseData()
                    {
                        Content = null,
                        Err = new ResponseErrorData(ErrorTypeConstant.UnableHandleException, $"{StringMessage.ErrorMessages.ErrorProcess} {ex}")
                    }
                );
            }
        }
        [HttpPost("Create")]
        //[RequiresPermission(RoleHelper.Action.Create, RoleHelper.Screen.Project)]
        public async Task<ActionResult<ResponseItem<ModelDTO>>> CreateModel(CreateModelDTO dto)
        {
            try
            {
                dto.ValidateInput();
                var userId = _workerService.GetCurrentUser().Id;
                var createResult = await _modelService.CreateModel(dto, userId);
                //CreateLogHistory(ActionEnum.CREATE.GetHashCode(), "CreateProject");
                return Ok(new ResponseData() { Content = createResult });
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new ResponseData()
                    {
                        Content = null,
                        Err = new ResponseErrorData(ErrorTypeConstant.DataNotValid, $"{StringMessage.ErrorMessages.DataNotValid} {ex}")
                    }
                );
            }
        }
        [HttpPut("Update")]
        //[RequiresPermission(RoleHelper.Action.Update, RoleHelper.Screen.Project)]
        public async Task<ActionResult<ResponseItem<ModelDTO>>> Put([FromBody] UpdateModelDTO updateData)
        {
            try
            {
                updateData.ValidateInput();
                var userId = _workerService.GetCurrentUser().Id;
                var updateResult = await _modelService.UpdateModel(updateData, userId);
                //CreateLogHistory(ActionEnum.UPDATE.GetHashCode(), "UpdateProject");
                return Ok(new ResponseData() { Content = updateResult });
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new ResponseData()
                    {
                        Content = null,
                        Err = new ResponseErrorData(ErrorTypeConstant.DataNotValid, $"{StringMessage.ErrorMessages.DataNotValid} {ex}")
                    }
                );
            }
        }
        [HttpDelete("Remove/{id}")]
        //[RequiresPermission(RoleHelper.Action.Delete, RoleHelper.Screen.Project)]
        public async Task<ActionResult<ResponseItem<bool>>> Delete(string id)
        {
            try
            {
                var result = await _modelService.RemoveModel(id);
                //CreateLogHistory(ActionEnum.DELETE.GetHashCode(), "RemoveProject");
                return Ok(new ResponseData() { Content = result });
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new ResponseData()
                    {
                        Content = null,
                        Err = new ResponseErrorData(ErrorTypeConstant.UnableHandleException, $"{StringMessage.ErrorMessages.ErrorProcess} {ex}")
                    }
                );
            }

        }

    }
}
