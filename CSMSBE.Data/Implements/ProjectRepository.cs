using AutoMapper;
using CSMS.Data.Interfaces;
using CSMS.Entity.CSMS_Entity;
using CSMS.Entity;
using CSMS.Model.DTO.FilterRequest;
using CSMS.Model.DTO.ProjectDTO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSMSBE.Core.Helper;
using Microsoft.EntityFrameworkCore;

namespace CSMS.Data.Implements
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly CsmsDbContext _context;
        private readonly ILogger<ProjectRepository> _logger;
        private readonly IMapper _mapper;
        public ProjectRepository(CsmsDbContext context, ILogger<ProjectRepository> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Project> Create(CreateProjectDTO dto)
        {
            try
            {
                var projectEntity = _mapper.Map<Project>(dto);
                string speckleProjectId = await SpeckleHelper.CreateStream(dto.Name, dto.Description, dto.IsPublic);
                if(string.IsNullOrEmpty(speckleProjectId)) {
                    throw new Exception("Có lỗi xảy ra trong khi tạo dự án!");
                }
                else
                {
                    projectEntity.SpeckleProjectId = speckleProjectId;
                }
                projectEntity.Id = Guid.NewGuid().ToString();
                projectEntity.SetDefaultValue("ADMIN");
                projectEntity.SetValueUpdate("ADMIN");
                var result = _context.Projects.Add(projectEntity);
                _context.SaveChanges();
                return result.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public async Task<Project> Get(string id)
        {           
            try
            {
                var result = await _context.Projects
                    .Include(p => p.Models.Where(m => m.IsDelete == false))
                    .FirstOrDefaultAsync(x => x.Id.Equals(id));
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public IQueryable<Project> GetAll()
        {
            try
            {
                var result = _context.Projects.AsQueryable();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public IQueryable<Project> GetAll(ProjectFilterRequest filter)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Remove(int id)
        {
            try
            {
                var entity = _context.Projects.FirstOrDefault(x => x.Id.Equals(id));
                if (entity == null)
                {
                    return false;
                }
                entity.IsDelete = true;
                var result = await SpeckleHelper.DeleteStream(entity.SpeckleProjectId);
                if (!result)
                {
                    throw new Exception("Xóa speckle project thất bại");
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

        public async Task<Project> Update(UpdateProjectDTO updateDto)
        {
            try
            {
                var entity = _context.Projects.Find(updateDto.Id);

                if (entity == null)
                {
                    throw new ArgumentException("Không tìm thấy bản ghi để cập nhật");
                }

                // Update fields
                _context.Entry(entity).CurrentValues.SetValues(updateDto);
                var result = await SpeckleHelper.UpdateStream(entity.SpeckleProjectId, updateDto.Name, updateDto.IsPublic, updateDto.Description);
                if (!result)
                {
                    throw new Exception("Cập nhật speckle project thất bại");
                }
                entity.SetValueUpdate("ADMIN");
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
