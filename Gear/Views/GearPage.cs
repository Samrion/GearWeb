using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gear.Views
{

    public abstract class GearPage<T> : RazorPage<T>
    {
        public GearPage()
        {
            Debug.WriteLine("XD");
        }
    }
}
