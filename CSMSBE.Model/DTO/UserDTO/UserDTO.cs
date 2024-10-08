﻿using CSMS.Entity;
using CSMS.Model.SecurityMatrix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMS.Model.DTO.UserDTO
{
    public class UserDTO : BaseFullAuditedEntity<string>
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool? Gender { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        //public string Avatar { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }      
        public string PhoneNumber { get; set; }
        public string UserType { get; set; }
        public string LastDateLogin { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public List<ScreenViewDTO> Screens { get; set; }
    }
}
