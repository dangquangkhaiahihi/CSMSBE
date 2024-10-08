using CSMS.Data.Interfaces;
using CSMS.Entity;
using CSMS.Entity.CSMS_Entity;
using CSMS.Model.DTO.FilterRequest;
using Microsoft.Extensions.Logging;

namespace CSMS.Data.Implements
{
    public class SomeTableRepository : ISomeTableRepository
    {
        private readonly CsmsDbContext _context;
        private readonly ILogger<SomeTableRepository> _logger;
        public SomeTableRepository(CsmsDbContext context, ILogger<SomeTableRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public SomeTable Create(SomeTable entity)
        {
            try
            {
                entity.SetDefaultValue("ADMIN");
                entity.SetValueUpdate("ADMIN");
                var result = _context.SomeTables.Add(entity);
                _context.SaveChanges();
                return result.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }


        public SomeTable Get(int id)
        {
            try
            {
                var result = _context.SomeTables.FirstOrDefault(x => x.Id == id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }
        public IQueryable<SomeTable> GetAll()
        {
            try
            {
                var result = _context.SomeTables.AsQueryable();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public IQueryable<SomeTable> GetAll(SomeTableFilterRequest filter)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            try
            {
                var entity = _context.SomeTables.FirstOrDefault(x => x.Id == id);
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

        public SomeTable Update(SomeTable updateData)
        {
            try
            {
                var entity = _context.SomeTables.Find(updateData.Id);

                if (entity == null)
                {
                    throw new ArgumentException("Không tìm thấy bản ghi để cập nhật");
                }

                // Update fields
                _context.Entry(entity).CurrentValues.SetValues(updateData);

                entity.SetValueUpdate("ADMIN");

                _context.SaveChanges();
                return entity;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        public List<SomeTable> UpdateMulti(List<SomeTable> listItem)
        {
            throw new NotImplementedException();
        }
    }
}
