using Academy.Models.Enums;

namespace Academy.Models.Resource
{
    public class PresentationResource : LectureResource
    {
        public PresentationResource(string name, string url, ResourceType type) : base(name, url, type)
        {
        }
    }
}
