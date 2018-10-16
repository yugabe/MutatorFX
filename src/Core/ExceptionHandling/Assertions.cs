using MutatorFX.Coding;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace MutatorFX.ExceptionHandling
{
    /// <summary>
    /// This class contains static helper methods to validate simple assertions for generating Exceptions like
    /// <see cref="ArgumentNullException"/> or <see cref="ArgumentOutOfRangeException"/>.
    /// It is suggested that you use the assertions as follows:<para></para>
    /// <code>
    /// using static MutatorFX.ExceptionHandling.Assertions;
    /// 
    /// void Method(string param1, object param2)
    /// {
    ///     EnsureNoneNull(new { param1, param2 });
    /// }
    /// 
    /// void Method2(string parameter)
    /// {
    ///     EnsureNotNull(nameof(parameter), parameter);
    /// }
    /// </code>
    /// </summary>
    public static class Assertions
    {
        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if the passed parameter was null.
        /// Consider using the <see cref="EnsureNotNull{T}(string, T)"/> overload for named parameters.
        /// </summary>
        /// <param name="parameter">The parameter which should not be null.</param>
        /// <exception cref="ArgumentNullException">Thrown when the given parameter object is null.</exception>
        /// <returns>The parameter if it was not null, throws an <see cref="ArgumentNullException"/> otherwise.</returns>
        [DebuggerStepThrough]
        public static T EnsureNotNull<T>(T parameter) 
            => parameter == null ? parameter : throw new ArgumentNullException();

        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if the passed parameter was null.
        /// </summary>
        /// <param name="parameterName">The (outer) name of the parameter. Should not be null :)</param>
        /// <param name="parameter">The parameter which should not be null.</param>
        /// <exception cref="ArgumentNullException">Thrown when the given parameter object is null.</exception>
        /// <returns>The parameter if it was not null, throws an <see cref="ArgumentNullException"/> otherwise.</returns>
        [DebuggerStepThrough]
        public static T EnsureNotNull<T>(string parameterName, T parameter)
            => parameter == null ? parameter : throw new ArgumentNullException(parameterName);

        /// <summary>
        /// Throws an <see cref="AggregateException"/> if any of the passed <paramref name="parameters"/> object's properties are null.
        /// Should be used with an anonymous object containing
        /// Usage:<para></para>
        /// <code>
        /// using static MutatorFX.ExceptionHandling.Assertions;
        /// 
        /// void Method(string param1, object param2)
        /// {
        ///     EnsureNoneNull(new { param1, param2 });
        /// }
        /// </code>
        /// </summary>
        /// <param name="parameters">The object containing the parameters in its properties to check for null. 
        /// Should be an anonymous object constructed inline from the names of the parameters.</param>
        /// <exception cref="ArgumentNullException">Thrown when the given parameters object is null.</exception>
        /// <exception cref="AggregateException">Thrown when any of the given parameters object's properties are null. 
        /// Contains <see cref="ArgumentNullException"/> instances which show the invalid parameters.</exception>
        [DebuggerStepThrough]
        public static void EnsureNoneNull(object parameters)
            => (parameters ?? throw new ArgumentNullException(nameof(parameters), "The parameters object passed to this method should not be null and contain the parameters in an anonymous object's properties."))
                .GetType().GetProperties().Where(p => p.GetValue(parameters) == null).Branch(nullValues => nullValues.Any(), nullValues => throw new AggregateException(nullValues.Select(n => new ArgumentNullException(n.Name))));
    }
}
