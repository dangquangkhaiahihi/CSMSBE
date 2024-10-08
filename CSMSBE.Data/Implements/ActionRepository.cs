﻿using CSMS.Data.Interfaces;
using CSMS.Data.Repository;
using CSMS.Entity;
using CSMS.Entity.SecurityMatrix;
using CSMS.Model.DTO.BaseFilterRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMS.Data.Implements
{
    public class ActionRepository : BaseRepository<Entity.SecurityMatrix.Action>, IActionRepository
    {
        private readonly CsmsDbContext _context;
        public ActionRepository(CsmsDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Entity.SecurityMatrix.Action> GetLookUpAction(IKeywordDto keywordDto)
        {
            try
            {
                IQueryable<Entity.SecurityMatrix.Action> query = null;
                if (string.IsNullOrEmpty(keywordDto.Keyword))
                {
                    query = _context.Action;
                    return query;
                }
                query = _context.Action.Where(x => x.Name.ToLower().Contains(keywordDto.Keyword.ToLower()));
                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
