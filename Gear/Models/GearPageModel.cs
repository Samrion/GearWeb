using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gear.Models
{
    public class GearPageModel
    {
        public string? Title { get; set; }
        public string? Url { get; set; }
        public string? PageViewName { get; set; }
        public GearPageModel<object>? Ancestor { get; set; }
        public List<GearPageModel<object>>? Descendants { get; set; }
    }


    public class GearPageModel<T> : GearPageModel where T : class
    {
        public T? UserPageModel { get; set; }     
    }
}
