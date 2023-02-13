using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gear.Models.Editors
{
    public abstract class GearEditor
    {
        public int ModelId { get; set; }
        public string Name { get; set; }

    }
    public abstract class GearEditor<T> : GearEditor
    {
        public T Value { get; set; }
    }
}
