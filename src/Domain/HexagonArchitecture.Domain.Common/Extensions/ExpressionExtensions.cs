using System;
using System.Collections.Concurrent;
using System.Linq.Expressions;
using JetBrains.Annotations;

namespace HexagonArchitecture.Domain.Common.Extensions
{
    #region Using

    #endregion

    [PublicAPI]
    public static class ExpressionExtensions
    {
        #region Dynamic Expression Compilation

        private static readonly ConcurrentDictionary<Expression, object> Cache = new ConcurrentDictionary<Expression, object>();

        public static Func<TIn, TOut> AsFunc<TIn, TOut>(this Expression<Func<TIn, TOut>> expr)
            //@see http://sergeyteplyakov.blogspot.ru/2015/06/lazy-trick-with-concurrentdictionary.html
        {
            return (Func<TIn, TOut>) ((Lazy<object>) Cache.GetOrAdd(expr, id => new Lazy<object>(expr.Compile))).Value;
        }

        #endregion
    }
}