using Microsoft.Azure.Documents.Client;
using StackExchange.Redis;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ResetTestScript
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var endpoint = new Uri("https://jwdotnetcore.documents.azure.com/");
            var authKey = "X7Bw3Mdyo8U2pH9UpxiWxjXJUeDVaWCORiFr6ZFCSwBFpCbctI2x8wkPsNuf7zl3wHiYc4jGLGxBex6pfAo9Lg==";
            var documentClient = new DocumentClient(endpoint, authKey);
            var databaseUri = UriFactory.CreateDatabaseUri("ContosoDatabase");
            await documentClient.DeleteDatabaseAsync(databaseUri);

            var lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                var configurationOptions = ConfigurationOptions.Parse("jwdotnetcache.redis.cache.windows.net:6380,password=cxJ/LWPMTH5M967HLQxDIopeormW2yNQJnTn9KBs8IA=,ssl=True,abortConnect=False");
                configurationOptions.AllowAdmin = true;
                return ConnectionMultiplexer.Connect(configurationOptions);
            });

            var connection = lazyConnection.Value;
            var redisEndpoint = connection.GetEndPoints().FirstOrDefault();
            var server = connection.GetServer(redisEndpoint);
            await server.FlushAllDatabasesAsync();

            var webClient = new WebClient();
            var result = await webClient.DownloadStringTaskAsync(new Uri("https://jwdotnetcore.azurewebsites.net/api/setup"));
        }
    }
}
