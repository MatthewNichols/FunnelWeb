using System;
using System.Collections.Generic;
using FunnelWeb.DataAccess.Sql.Providers.Database;
using FunnelWeb.Domain.Interfaces;
using NHibernate;

namespace FunnelWeb.DataAccess.Sql.DatabaseDeployer.Infrastructure
{
    public static class FunnelWebNHibernateExtensions
    {
        public static IFutureValue<TValue> FutureValue<T, TValue>(this IQueryOver<T> query, IDatabaseProvider databaseProvider)
        {
            if (databaseProvider.SupportFuture)
                return query.FutureValue<TValue>();
            return new FunnelWebFutureValue<TValue>(query.SingleOrDefault<TValue>());
        }

        public static IEnumerable<T> Future<T>(this IQueryOver<T> query, IDatabaseProvider databaseProvider)
        {
            if (databaseProvider.SupportFuture)
                return query.Future();
            return query.List();
        }

        public static IEnumerable<TU> Future<T, TU>(this IQueryOver<T> query, IDatabaseProvider databaseProvider)
        {
            if (databaseProvider.SupportFuture)
                return query.Future<TU>();
            return query.List<TU>();
        }
    }

    public class FunnelWebFutureValue<T> : IFutureValue<T>
    {
        private readonly T value;

        public FunnelWebFutureValue(T value)
        {
            this.value = value;
        }

        public T Value
        {
            get { return value; }
        }
    }
}
