using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSMSBE.Core.Helper;
using CSMS.Entity.Issues;
using CSMS.Entity.Notification;

namespace CSMS.Entity.IdentityAccess
{
    [Table(TableFieldNameHelper.IdentityExtentions.AspNetUsers, Schema = "authentication")]
    public class User : IdentityUser<string>
    {
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool? Gender { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        [StringLength(Constant.Maxlength.UserType)]
        public string UserType { get; set; }
        [Column("SecretKey")]
        public string SecretKey { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; } = new List<UserRole>();
        public virtual ICollection<UserClaim> UserClaims { get; } = new List<UserClaim>();
        public virtual ICollection<UserLogin> UserLogins { get; } = new List<UserLogin>();
        public ICollection<Issue> Issues { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<PushNotification> PushNotifications { get; set; }
    }
}
