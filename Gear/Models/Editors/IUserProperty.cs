using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gear.Models.Editors
{


    public interface IUserProperty<T>
    {
        T Value { get; internal set; }
    }
}
