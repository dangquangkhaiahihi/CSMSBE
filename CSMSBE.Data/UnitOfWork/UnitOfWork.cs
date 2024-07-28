using CSMS.Data.Implements;
using CSMS.Data.Interfaces;
using CSMS.Entity;
using Microsoft.EntityFrameworkCore.Storage;

namespace CSMS.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<bool> CompleteAsync();

        bool Complete();

        IDbContextTransaction BeginTransaction();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly CsmsDbContext _context;
        private readonly Lazy<IPushNotificationRepository> _pushNotificationRepository;

        public UnitOfWork(CsmsDbContext context)
        {
            _context = context;
            _pushNotificationRepository = new Lazy<IPushNotificationRepository>(() => new PushNotificationRepository(context));
        }

        public IPushNotificationRepository PushNotificationRepository => _pushNotificationRepository.Value;

        public async Task<bool> CompleteAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool Complete()
        {
            return _context.SaveChanges() > 0;
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }
    }
}
