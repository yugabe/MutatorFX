using MutatorFX.Coding;
using System;

namespace MutatorFX.ExceptionHandling
{
    public static class ExceptionHandlingExtensions
    {
        public static TException WithData<TException>(this TException exception, object data)
            where TException : Exception
            => exception.Branch(e => data != null, e => e.Do(ex => data.GetType().GetProperties().For(p => e.Data.Add(p.Name, p.GetValue(data)))));
    }
}
