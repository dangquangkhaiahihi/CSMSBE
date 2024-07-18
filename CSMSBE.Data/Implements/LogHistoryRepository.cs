using CSMS.Data.Interfaces;
using CSMS.Data.Repository;
using CSMS.Entity;
using CSMS.Entity.LogHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMS.Data.Implements
{
    public class LogHistoryRepository : BaseRepository<LogHistoryEntity>, ILogHistoryRepository
    {
        public LogHistoryRepository(CsmsDbContext context) : base(context)
        {
        }
    }
}
