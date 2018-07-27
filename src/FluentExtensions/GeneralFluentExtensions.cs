using System;
using System.Collections.Generic;
using System.Linq;

namespace MutatorFX.FluentExtensions
{
    public static class GeneralFluentExtensions
    {
        /// <summary>
        /// Execute an action with the given object as parameter, then return the object.
        /// Useful for creating fluent APIs and shortening two-liners.
        /// Note that the input object <paramref name="obj"/> can only be mutated by the provided <paramref name="action"/> if it is a reference type.
        /// </summary>
        /// <typeparam name="T">The type of the given object <paramref name="obj"/>. Should be inferred.</typeparam>
        /// <param name="obj">The object to execute the given action on. Can be null.</param>
        /// <param name="action">The action to execute on the object <paramref name="obj"/>. Usually a method with 
        /// no return value or with a return value that should be ignored.</param>
        /// <returns>The object itself after the invokation of the action.</returns>
        public static T Do<T>(this T obj, Action<T> action)
        {
            (action ?? throw new ArgumentNullException(nameof(action)))(obj);
            return obj;
        }

        /// <summary>
        /// Execute an action with the given object as parameter if a precondition succeeds, then return the object.
        /// Optionally execute another action, like an if-else statement.
        /// Useful for creating fluent APIs and shortening two-liners.
        /// Note that the input object <paramref name="obj"/> can only be mutated by the provided actions if it is a reference type.
        /// </summary>
        /// <typeparam name="T">The type of the given object <paramref name="obj"/>. Should be inferred.</typeparam>
        /// <param name="obj">The object to execute the given action on. Can be null.</param>
        /// <param name="predicate">The precondition to check.</param>
        /// <param name="actionIf">The action to execute on the object <paramref name="obj"/> when the precondition succeeds.
        /// Usually a method with no return value or with a return value that should be ignored.</param>
        /// <param name="actionElse">The action to execute on the object <paramref name="obj"/> when the precondition fails.
        /// Usually a method with no return value or with a return value that should be ignored. Optional.</param>
        /// <returns>The object itself after the invokation of either or none of the actions.</returns>
        public static T DoWhen<T>(this T obj, bool predicate, Action<T> actionIf, Action<T> actionElse = null) =>
            predicate ? obj.Do(o => (actionIf ?? throw new ArgumentNullException(nameof(actionIf)))(o)) : obj.Do(o => actionElse?.Invoke(o));

        /// <summary>
        /// Execute an action with the given object as parameter if a precondition succeeds, then return the object.
        /// Optionally execute another action, like an if-else statement.
        /// Useful for creating fluent APIs and shortening two-liners.
        /// Note that the input object <paramref name="obj"/> can only be mutated by the provided actions if it is a reference type.
        /// </summary>
        /// <typeparam name="T">The type of the given object <paramref name="obj"/>. Should be inferred.</typeparam>
        /// <param name="obj">The object to execute the given action on. Can be null.</param>
        /// <param name="predicate">The precondition to check.</param>
        /// <param name="actionIf">The action to execute on the object <paramref name="obj"/>. A method with 
        /// no return value or with a return value that should be ignored.</param>
        /// <returns>The object itself after the invokation of either or none of the actions.</returns>
        public static T DoWhen<T>(this T obj, Func<T, bool> predicate, Action<T> actionIf, Action<T> actionElse = null) =>
            predicate(obj) ? obj.Do(o => (actionIf ?? throw new ArgumentNullException(nameof(actionIf)))(o)) : obj.Do(o => actionElse?.Invoke(o));

        /// <summary>Branch a statement based on the current value.</summary>
        /// <param name="predicate">The value to check for branching.</param>
        /// <param name="actionIf">The action to execute when precondition succeeds.</param>
        /// <param name="actionElse">The action to execute when precondition fails. Optional.</param>
        public static void Branch(this bool predicate, Action actionIf, Action actionElse = null) =>
            (predicate ? actionIf ?? throw new ArgumentNullException(nameof(actionIf)) : actionElse)();

        /// <summary>Branch a statement based on the current value.</summary>
        /// <typeparam name="T">The type of the return value. In most cases, should be inferred.</typeparam>
        /// <param name="predicate">The value to check for branching.</param>
        /// <param name="funcIf">The function to execute when precondition succeeds.</param>
        /// <param name="funcElse">The function to execute when precondition fails. Optional.</param>
        /// <returns>The result of the appropriate invokation. If no else branch was specified and precondition fails, the default of type <typeparamref name="T"/> is returned.</returns>
        public static T Branch<T>(this bool predicate, Func<T> funcIf, Func<T> funcElse = null) =>
            (predicate ? funcIf ?? throw new ArgumentNullException(nameof(funcIf)) : funcElse).Pipe(f => f != null ? f.Invoke() : default);

        /// <summary>Branch a statement based on the current value.</summary>
        /// <typeparam name="T">The type of the given object <paramref name="obj"/>. Should be inferred.</typeparam>
        /// <typeparam name="TResult">The type of the return value. In most cases, should be inferred.</typeparam>
        /// <param name="predicate">The value to check for branching.</param>
        /// <param name="funcIf">The function to execute when precondition succeeds.</param>
        /// <param name="funcElse">The function to execute when precondition fails. Optional.</param>
        /// <returns>The result of the appropriate invokation. If no else branch was specified and precondition fails, the default of type <typeparamref name="T"/> is returned.</returns>
        public static TResult Branch<TResult, T>(this T obj, Func<T, bool> predicate, Func<T, TResult> funcIf, Func<T, TResult> funcElse = null) =>
            (predicate(obj) ? funcIf ?? throw new ArgumentNullException(nameof(funcIf)) : funcElse).Pipe(f => f != null ? f.Invoke(obj) : default);

        /// <summary>
        /// Execute a function with the given object as parameter, and return the result.
        /// Useful to create fluent APIs and shorten code by closing on the object <paramref name="obj"/>.
        /// Instead of a simple invocation, you can create a closure on the object <paramref name="obj"/> and reuse the variable in the <paramref name="function"/> scope.
        /// Note that the input object <paramref name="obj"/> can only be mutated by the provided <paramref name="function"/> if it is a reference type.
        /// </summary>
        /// <typeparam name="T">The type of the object <paramref name="obj"/>. Has to be a reference type so that structures won't be copied. Should be inferred.</typeparam>
        /// <typeparam name="TResult">The type of the invokation result of <paramref name="function"/>. Should be inferred.</typeparam>
        /// <param name="obj">The object to call the provided function <paramref name="function"/> on.</param>
        /// <param name="function">The function to call with the parameter <paramref name="obj"/> and return the resulting value of.</param>
        /// <returns>Returns the result of the function invokation of <paramref name="function"/> with the parameter <paramref name="obj"/>.</returns>
        public static TResult Pipe<T, TResult>(this T obj, Func<T, TResult> function) where T : class =>
            function(obj);

        /// <summary>
        /// Execute the provided <paramref name="action"/> for all elements in the <paramref name="source"/> collection.
        /// Useful to create fluent APIs and shorten code by replacing foreach loops. The action is executed and the element is returned for each element.
        /// Used instead of <see cref="Enumerable.Select{TSource, TResult}(IEnumerable{TSource}, Func{TSource, TResult})"/> when the <paramref name="source"/> should not lazily be enumerated.
        /// Note that the input objects in <paramref name="source"/> can only be mutated by the provided <paramref name="action"/> if <typeparamref name="T"/> is a reference type.
        /// </summary>
        /// <typeparam name="T">The type of the collection elements. Should be inferred.</typeparam>
        /// <param name="source">The collection to enumerate and execute the provided <paramref name="action"/> on. Can not be null.</param>
        /// <param name="action">The action to execute on the <paramref name="source"/> collection. Can not be null.</param>
        /// <returns>Returns the elements of <paramref name="source"/>, after each has been invoked on <paramref name="action"/>.</returns>
        public static IEnumerable<T> For<T>(this IEnumerable<T> source, Action<T> action) =>
            (source ?? throw new ArgumentNullException(nameof(source))).ForInternal(action ?? throw new ArgumentNullException(nameof(action))).ToArray();

        /// <summary>
        /// Execute the provided <paramref name="action"/> for all elements in the <paramref name="source"/> collection.
        /// Useful to create fluent APIs and shorten code by replacing foreach loops. The action is executed and the element is returned for each element.
        /// Used instead of <see cref="Enumerable.Select{TSource, TResult}(IEnumerable{TSource}, Func{TSource, TResult})"/> and the <paramref name="source"/> can optionally be lazily enumerated.
        /// Note that the input objects in <paramref name="source"/> can only be mutated by the provided <paramref name="action"/> if <typeparamref name="T"/> is a reference type.
        /// </summary>
        /// <typeparam name="T">The type of the collection elements. Should be inferred.</typeparam>
        /// <param name="source">The collection to enumerate and execute the provided <paramref name="action"/> on. Can not be null.</param>
        /// <param name="action">The action to execute on the <paramref name="source"/> collection. Can not be null.</param>
        /// <returns>Returns the elements of <paramref name="source"/> one by one after being invoked on <paramref name="action"/>, or after all has been invoked depending on the value of <paramref name="lazy"/>.</returns>
        public static IEnumerable<T> For<T>(this IEnumerable<T> source, Action<T> action, bool lazy) =>
            (source ?? throw new ArgumentNullException(nameof(source))).ForInternal(action ?? throw new ArgumentNullException(nameof(action))).DoWhen(!lazy, e => e.ToArray());

        /// <summary>
        /// Internal helper method for the method <see cref="For{T}(IEnumerable{T}, Action{T})"/>. Used for reducing the number of parameter null checks.
        /// Note that the input objects in <paramref name="source"/> can only be mutated by the provided <paramref name="action"/> if <typeparamref name="T"/> is a reference type.
        /// </summary>
        /// <typeparam name="T">The type of the collection elements. Should be inferred.</typeparam>
        /// <param name="source">The collection to enumerate and execute the provided <paramref name="action"/> on. Can not be null, but not checked.</param>
        /// <param name="action">The action to execute on the <paramref name="source"/> collection. Can not be null, but not checked.</param>
        /// <returns>The parameter <paramref name="source"/> after invoking <paramref name="action"/> with its elements. Evaluated lazily.</returns>
        private static IEnumerable<T> ForInternal<T>(this IEnumerable<T> source, Action<T> action) =>
            source.Select(e => { action(e); return e; });
    }
}
