using Gear.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gear.DAO
{
    public class MockContentRouteDAO : IContentRouteProvider
    {
        public Dictionary<string, int> RouteTable { get; private set; } = new Dictionary<string, int>()
        {
            { @"/mainSite", 1},
            { @"/mainSite/testPage1", 2},
            { @"/mainSite/testPage2", 3},
            { @"/mainSite/testPage3", 4},
            { @"/mainSite/testPage4", 5},
        };
    }
}
