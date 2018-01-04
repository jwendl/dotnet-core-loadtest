using Bogus;
using LoadTest.Models;
using Microsoft.VisualStudio.TestTools.WebTesting;
using Microsoft.VisualStudio.TestTools.WebTesting.Rules;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using Order = LoadTest.Models.Order;

namespace LoadTest.WebTests
{
    public class CreateWebTest
        : WebTest
    {
        private readonly Lazy<ConnectionMultiplexer> lazyConnection;

        public CreateWebTest()
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
            if (Context.ValidationLevel >= ValidationLevel.High)
            {
                var responseTimeValidationRule = new ValidationRuleRequestTime()
                {
                    MaxRequestTime = 1000,
                };

                ValidateResponse += new EventHandler<ValidationEventArgs>(responseTimeValidationRule.Validate);

                var responseTimeThresholdValidationRule = new ValidationRuleResponseTimeGoal()
                {
                    Tolerance = 15D,
                };

                ValidateResponseOnPageComplete += new EventHandler<ValidationEventArgs>(responseTimeThresholdValidationRule.Validate);
            }

            var webTestRequest = new WebTestRequest("http://jwdotnetcore.azurewebsites.net/api/customers")
            {
                Method = "POST",
            };
            webTestRequest.PostRequest += WebTestRequest_PostRequest;

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

            var address = new Faker<Address>()
                .RuleFor(a => a.AddressLine1, p => p.Address.StreetAddress())
                .RuleFor(a => a.AddressLine2, p => p.Address.BuildingNumber())
                .RuleFor(a => a.City, p => p.Address.City())
                .RuleFor(a => a.State, p => p.Address.StateAbbr())
                .RuleFor(a => a.ZipCode, p => p.Address.ZipCode());

            var customer = new Faker<Customer>()
                .RuleFor(c => c.FirstName, p => p.Name.FirstName())
                .RuleFor(c => c.LastName, p => p.Name.LastName())
                .RuleFor(c => c.BirthDate, p => p.Date.Between(DateTime.Now.AddYears(-80), DateTime.Now.AddYears(-18)))
                .RuleFor(c => c.Address, (faker) =>
                {
                    return address.Generate();
                })
                .RuleFor(c => c.Orders, (faker) =>
                {
                    return order.Generate(faker.Random.Int(1, 10));
                })
                .Generate();

            var json = JsonConvert.SerializeObject(customer);
            var body = new StringHttpBody
            {
                ContentType = "application/json",
                InsertByteOrderMark = false,
                BodyString = json,
            };

            webTestRequest.Body = body;

            yield return webTestRequest;
            webTestRequest = null;
        }

        private async void WebTestRequest_PostRequest(object sender, PostRequestEventArgs e)
        {
            var connection = lazyConnection.Value;
            var redisCache = connection.GetDatabase();

            var json = e.Response.BodyString;
            var customer = JsonConvert.DeserializeObject<Customer>(json);

            await redisCache.StringSetAsync(customer.Id, customer.Address.State);
        }
    }
}
