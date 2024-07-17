using CSMS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMS.Model.Role
{
    public class CreateRoleDTO
    {
        public string? Code { get; set; }
        public string? Name { get; set; }    
        public void ValidateInput() { }
    }
}
