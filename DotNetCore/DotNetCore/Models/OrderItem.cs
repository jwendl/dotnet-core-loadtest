using Newtonsoft.Json;

namespace DotNetCore.Models
{
    public class OrderItem
    {
        [JsonProperty("serialNumber")]
        public string SerialNumber { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("cost")]
        public decimal Cost { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}
