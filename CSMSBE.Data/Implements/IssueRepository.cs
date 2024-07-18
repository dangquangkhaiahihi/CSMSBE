using AutoMapper;
using CSMS.Data.Interfaces;
using CSMS.Data.Repository;
using CSMS.Entity;
using CSMS.Entity.CSMS_Entity;
using CSMS.Entity.IdentityAccess;
using CSMS.Entity.Issues;
using CSMS.Model.DTO.BaseFilterRequest;
using CSMS.Model.DTO.IssueDTO;
using CSMS.Model.Issue;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMS.Data.Implements
{
    public class IssueRepository :  BaseRepository<Issue>, IIssueRepository
    {
        private readonly CsmsDbContext _context;
        private readonly ILogger<IssueRepository> _logger;
        private readonly IMapper _mapper;

        public IssueRepository(CsmsDbContext context, ILogger<IssueRepository> logger, IMapper mapper) : base(context)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public Issue Create(CreateIssueDTO dto, string userId)
        {
            try
            {
                var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();
                var project = _context.Projects.Where(p => p.Id == dto.ProjectId).FirstOrDefault();
                if (user == null || project == null)
                {
                    throw new ArgumentException("User hoặc project không tồn tại!"); ;
                }

                var issueEntity = _mapper.Map<Issue>(dto);
                issueEntity.SetDefaultValue(user.UserName);
                issueEntity.SetValueUpdate(user.UserName);
                issueEntity.UserId = userId;

                var result = _context.Issues.Add(issueEntity);
                _context.SaveChanges();
                return result.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public Issue Get(int id)
        {
            try
            {
                var result = _context.Issues
                  .Include(i => i.User)
                  .Include(i => i.Project)
                  .Include(i => i.Comments.Where(c => c.IsDelete == false))
                      .ThenInclude(c => c.User)
                  .FirstOrDefault(x => x.Id == id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public IQueryable<Issue> GetLookupIssue(IKeywordDto keywordDto)
        {
            try
            {
                IQueryable<Issue> query = null;
                if (string.IsNullOrEmpty(keywordDto.Keyword))
                {
                    query = _context.Issues.Where(i => i.IsDelete == false);
                    return query;
                }
                query = _context.Issues.Where(x => x.Name.ToLower().Contains(keywordDto.Keyword.ToLower()) && x.IsDelete == false);
                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Remove(int id)
        {
            try
            {
                var entity = _context.Issues.FirstOrDefault(x => x.Id.Equals(id));
                if (entity == null)
                {
                    return false;
                }
                entity.IsDelete = true;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public Issue Update(UpdateIssueDTO updateDto, string userId)
        {
            try
            {
                var entity = _context.Issues.Include(i => i.Project).FirstOrDefault(i => i.Id == updateDto.Id);

                var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();

                if (entity == null)
                {
                    throw new ArgumentException("Không tìm thấy bản ghi để cập nhật");
                }

                // Update fields
                entity.UserId = userId;
                
                _context.Entry(entity).CurrentValues.SetValues(updateDto);

                entity.SetValueUpdate(user.UserName);

                _context.SaveChanges();

                return entity;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }
    }
}
