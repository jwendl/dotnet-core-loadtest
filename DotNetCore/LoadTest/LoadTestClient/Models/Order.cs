﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace LoadTest.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    public partial class Order
    {
        /// <summary>
        /// Initializes a new instance of the Order class.
        /// </summary>
        public Order() { }

        /// <summary>
        /// Initializes a new instance of the Order class.
        /// </summary>
        public Order(DateTime? orderDate = default(DateTime?), IList<OrderItem> orderItems = default(IList<OrderItem>))
        {
            OrderDate = orderDate;
            OrderItems = orderItems;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "orderDate")]
        public DateTime? OrderDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "orderItems")]
        public IList<OrderItem> OrderItems { get; set; }

    }
}