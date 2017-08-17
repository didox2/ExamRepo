namespace Academy.Models.Contracts
{
    public interface ILectureResource : IResourceType
    {
        string Name { get; set; }

        string Url { get; set; }
    }
}
