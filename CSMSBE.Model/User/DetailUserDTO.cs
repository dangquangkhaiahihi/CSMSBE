using CSMS.Model.SecurityMatrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMS.Model.User
{
    public class DetailUserDTO
    {
        public string Id { set; get; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool? Gender { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string Avatar { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }        
        public string PhoneNumber { get; set; }
        //public Files Files { get; set; }
        public string UserType { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public List<ScreenViewDTO> Screens { get; set; }
        public string LastDateLogin { get; set; }
        public string DeviceStatus { get; set; }
    }

    //public class Files
    //{
    //    public string fileName { get; set; }
    //    public string filePreview { get; set; }
    //    public string fileType { get; set; }
    //    public long fileSize { get; set; }
    //    public long? fileId { get; set; }
    //}
    public class DetailUserCmsModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool? Gender { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public string PhoneNumber { get; set; }
        public string PC07LocalName { set; get; }
        public string PC07LocalCode { set; get; }
        public long pc07Id { set; get; }
        public bool IsUse2FA { set; get; }
    }
    public class UpdateUserCmsDto
    {
        public string Id { set; get; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}

