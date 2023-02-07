using Gear.Models;

namespace Gear.DAO
{
    public class ContentDAOMock : IContentDAO
    {

        List<GearPageModel<object>> PageModels { get; set; }

        public ContentDAOMock(List<GearPageModel<object>> mockModels)
        {
            PageModels = mockModels;
        }

        public Type GetModelType(GearModel model)
        {
            throw new NotImplementedException();
        }

        public GearPageModel<object>? GetPageModelForUrl(string url)
        {
            var pageModel = PageModels.Where(x => x.Url == url).FirstOrDefault();
            return pageModel;
        }
    }
}
