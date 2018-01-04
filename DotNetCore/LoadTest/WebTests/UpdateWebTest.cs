using Bogus;
using LoadTest.Models;
using Microsoft.VisualStudio.TestTools.WebTesting;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Order = LoadTest.Models.Order;

namespace LoadTest.WebTests
{
    public class UpdateWebTest
        : WebTest
    {
        private readonly Lazy<ConnectionMultiplexer> lazyConnection;

        public UpdateWebTest()
        {
            lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect("jwdotnetcache.redis.cache.windows.net:6380,password=cxJ/LWPMTH5M967HLQxDIopeormW2yNQJnTn9KBs8IA=,ssl=True,abortConnect=False");
            });

            PreAuthenticate = true;
            Proxy = "default";
        }

        public override IEnumerator<WebTestRequest> GetRequestEnumerator()
        {
            var connection = lazyConnection.Value;
            var redisCache = connection.GetDatabase();
            var endpoint = connection.GetEndPoints().FirstOrDefault();

            var keys = connection.GetServer(endpoint).Keys();
            var randomId = keys.OrderBy(k => Guid.NewGuid()).FirstOrDefault();
            var randomState = redisCache.StringGet(randomId);

            var uri = new Uri($"http://jwdotnetcore.azurewebsites.net/api/customers/{randomState}/{randomId}");
            var webClient = new WebClient();
            var json = webClient.DownloadString(uri);
            var customer = JsonConvert.DeserializeObject<Customer>(json);

            var orderItem = new Faker<OrderItem>()
                .RuleFor(oi => oi.SerialNumber, p => p.Finance.Iban())
                .RuleFor(oi => oi.Title, p => p.Commerce.Product())
                .RuleFor(oi => oi.Description, p => p.Lorem.Sentences(5))
                .RuleFor(oi => oi.Cost, p => p.Random.Double(1, 100))
                .RuleFor(oi => oi.Quantity, p => p.Random.Int(1, 10));

            var order = new Faker<Order>()
                .RuleFor(oi => oi.OrderDate, p => p.Date.Between(DateTime.Now.AddYears(-1), DateTime.Now))
                .RuleFor(oi => oi.OrderItems, (faker) =>
                {
                    return orderItem.Generate(faker.Random.Int(1, 100));
                });

            customer.Orders = order.Generate(10);
            var webTestRequest = new WebTestRequest($"http://jwdotnetcore.azurewebsites.net/api/customers/{randomId}")
            {
                Method = "PUT",
            };

            var newJson = JsonConvert.SerializeObject(customer);
            var body = new StringHttpBody
            {
                ContentType = "application/json",
                InsertByteOrderMark = false,
                BodyString = newJson,
            };

            webTestRequest.Body = body;

            yield return webTestRequest;
            webTestRequest = null;
        }
    }
}
