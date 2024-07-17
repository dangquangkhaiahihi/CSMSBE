using CSMS.Entity.IdentityAccess;
using CSMSBE.Core.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMS.Entity.Issues
{
    [Table(TableFieldNameHelper.CSMS.Comment, Schema = Constant.Schema.CSMS)]
    public class Comment : BaseFullAuditedEntity<int>
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int IssueId { get; set; }
        public string UserId { get; set; }

        public virtual Issue Issues { get; set; }
        public virtual User User { get; set; }
    }
}
