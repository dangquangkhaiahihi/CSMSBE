using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMS.Model.Issue
{
    public class CreateCommentDTO
    {
        public string? Content { get; set; }
        public int? IssueId { get; set; }
        public void ValidateInput() { }
    }
}
