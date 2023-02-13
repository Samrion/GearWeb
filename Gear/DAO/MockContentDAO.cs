using Gear.Core;
using Gear.DAO.Interfaces;
using Gear.Models;
using Gear.Models.Editors;
using System.Diagnostics;

namespace Gear.DAO
{
    public class MockContentPageDAO : IContentDAO
    {
        List<GearPageModel> PageModels { get; set; } = new List<GearPageModel>()
        {
            new GearPageModel
            {
                Id = 1,
                TemplateName = "HomePage"
            },
            new GearPageModel
            {
                Id = 2,
                TemplateName = "Subpage"
            },
            new GearPageModel
            {
                Id = 3,
                TemplateName = "Subpage2"
            }
        };

        IEnumerable<UserModelProperty> UserModelProperties { get; set; } = new List<UserModelProperty>()
        {
            new UserModelProperty()
            {
                Id=1,
                ModelId=1,
                Name = "TestValue",
                Value = 420
            },
            new UserModelProperty()
            {
                Id=2,
                ModelId=1,
                Value = "test title",
                Name = "TestTitle"
            },
            new UserModelProperty()
            {
                Id=3,
                ModelId=1,
                Name = "AnotherTestValue",
                Value = 777
            },
            new UserModelProperty()
            {
                Id=4,
                ModelId = 2,
                Name = "SubpageTestVariable",
                Value = "subpageTest"
            },
            new UserModelProperty()
            {
                Id=5,
                ModelId = 2,
                Name = "SubpageTestVariable2",
                Value = "subpage test of test"
            },
            new UserModelProperty()
            {
                Id=4,
                ModelId = 3,
                Name = "SubpageTestVariable",
                Value = "subpageTest2"
            },
            new UserModelProperty()
            {
                Id=5,
                ModelId = 3,
                Name = "SubpageTestVariable2",
                Value = "subpage2 test of test"
            }

        };



        public GearPageModel? GetPageModelById(int id)
        {
            return PageModels.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<UserModelProperty> GetUserModelPropertiesById(int id)
        {
            return UserModelProperties.Where(x => x.ModelId == id);
        }

    }
}
