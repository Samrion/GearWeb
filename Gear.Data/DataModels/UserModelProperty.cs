﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gear.Data.DataModels
{
    public class UserModelProperty
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int UserModelID { get; set; }
    }
}
