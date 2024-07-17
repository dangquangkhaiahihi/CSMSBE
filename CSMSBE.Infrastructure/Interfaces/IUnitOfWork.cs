﻿using System.Threading.Tasks;
using CSMS.Entity;

using Microsoft.EntityFrameworkCore.Storage;

namespace CSMSBE.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> CompleteAsync();

        bool Complete();

        IDbContextTransaction BeginTransaction();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly csms_dbContext _context;

        public UnitOfWork(csms_dbContext context)
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
