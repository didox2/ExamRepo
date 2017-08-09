using Academy.Models.Enums;
using System;

namespace Academy.Models.Resource
{
    public class VideoResource : LectureResource
    {
        private DateTime uploadedOn;
        public VideoResource(string name, string url, ResourceType type, DateTime uploadedOn) : base(name, url, type)
        {
            this.UploadedOn = uploadedOn;
        }

        public DateTime UploadedOn
        {
            get
            {
                return this.uploadedOn;
            }
            set
            {
                this.uploadedOn = value;
            }
        }
        public override string ToString()
        {
            return base.ToString() + $"\n     - Uploaded on: {this.UploadedOn}";
        }
    }
}
