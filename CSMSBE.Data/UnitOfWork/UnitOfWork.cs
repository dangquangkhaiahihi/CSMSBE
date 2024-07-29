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

        public UnitOfWork(CsmsDbContext context)
        {
            _context = context;
        }
        
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
