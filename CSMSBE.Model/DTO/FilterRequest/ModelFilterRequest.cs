using CSMS.Model.DTO.BaseFilterRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMS.Model.DTO.FilterRequest
{
    public class ModelFilterRequest : PagedAndSortResultRequestDto
    {
        public string? Name { get; set; }
        public int? Level { get; set; }
        public string? Description { get; set; }
        public string? SpeckleBranchId { get; set; }
        public string? Type { get; set; }
        public string? ProjectID { get; set; }
        public string? ProjectName { set; get; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public void ValidateInput()
        {

        }
    }
}
