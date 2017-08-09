using Academy.Models.Contracts;
using Academy.Models.Enums;
using System;

namespace Academy.Models.Resource
{
    public abstract class LectureResource : ILectureResource
    {
        private string name;
        private string url;
        private readonly ResourceType resourceType;

        public LectureResource(string name, string url, ResourceType type)
        {
            this.Name = name;
            this.Url = url;
            this.resourceType = type;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3 || value.Length > 15)
                {
                    throw new ArgumentException("Resource name should be between 3 and 15 symbols long!");
                }
                this.name = value;
            }
        }
        public string Url
        {
            get
            {
                return this.url;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5 || value.Length > 150)
                {
                    throw new ArgumentException("Resource url should be between 5 and 150 symbols long!");
                }
                this.url = value;
            }
        }

        public ResourceType Type
        {
            get
            {
                return this.resourceType;
            }
        }

        public override string ToString()
        {
            return $"    * Resource:\n     - Name: {this.Name}\n     - Url: {this.Url}\n     - Type: {this.Type}";
        }
    }
}
