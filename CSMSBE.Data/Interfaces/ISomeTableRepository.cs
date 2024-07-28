using CSMS.Entity.CSMS_Entity;
using CSMS.Model.DTO.FilterRequest;

namespace CSMS.Data.Interfaces
{
    public interface ISomeTableRepository /*: IRepository<SomeTable, int>*/
    {
        SomeTable Create(SomeTable table);
        IQueryable<SomeTable> GetAll();
        SomeTable Get(int id);
        IQueryable<SomeTable> GetAll(SomeTableFilterRequest filter);
        SomeTable Update(SomeTable table);
        bool Remove(int id);
    }
}
