﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace LoadTest
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Models;

    /// <summary>
    /// Extension methods for LoadTestClient.
    /// </summary>
    public static partial class LoadTestClientExtensions
    {
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='partitionKey'>
            /// </param>
            public static IList<Customer> ApiCustomersGet(this ILoadTestClient operations, string partitionKey = default(string))
            {
                return Task.Factory.StartNew(s => ((ILoadTestClient)s).ApiCustomersGetAsync(partitionKey), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='partitionKey'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<Customer>> ApiCustomersGetAsync(this ILoadTestClient operations, string partitionKey = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiCustomersGetWithHttpMessagesAsync(partitionKey, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='customer'>
            /// </param>
            public static void ApiCustomersPost(this ILoadTestClient operations, Customer customer = default(Customer))
            {
                Task.Factory.StartNew(s => ((ILoadTestClient)s).ApiCustomersPostAsync(customer), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='customer'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task ApiCustomersPostAsync(this ILoadTestClient operations, Customer customer = default(Customer), CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.ApiCustomersPostWithHttpMessagesAsync(customer, null, cancellationToken).ConfigureAwait(false);
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='partitionKey'>
            /// </param>
            /// <param name='id'>
            /// </param>
            public static Customer ApiCustomersByPartitionKeyByIdGet(this ILoadTestClient operations, string partitionKey, string id)
            {
                return Task.Factory.StartNew(s => ((ILoadTestClient)s).ApiCustomersByPartitionKeyByIdGetAsync(partitionKey, id), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='partitionKey'>
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Customer> ApiCustomersByPartitionKeyByIdGetAsync(this ILoadTestClient operations, string partitionKey, string id, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiCustomersByPartitionKeyByIdGetWithHttpMessagesAsync(partitionKey, id, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='customer'>
            /// </param>
            public static void ApiCustomersByIdPut(this ILoadTestClient operations, string id, Customer customer = default(Customer))
            {
                Task.Factory.StartNew(s => ((ILoadTestClient)s).ApiCustomersByIdPutAsync(id, customer), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='customer'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task ApiCustomersByIdPutAsync(this ILoadTestClient operations, string id, Customer customer = default(Customer), CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.ApiCustomersByIdPutWithHttpMessagesAsync(id, customer, null, cancellationToken).ConfigureAwait(false);
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='partitionKey'>
            /// </param>
            public static void ApiCustomersByIdDelete(this ILoadTestClient operations, string id, string partitionKey = default(string))
            {
                Task.Factory.StartNew(s => ((ILoadTestClient)s).ApiCustomersByIdDeleteAsync(id, partitionKey), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='partitionKey'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task ApiCustomersByIdDeleteAsync(this ILoadTestClient operations, string id, string partitionKey = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.ApiCustomersByIdDeleteWithHttpMessagesAsync(id, partitionKey, null, cancellationToken).ConfigureAwait(false);
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static void ApiSetupGet(this ILoadTestClient operations)
            {
                Task.Factory.StartNew(s => ((ILoadTestClient)s).ApiSetupGetAsync(), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task ApiSetupGetAsync(this ILoadTestClient operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.ApiSetupGetWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false);
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static IList<string> ApiValuesGet(this ILoadTestClient operations)
            {
                return Task.Factory.StartNew(s => ((ILoadTestClient)s).ApiValuesGetAsync(), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<string>> ApiValuesGetAsync(this ILoadTestClient operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiValuesGetWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='value'>
            /// </param>
            public static void ApiValuesPost(this ILoadTestClient operations, string value = default(string))
            {
                Task.Factory.StartNew(s => ((ILoadTestClient)s).ApiValuesPostAsync(value), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='value'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task ApiValuesPostAsync(this ILoadTestClient operations, string value = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.ApiValuesPostWithHttpMessagesAsync(value, null, cancellationToken).ConfigureAwait(false);
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            public static string ApiValuesByIdGet(this ILoadTestClient operations, int id)
            {
                return Task.Factory.StartNew(s => ((ILoadTestClient)s).ApiValuesByIdGetAsync(id), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<string> ApiValuesByIdGetAsync(this ILoadTestClient operations, int id, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiValuesByIdGetWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='value'>
            /// </param>
            public static void ApiValuesByIdPut(this ILoadTestClient operations, int id, string value = default(string))
            {
                Task.Factory.StartNew(s => ((ILoadTestClient)s).ApiValuesByIdPutAsync(id, value), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='value'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task ApiValuesByIdPutAsync(this ILoadTestClient operations, int id, string value = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.ApiValuesByIdPutWithHttpMessagesAsync(id, value, null, cancellationToken).ConfigureAwait(false);
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            public static void ApiValuesByIdDelete(this ILoadTestClient operations, int id)
            {
                Task.Factory.StartNew(s => ((ILoadTestClient)s).ApiValuesByIdDeleteAsync(id), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task ApiValuesByIdDeleteAsync(this ILoadTestClient operations, int id, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.ApiValuesByIdDeleteWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false);
            }

    }
}
