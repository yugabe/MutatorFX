using MutatorFX.Coding;
using System;

namespace MutatorFX.ExceptionHandling
{
    /// <summary>
    /// Contains helper methods to use when throwing and handling <see cref="Exception"/>s.
    /// </summary>
    public static class ExceptionHandlingExtensions
    {
        /// <summary>
        /// Appends the <paramref name="data"/> object's properties to the <paramref name="exception"/>'s <see cref="Exception.Data"/> dictionary.
        /// </summary>
        /// <typeparam name="TException">The type of the <see cref="Exception"/> to extend. Should be inferred by using as an extension method.</typeparam>
        /// <param name="exception">The exception to append the data to. Can be null, in this case null will be returned.</param>
        /// <param name="data">The data to append to the exception. Can be null, in this case the exception object will be returned as is.</param>
        /// <returns>The <paramref name="exception"/> with data appended from the <paramref name="data"/> object's properties to its <see cref="Exception.Data"/> property. 
        /// If the <paramref name="data"/> was null, the <paramref name="exception"/> is returned as is. 
        /// If the <paramref name="exception"/> was null, null will be returned.</returns>
        public static TException WithData<TException>(this TException exception, object data)
            where TException : Exception
            => exception.Branch(e => e != null && data != null, e => e.Do(ex => data.GetType().GetProperties().For(p => e.Data.Add(p.Name, p.GetValue(data)))));
    }
}
