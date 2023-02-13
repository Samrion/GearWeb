using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gear.Models.Editors
{
    public class TextBox : GearEditor<string>
    {
        public string Value { get; set; } = string.Empty;
    }
}
