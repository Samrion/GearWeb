﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gear.Models
{
    public class GearPageModel : GearModel
    {
        public string? Url { get; set; }        
        public string? Title { get; set; }
        public GearPageModel? Ancestor { get; set; }
        public List<GearPageModel>? Descendants { get; set; }
    }
}
