using CSMS.Data.Interfaces;
using CSMS.Data.Repository;
using CSMS.Entity;
using CSMS.Entity.CSMS_Entity;
using CSMS.Entity.SecurityMatrix;
using CSMS.Model.DTO.BaseFilterRequest;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMS.Data.Implements
{
    public class ScreenRepository : BaseRepository<Screen>, IScreenRepository
    {
        private readonly CsmsDbContext _context;
        public ScreenRepository(CsmsDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Screen> GetLookUpScreen(IKeywordDto keywordDto)
        {
            try
            {
                IQueryable<Screen> query = null;
                if (string.IsNullOrEmpty(keywordDto.Keyword))
                {
                    query = _context.Screen;
                    return query;
                }
                query = _context.Screen.Where(x => x.Name.ToLower().Contains(keywordDto.Keyword.ToLower()));
                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

