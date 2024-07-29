using CSMSBE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CSMSBE.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PushNotificationController : BaseController
{
    private readonly IPushNotificationService _pushNotificationService;

    public PushNotificationController(IPushNotificationService pushNotificationService)
    {
        _pushNotificationService = pushNotificationService;
    }

    [HttpGet()]
    public async Task<IActionResult> GetListNotificationsByUserId(string userId)
    {
        return HandleResult(await _pushNotificationService.GetListNotificationsByUserId(userId));
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetNotificationById(Guid id)
    {
        return HandleResult(await _pushNotificationService.GetNotificationById(id));
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateProfile(Guid id)
    {
        return HandleResult(await _pushNotificationService.MarkAsRead(id));
    }

}