using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MutatorFX.Kraken.AspNetCore
{
    /// <summary>
    /// A module that is used to wire up different featuresets to an application.
    /// </summary>
    public interface IKrakenModule
    {
        /// <summary>
        /// Used to configure an application's dependency injection, configuration and logging based on the hosting environment.
        /// </summary>
        /// <param name="services">The dependency injection services to configure. Features should only provide services pertaining to their featuresets.</param>
        /// <param name="configuration">The configuration object to configure.</param>
        /// <param name="hostingEnvironment">The environment of the application. Can be used to switch different implementations for services, logging and so on.</param>
        /// <param name="loggingBuilder">Used to configure different logging objects for the application. Should be scoped to the module's featureset.</param>
        void Configure(IServiceCollection services, IConfiguration configuration, IHostingEnvironment hostingEnvironment, ILoggingBuilder loggingBuilder);
    }
}
