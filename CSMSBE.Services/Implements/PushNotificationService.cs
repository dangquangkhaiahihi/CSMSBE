using System.Reactive;
using AutoMapper;
using CSMS.Data.Extensions;
using CSMS.Data.Interfaces;
using CSMS.Data.UnitOfWork;
using CSMSBE.Services.Interfaces;
using CSMSBE.Services.PushNotification;
using Microsoft.Extensions.Logging;

namespace CSMSBE.Services.Implements;

public class PushNotificationService : IPushNotificationService
{
    private readonly IPushNotificationRepository _pushNotificationRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<PushNotificationService> _logger;

    public PushNotificationService(IPushNotificationRepository pushNotificationRepository, IMapper mapper, IUnitOfWork unitOfWork, ILogger<PushNotificationService> logger)
    {
        _pushNotificationRepository = pushNotificationRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<Result<IEnumerable<PushNotificationDto>>>  GetListNotificationsByUserId(string userId)
    {
        var notificationList = await _pushNotificationRepository.GetListNotificationsByUserIdAsync(userId, trackchanges: false);
        
        return Result<IEnumerable<PushNotificationDto>>.Success(_mapper.Map<IEnumerable<PushNotificationDto>>(notificationList));
    }

    public async Task<Result<PushNotificationDto>> GetNotificationById(Guid id)
    {
        var notification = await _pushNotificationRepository.GetNotificationByIdAsync(id, trackchanges: false);

        return Result<PushNotificationDto>.Success(_mapper.Map<PushNotificationDto>(notification));
    }

    public async Task<Result<string>> MarkAsRead(Guid id)
    {
        await _pushNotificationRepository.MarkAsReadAsync(id);
        
        var isSavedSuccess  = await _unitOfWork.CompleteAsync();
        
        if (!isSavedSuccess)
        {
            _logger.LogError(@"Failed to mark notification with id:{id} as read", id);
            return Result<string>.Failure($"Failed to mark notification with id: {id} as read.");
        }
        
        return Result<string>.Success($"Marked the notification with id: {id} as read successfully.");

    }
}