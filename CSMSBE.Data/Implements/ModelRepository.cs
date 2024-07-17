using AutoMapper;
using CSMS.Data.Interfaces;
using CSMS.Data.Repository;
using CSMS.Entity;
using CSMS.Entity.CSMS_Entity;
using CSMS.Entity.Issues;
using CSMS.Model.DTO.BaseFilterRequest;
using CSMS.Model.DTO.ModelDTO;
using CSMS.Model.Model;
using CSMSBE.Core.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMS.Data.Implements
{
    public class ModelRepository : BaseRepository<Entity.CSMS_Entity.Model>, IModelRepository
    {
        private readonly csms_dbContext _context;
        private readonly ILogger<ModelRepository> _logger;
        private readonly IMapper _mapper;
        public ModelRepository(csms_dbContext context, ILogger<ModelRepository> logger, IMapper mapper) : base(context)
        {
            _context = context; 
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Entity.CSMS_Entity.Model> Create(CreateModelDTO dto, string userId)
        {
            try
            {
                var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();               
                if (user == null)
                {
                    throw new ArgumentException("User không tồn tại!"); ;
                }

                var project = _context.Projects.Where(p => p.Id == dto.ProjectID).FirstOrDefault();
                if (project == null)
                {
                    throw new ArgumentException("Project không tồn tại!"); ;
                }
                var modelEntity = _mapper.Map<Entity.CSMS_Entity.Model>(dto);
                string speckleBarnchId = await SpeckleHelper.CreateBranch(dto.Name, project.SpeckleProjectId, dto.Description );
                if (string.IsNullOrEmpty(speckleBarnchId))
                {
                    throw new Exception("Có lỗi xảy ra trong khi tạo nhánh!");
                }
                else
                {
                    modelEntity.SpeckleBranchId = speckleBarnchId;
                }
                modelEntity.Id = Guid.NewGuid().ToString();
                modelEntity.SetDefaultValue(user.UserName);
                modelEntity.SetValueUpdate(user.UserName);

                var result = _context.Models.Add(modelEntity);
                _context.SaveChanges();
                return result.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public Entity.CSMS_Entity.Model Get(string id)
        {           
            try
            {

                var result = _context.Models
                  .Include(i => i.Project)
                  .FirstOrDefault(x => x.Id == id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public IQueryable<Entity.CSMS_Entity.Model> GetLookupModel(IKeywordDto keywordDto)
        {
            try
            {
                IQueryable<Entity.CSMS_Entity.Model> query = null;
                if (string.IsNullOrEmpty(keywordDto.Keyword))
                {
                    query = _context.Models.Where(i => i.IsDelete == false);
                    return query;
                }              
                query = _context.Models.Where(x => x.Name.ToLower().Contains(keywordDto.Keyword.ToLower()) && x.IsDelete == false);
                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Remove(string id)
        {
            try
            {
                var entity = _context.Models.FirstOrDefault(x => x.Id.Equals(id));
                if (entity == null)
                {
                    return false;
                }
                entity.IsDelete = true;

                var project = _context.Projects.Where(p => p.Id == entity.ProjectID).FirstOrDefault();
                if (project == null)
                {
                    return false;
                }

                var result = await SpeckleHelper.DeleteBranch(entity.SpeckleBranchId, project.SpeckleProjectId);
                if (!result)
                {
                    throw new Exception("Xóa speckle branch thất bại");
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public async Task<Entity.CSMS_Entity.Model> Update(UpdateModelDTO updateDto, string userId)
        {
            try
            {
                var entity = _context.Models.Include(i => i.Project).FirstOrDefault(i => i.Id == updateDto.Id);
                if (entity == null)
                {
                    throw new ArgumentException("Không tìm thấy bản ghi để cập nhật");
                }

                var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();
                if (user == null)
                {
                    throw new ArgumentException("User không tồn tại!");
                }

                var project = _context.Projects.Where(p => p.Id == updateDto.ProjectID).FirstOrDefault();
                if (project == null)
                {
                    throw new ArgumentException("Project không tồn tại!");
                }

                _context.Entry(entity).CurrentValues.SetValues(updateDto);

                var result = await SpeckleHelper.UpdateBranch(entity.SpeckleBranchId, updateDto.Name, entity.Project.SpeckleProjectId , updateDto.Description);
                if (!result)
                {
                    throw new Exception("Cập nhật speckle branch thất bại");
                }
                entity.SetValueUpdate(user.UserName);

                await _context.SaveChangesAsync();

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
