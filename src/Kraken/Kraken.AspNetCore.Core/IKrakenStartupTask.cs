using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static MutatorFX.ExceptionHandling.Assertions;

namespace MutatorFX.Kraken.AspNetCore
{
    /// <summary>
    /// Represents a startup task that gets executed before hosting starts.
    /// </summary>
    public interface IKrakenStartupTask
    {
        /// <summary>
        /// The task to execute before hosting starts on the <paramref name="webHost"/>.
        /// </summary>
        /// <param name="webHost">The <see cref="IWebHost"/> to use.</param>
        Task OnBeforeHostStartsAsync(IWebHost webHost);
    }
}
