﻿using Bogus;
using LoadTest.Models;
using Microsoft.VisualStudio.TestTools.WebTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LoadTest.WebTests
{
    public class CreateWebTest
        : WebTest
    {
        public CreateWebTest()
        {
            PreAuthenticate = true;
            Proxy = "default";
        }

        public override IEnumerator<WebTestRequest> GetRequestEnumerator()
        {
            var webTestRequest = new WebTestRequest("http://jwdotnetcore.azurewebsites.net/api/customers")
            {
                Method = "POST"
            };

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
    }
}
