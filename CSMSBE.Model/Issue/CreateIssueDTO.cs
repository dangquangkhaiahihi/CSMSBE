using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMS.Model.Issue
{
    public class CreateIssueDTO
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Status { get; set; }
        public string? Description { get; set; }
        public string? ProjectId { get; set; }
        public void ValidateInput() { }
    }
}
