using Microsoft.VisualStudio.TestTools.WebTesting;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoadTest.WebTests
{
    public class ReadWebTest
        : WebTest
    {
        private readonly Lazy<ConnectionMultiplexer> lazyConnection;

        public ReadWebTest()
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

            var webTestRequest = new WebTestRequest($"http://jwdotnetcore.azurewebsites.net/api/customers/{randomState}/{randomId}");

            yield return webTestRequest;
            webTestRequest = null;
        }
    }
}
