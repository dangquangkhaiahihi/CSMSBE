using CSMS.Data.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CSMSBE.Api.Controllers;

public class BaseController : ControllerBase
{
    [NonAction]
    protected IActionResult HandleResult<T>(Result<T> result, string routeName = null, object routeValues = null)
    {
        if (result == null)
        {
            return NotFound();
        }

        if (!result.IsSuccess)
        {
            return BadRequest(result.ErrorMessage);
        };
        
        if (result.Value == null)
        {
            return NotFound();
        }

        if (string.IsNullOrEmpty(routeName))
        {
            return Ok(result.Value);
        }

        return CreatedAtRoute(routeName, routeValues, result.Value);

    }

}