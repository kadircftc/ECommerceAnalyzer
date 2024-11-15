using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class TrendyolSocialProof
    {
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public object Error { get; set; }
        public Dictionary<string, ProductData> Result { get; set; }
    }
}
