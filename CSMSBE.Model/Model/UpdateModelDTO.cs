﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSMS.Model.Model
{
    public class UpdateModelDTO
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public int? Level { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public string? ProjectID { get; set; }
        public void ValidateInput() { }
    }
}
