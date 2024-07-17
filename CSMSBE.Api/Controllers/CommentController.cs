using AutoMapper;
using CSMS.Model.DTO.IssueDTO;
using CSMS.Model.Issue;
using CSMSBE.Core.Helper;
using CSMSBE.Core.Resource;
using CSMSBE.Core;
using CSMSBE.Services.Implements;
using CSMSBE.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSMSBE.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        private readonly IWorkerService _workerService;
        public CommentController(ICommentService commentService, IMapper mapper, IWorkerService workerService)
        {
            _commentService = commentService;
            _mapper = mapper;
            _workerService = workerService;
        }
        [HttpPost("Create")]
        //[RequiresPermission(RoleHelper.Action.Create, RoleHelper.Screen.Project)]
        public ActionResult<ResponseItem<CommentDTO>> CreateComment(CreateCommentDTO dto)
        {
            try
            {
                dto.ValidateInput();
                var userId = _workerService.GetCurrentUser().Id;
                var createResult = _commentService.CreateComment(dto, userId);
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
        public ActionResult<ResponseItem<CommentDTO>> Put([FromBody] UpdateCommentDTO updateData)
        {
            try
            {
                updateData.ValidateInput();
                var userId = _workerService.GetCurrentUser().Id;

                var updateResult = _commentService.UpdateComment(updateData, userId);
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
                var result = _commentService.RemoveComment(id);
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
