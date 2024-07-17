using CSMSBE.Core;
using CSMSBE.Core.Helper;
using CSMSBE.Infrastructure.Interfaces;
using CSMSBE.Core.Resource;
using CSMS.Model.DTO.FilterRequest;
using CSMSBE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Office.Interop.Excel;
using System.Net.WebSockets;
using System.Text;
using CSMS.Model.DTO.ProjectDTO;
using CSMSBE.Core.Interfaces;
using CSMSBE.Api.PermissionAttribute;
using CSMSBE.Core.Enum;
using CSMS.Model.User;
using CSMSBE.Services.Implements;
using CSMS.Model.DTO.BaseFilterRequest;
using CSMS.Model;
using CSMSBE.Services.Implements;
using CSMS.Model.DTO.ModelDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CSMSBE.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly ILogger<ProjectController> _logger;
        private readonly ILogHistoryService _logHistoryService;
        private readonly IWorkerService _workerService;
        public ProjectController(IProjectService projectService, ILogger<ProjectController> logger, ILogHistoryService logHistoryService, IWorkerService workerService)
        {
            _projectService = projectService;
            _logger = logger;
            _logHistoryService = logHistoryService;
            _workerService = workerService;
        }
        // GET: api/<ProjectController>
        [HttpGet("GetLookup")]
        //[RequiresPermission(RoleHelper.Action.View, RoleHelper.Screen.Project)]
        public ActionResult<ResponseItem<IEnumerable<ProjectDTO>>> GetAllData()
        {
            try
            {
                var results = _projectService.GetLookupProject();
                //CreateLogHistory(ActionEnum.VIEW.GetHashCode(), "GetLookupProject");
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

        [HttpGet("Filter")]
        //[RequiresPermission(RoleHelper.Action.View, RoleHelper.Screen.Project)]
        public async Task<ActionResult<ResponseItem<IPagedList<ProjectDTO>>>> GetFilteredData([FromQuery] ProjectFilterRequest filter)
        {
            try
            {
                filter.ValidateInput();
                var results = await _projectService.FilterProject(filter);
                //CreateLogHistory(ActionEnum.VIEW.GetHashCode(), "FilterProject");
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

        // GET api/<ProjectController>/5
        [HttpGet("GetById/{id}")]
        //[RequiresPermission(RoleHelper.Action.View, RoleHelper.Screen.Project)]
        public async Task<ActionResult<ResponseItem<ProjectDTO>>> Get(string id)
        {
            try
            {
                var result = _projectService.GetProjectById(id);
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

        // POST api/<ProjectController>
        [HttpPost("Create")]
        //[RequiresPermission(RoleHelper.Action.Create, RoleHelper.Screen.Project)]
        public async Task<ActionResult<ResponseItem<ProjectDTO>>> CreateProject(CreateProjectDTO dto)
        {
            try
            {
                dto.ValidateInput();
                var createResult = await _projectService.CreateProject(dto);
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

        // PUT api/<ProjectController>/5
        [HttpPut("Update")]
        //[RequiresPermission(RoleHelper.Action.Update, RoleHelper.Screen.Project)]
        public async Task<ActionResult<ResponseItem<ProjectDTO>>> Put([FromBody] UpdateProjectDTO updateData)
        {
            try
            {
                updateData.ValidateInput();
                var updateResult = _projectService.UpdateProject(updateData);
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

        // DELETE api/<ProjectController>/5
        [HttpDelete("Remove/{id}")]
        //[RequiresPermission(RoleHelper.Action.Delete, RoleHelper.Screen.Project)]
        public async Task<ActionResult<ResponseItem<bool>>> Delete(int id)
        {
            try
            {
                var result = _projectService.RemoveProject(id);
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
