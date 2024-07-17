using CSMS.Model.DTO.BaseFilterRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMS.Model.DTO.FilterRequest
{
    public class ProjectFilterRequest : PagedAndSortResultRequestDto
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int? CommuneId { get; set; }
        public int? DistrictId { get; set; }
        public int? ProvinceId { get; set; }
        public string? Status { get; set; }
        public int? TypeProjectId { get; set; }
        public string? Desc { get; set; }
        public string? Role { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public void ValidateInput()
        {

        }
    }
}
