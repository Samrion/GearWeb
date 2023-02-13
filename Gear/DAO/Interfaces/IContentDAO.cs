using Gear.Models;
using Gear.Models.Editors;

namespace Gear.DAO.Interfaces
{
    public interface IContentDAO
    {
        public GearPageModel? GetPageModelById(int id);
        public IEnumerable<GearPageModel> GetPageModels();
        public IEnumerable<UserModelProperty> GetUserModelPropertiesById(int id);
        
    }
}
