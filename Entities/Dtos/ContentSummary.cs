﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ContentSummary
    {
        [JsonProperty("totalCommentCount")]
        public int CommentCount { get; set; }
        [JsonProperty("tags")]
        public List<ContentSummaryTag> Tags { get; set; }
    }
}
