using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gear.DAO.Interfaces
{
    public interface IContentRouteProvider
    {

        public Dictionary<string, int> RouteTable { get; }

    }
}
