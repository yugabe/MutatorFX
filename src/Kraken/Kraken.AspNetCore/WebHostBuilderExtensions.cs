using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using static MutatorFX.ExceptionHandling.Assertions;
using MutatorFX.Coding;

namespace MutatorFX.Kraken.AspNetCore
{
    /// <summary>
    /// Contains extensions for configuring Kraken architecture application modules.
    /// </summary>
    public static class WebHostBuilderExtensions
    {
        /// <summary>
        /// Configures a Kraken module to be used for the current <paramref name="webHostBuilder"/>.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="IKrakenModule"/> to use. A new object will be instantiated.</typeparam>
        /// <param name="webHostBuilder">The <see cref="IWebHostBuilder"/> to use. Should not be null.</param>
        /// <returns>The <paramref name="webHostBuilder"/> instance after configured by the <see cref="IKrakenModule"/>.</returns>
        public static IWebHostBuilder UseKrakenModule<T>(this IWebHostBuilder webHostBuilder)
            where T : class, IKrakenModule, new()
            => webHostBuilder.UseKrakenModule<T, IWebHostBuilder>(new T());

        /// <summary>
        /// Configures a Kraken module to be used for the current <paramref name="webHostBuilder"/>.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="IKrakenModule"/> to use.</typeparam>
        /// <param name="webHostBuilder">The <see cref="IWebHostBuilder"/> to use. Should not be null.</param>
        /// <param name="krakenModule">The module to configure the builder with.</param>
        /// <returns>The <paramref name="webHostBuilder"/> instance after configured by the <see cref="IKrakenModule"/>.</returns>
        public static IWebHostBuilder UseKrakenModule<T>(this IWebHostBuilder webHostBuilder, T krakenModule)
            where T : class, IKrakenModule
            => UseKrakenModule<T, IWebHostBuilder>(webHostBuilder, krakenModule);

        /// <summary>
        /// Configures a Kraken module to be used for the current <paramref name="webHostBuilder"/>.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="IKrakenModule"/> to use. A new object will be instantiated.</typeparam>
        /// <typeparam name="TBuilder">The type of the builder. Should be inferred.</typeparam>
        /// <param name="webHostBuilder">The <see cref="IWebHostBuilder"/> to use. Should not be null.</param>
        /// <returns>The <paramref name="webHostBuilder"/> instance after configured by the <see cref="IKrakenModule"/>.</returns>
        public static TBuilder UseKrakenModule<T, TBuilder>(this TBuilder webHostBuilder) 
            where T : class, IKrakenModule, new()
            where TBuilder : IWebHostBuilder
            => webHostBuilder.UseKrakenModule(new T());

        /// <summary>
        /// Configures a Kraken module to be used for the current <paramref name="webHostBuilder"/>.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="IKrakenModule"/> to use.</typeparam>
        /// <typeparam name="TBuilder">The type of the builder. Should be inferred.</typeparam>
        /// <param name="webHostBuilder">The <see cref="IWebHostBuilder"/> to use. Should not be null.</param>
        /// <param name="krakenModule">The module to configure the builder with.</param>
        /// <returns>The <paramref name="webHostBuilder"/> instance after configured by the <see cref="IKrakenModule"/>.</returns>
        public static TBuilder UseKrakenModule<T, TBuilder>(this TBuilder webHostBuilder, T krakenModule) 
            where T : class, IKrakenModule
            where TBuilder : IWebHostBuilder
            => EnsureNoneNull(new { webHostBuilder, krakenModule }).webHostBuilder.Do(builder =>
                  builder.ConfigureServices((context, services) => builder.ConfigureLogging(logging =>
                    krakenModule.Configure(services, context.Configuration, context.HostingEnvironment, logging))));

    }
}
