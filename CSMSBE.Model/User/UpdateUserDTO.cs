using CSMSBE.Core.Enum;
using CSMSBE.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMS.Model.User
{
    public class UpdateUserDTO
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string RoleId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool? Gender { get; set; }
        public string Address { get; set; }
        //public string Avatar { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public RecordPermissionEnum RecordPermission { get; set; }
        public void ValidateInput()
        {
            try
            {
                if (!ValidationHelper.IsValidPhoneNumber(PhoneNumber))
                {
                    throw new InvalidOperationException("Phone number is invalid");
                }

                if (DateOfBirth != null && DateOfBirth > DateTime.Now)
                {
                    throw new InvalidOperationException("Date of birth cannot higher than date time now");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
