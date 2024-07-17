using CSMS.Model.DTO.BaseFilterRequest;
using CSMS.Model.Role;
using CSMSBE.Api.PermissionAttribute;
using CSMSBE.Core.Helper;
using CSMSBE.Core.Resource;
using CSMSBE.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CSMSBE.Services.Interfaces;
using CSMS.Model;
using AutoMapper;
using CSMS.Model.DTO.FilterRequest;
using CSMS.Model.DTO.SecurityMatrixDTO;
using CSMSBE.Core.Interfaces;
using CSMSBE.Services.Implements;
using CSMS.Model.DTO.IssueDTO;
using CSMS.Model.DTO.ProjectDTO;
using CSMS.Model.Issue;

namespace CSMSBE.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IIssueService _issueService;
        private readonly IMapper _mapper;
        private readonly IWorkerService _workerService;
        public IssueController(IIssueService issueService, IMapper mapper, IWorkerService workerService)
        {
            _issueService = issueService;
            _mapper = mapper;
            _workerService = workerService;
         }

        [HttpGet("GetLookup")]
        //[RequiresPermission(RoleHelper.Action.View, RoleHelper.Screen.IssueManagment)]
        public async Task<ActionResult<ResponseItem<LookupDTO>>> GetLookupIssue([FromQuery] KeywordDto? keywordDto)
        {
            try
            {
                var issuesDto = await _issueService.GetLookupIssue(keywordDto);
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
        public async Task<ActionResult<ResponseItem<IPagedList<IssueDTO>>>> GetFilteredData([FromQuery] IssueFilterRequest filter)
        {
            try
            {
                filter.ValidateInput();
                var results = await _issueService.FilterIssue(filter);
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
        public ActionResult<ResponseItem<IssueDTO>> Get(int id)
        {
            try
            {
                var result = _issueService.GetIssueById(id);
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
        public ActionResult<ResponseItem<IssueDTO>> CreateIssue(CreateIssueDTO dto)
        {
            try
            {
                dto.ValidateInput();
                var userId = _workerService.GetCurrentUser().Id;
                var createResult = _issueService.CreateIssue(dto, userId);
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
        public ActionResult<ResponseItem<IssueDTO>> Put([FromBody] UpdateIssueDTO updateData)
        {
            try
            {
                updateData.ValidateInput();
                var userId = _workerService.GetCurrentUser().Id;
                var updateResult = _issueService.UpdateIssue(updateData, userId);
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
        public ActionResult<ResponseItem<bool>> Delete(int id)
        {
            try
            {
                var result = _issueService.RemoveIssue(id);
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
