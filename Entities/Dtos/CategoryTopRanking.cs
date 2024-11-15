﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class CategoryTopRanking
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("order")]
        public string Order { get; set; }

    }
}
