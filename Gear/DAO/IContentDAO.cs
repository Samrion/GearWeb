using Gear.Models;

namespace Gear.DAO
{
    public interface IContentDAO
    {
        public Type GetModelType(GearModel model);

        public GearPageModel<object> GetPageModelForUrl(string url);
    }
}
