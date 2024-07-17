using CSMS.Data.Interfaces;
using CSMS.Entity;
using CSMS.Entity.IdentityAccess;
using CSMS.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSMS.Model.DTO.BaseFilterRequest;
using AutoMapper;
using Microsoft.Extensions.Logging;
using CSMS.Entity.CSMS_Entity;
using CSMS.Model.Role;
using CSMS.Model.User;

namespace CSMS.Data.Implements
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        private readonly csms_dbContext _context;
        private readonly ILogger<RoleRepository> _logger;
        private readonly IMapper _mapper;
        public RoleRepository(csms_dbContext context, ILogger<RoleRepository> logger, IMapper mapper) : base(context)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public Role Create(CreateRoleDTO dto)
        {
            try
            {
                var roleEntity = _mapper.Map<Role>(dto);
                var mappedEntity = _mapper.Map<Role>(roleEntity);
                mappedEntity.Id = Guid.NewGuid().ToString();
                mappedEntity.CreatedBy = "Admin";
                mappedEntity.ModifiedBy = "Admin";
                mappedEntity.CreatedDate = DateTime.Now;
                mappedEntity.ModifiedDate = DateTime.Now;
                mappedEntity.NormalizedName = mappedEntity.Name.ToUpper();

                var result = _context.Role.Add(mappedEntity);
                _context.SaveChanges();
                return result.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public Role Get(string id)
        {
            try
            {
                var result = _context.Role.FirstOrDefault(x => x.Id == id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public IQueryable<Role> GetLookupRole(IKeywordDto keywordDto)
        {
            try
            {
                IQueryable<Role> query = null;
                if (string.IsNullOrEmpty(keywordDto.Keyword))
                {
                    query = _context.Role;
                    return query;
                }
                query = _context.Role.Where(x => x.Name.ToLower().Contains(keywordDto.Keyword.ToLower()));
                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Remove(string id)
        {
            try
            {
                var entity = _context.Role.FirstOrDefault(x => x.Id == id);
                if (entity == null)
                {
                    return false;
                }

                var userRoles = _context.UserRoles.Where(ur => ur.RoleId == id).ToList();
                _context.UserRoles.RemoveRange(userRoles);

                _context.SaveChanges();

                _context.Role.Remove(entity);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

        public Role Update(UpdateRoleDTO dto)
        {
            try
            {
                var entity = _context.Role.Find(dto.Id);

                if (entity == null)
                {
                    throw new ArgumentException("Không tìm thấy bản ghi để cập nhật");
                }

                // Update fields
                entity.NormalizedName = dto.Name.ToUpper();
                entity.ModifiedDate = DateTime.Now;
                _context.Entry(entity).CurrentValues.SetValues(dto);

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
