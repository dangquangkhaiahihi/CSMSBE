using CSMS.Data.Interfaces;
using CSMS.Data.Repository;
using CSMS.Entity;
using CSMS.Entity.Notification;
using Microsoft.EntityFrameworkCore;

namespace CSMS.Data.Implements;

public class PushNotificationRepository : BaseRepository<PushNotification>, IPushNotificationRepository
{
    public PushNotificationRepository(CsmsDbContext context) : base(context)
    {
    }

    public async Task AddNotificationAsync(PushNotification pushNotification)
    {
        await InsertAsync(pushNotification);
    }

    public async Task<IEnumerable<PushNotification>> GetNotificationsByUserIdAsync(string appUserId, bool trackChanges)
    {
        var query = Query(n => n.AppUserId.Equals(appUserId));

        if (!trackChanges)
        {
            return await query.AsNoTracking().ToListAsync();
        }

        return await query.ToListAsync();
    }

    public async Task<PushNotification?> GetNotificationByIdAsync(Guid id, bool trackChanges)
    {
        return await FindFirstOrDefaultAsync(n => n != null 
                                                  && n.Id.Equals(id), trackChanges);
    }

    public async Task MarkAsReadAsync(Guid id)
    {
        var notification = await FindFirstOrDefaultAsync(n => n != null 
                                                              && n.Id.Equals(id), trackChanges: true);

        if (notification != null)
        {
            notification.IsRead = true;
        }
    }
}