﻿using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CSMSBE.Services
{
    public abstract class BaseModel
    {
        [JsonProperty("created_by")]
        public string CreatedBy { get; set; }

        [JsonPropertyAttribute("created_date")]
        public DateTime CreatedDate { get; set; }

        [JsonPropertyAttribute("modified_by")]
        public string ModifiedBy { get; set; }

        [JsonPropertyAttribute("modified_date")]
        public DateTime ModifiedDate { get; set; }
    }
}
