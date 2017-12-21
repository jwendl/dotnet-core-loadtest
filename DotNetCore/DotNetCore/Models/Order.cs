using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DotNetCore.Models
{
    public class Order
    {
        [JsonProperty("orderDate")]
        public DateTime OrderDate { get; set; }

        [JsonProperty("orderItems")]
        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}
