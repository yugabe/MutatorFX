using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MutatorFX.Coding;
using System;
using static MutatorFX.ExceptionHandling.Assertions;

namespace MutatorFX.Kraken.AspNetCore
{
    /// <summary>
    /// Contains extensions for configuring Kraken architecture application modules.
    /// </summary>
    public static class WebHostingExtensions
    {
        /// <summary>
        /// Configures a Kraken module to be used for the current <paramref name="webHostBuilder"/>.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="IKrakenModule"/> to use. A new object will be instantiated.</typeparam>
        /// <param name="webHostBuilder">The <see cref="IWebHostBuilder"/> to use. Should not be null.</param>
        /// <returns>The <paramref name="webHostBuilder"/> instance after configured by the <see cref="IKrakenModule"/>.</returns>
        public static IWebHostBuilder UseKrakenModule<T>(this IWebHostBuilder webHostBuilder)
            where T : class, IKrakenModule, new()
            => webHostBuilder.UseKrakenModule<T>(new T());

        /// <summary>
        /// Configures a Kraken module to be used for the current <paramref name="webHostBuilder"/>.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="IKrakenModule"/> to use.</typeparam>
        /// <param name="webHostBuilder">The <see cref="IWebHostBuilder"/> to use. Should not be null.</param>
        /// <param name="krakenModule">The module to configure the builder with.</param>
        /// <returns>The <paramref name="webHostBuilder"/> instance after configured by the <see cref="IKrakenModule"/>.</returns>
        public static IWebHostBuilder UseKrakenModule<T>(this IWebHostBuilder webHostBuilder, T krakenModule)
            where T : class, IKrakenModule
            => EnsureNoneNull(new { webHostBuilder, krakenModule }).webHostBuilder.Do(builder =>
                  builder.ConfigureServices((context, services) => builder.ConfigureLogging(logging =>
                    krakenModule.Configure(services, context.Configuration, context.HostingEnvironment, logging))));

        /// <summary>
        /// Execute an <see cref="IKrakenStartupTask"/> before hosting starts of an <see cref="IWebHost"/>.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="IKrakenStartupTask"/> to use. Will be instantiated by using a service scope from the <paramref name="webHost"/>'s <see cref="IWebHost.Services"/>.</typeparam>
        /// <param name="webHost">The host to execute the startup task on.</param>
        /// <returns>The <paramref name="webHost"/>, after the startup task finished.</returns>
        public static IWebHost UseKrakenStartupTask<T>(this IWebHost webHost)
            where T : IKrakenStartupTask
            => EnsureNotNull(webHost, nameof(webHost)).DoAwait(h => h.Services.CreateScope().Using(s => s.ServiceProvider.GetRequiredService<T>().OnBeforeHostStartsAsync(h)));
    }
}
