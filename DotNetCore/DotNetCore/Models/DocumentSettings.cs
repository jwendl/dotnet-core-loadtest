using System;

namespace DotNetCore.Models
{
    public class DocumentSettings
    {
        public Uri DocumentEndpoint { get; set; }

        public string DocumentKey { get; set; }

        public string DatabaseId { get; set; }

        public string CollectionId { get; set; }
    }
}
