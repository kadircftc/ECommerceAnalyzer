﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime FetchDate { get; set; }
    }
}
