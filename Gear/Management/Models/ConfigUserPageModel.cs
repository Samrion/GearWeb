using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gear.Management.Models
{
    public class ConfigUserPageModel
    {
        //Page info
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }

        //Template info

        public string TemplateName { get; set; }
        public string TemplateModelName { get; set; }

        //User model info
        public List<ConfigUserModelProperty> UserProperties { get; set; }
    }
}
