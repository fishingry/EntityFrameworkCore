// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.EntityFrameworkCore.TestUtilities
{
    public class QueryAsserter<TContext> : QueryAsserterBase
        where TContext : DbContext
    {
        private readonly Func<TContext> _contextCreator;
        private readonly Dictionary<Type, Func<dynamic, object>> _entitySorters;
        private readonly Dictionary<Type, Action<dynamic, dynamic>> _entityAsserters;
        private readonly IncludeQueryResultAsserter _includeResultAsserter;

        public QueryAsserter(
            Func<TContext> contextCreator,
            IExpectedData expectedData,
            Dictionary<Type, Func<dynamic, object>> entitySorters,
            Dictionary<Type, Action<dynamic, dynamic>> entityAsserters)
        {
            _contextCreator = contextCreator;
            ExpectedData = expectedData;

            _entitySorters = entitySorters ?? new Dictionary<Type, Func<dynamic, object>>();
            _entityAsserters = entityAsserters ?? new Dictionary<Type, Action<dynamic, dynamic>>();

            SetExtractor = new DefaultSetExtractor();
            _includeResultAsserter = new IncludeQueryResultAsserter(_entitySorters, _entityAsserters);
        }

        #region AssertQuery

        // one argument

        public virtual Task AssertQuery<TItem1>(
            Func<IQueryable<TItem1>, IQueryable<object>> query,
            Func<dynamic, object> elementSorter = null,
            Action<dynamic, dynamic> elementAsserter = null,
            bool assertOrder = false,
            int entryCount = 0,
            bool isAsync = false)
            where TItem1 : class
            => AssertQuery(query, query, elementSorter, elementAsserter, assertOrder, entryCount, isAsync);


        private Task<object[]> DummyAsync() => Task.FromResult(new object[] { "foo", "bar" });
        private object[] Dummy() => new object[] { "foo", "bar" };


        public override async Task AssertQuery<TItem1>(
            Func<IQueryable<TItem1>, IQueryable<object>> actualQuery,
            Func<IQueryable<TItem1>, IQueryable<object>> expectedQuery,
            Func<dynamic, object> elementSorter = null,
            Action<dynamic, dynamic> elementAsserter = null,
            bool assertOrder = false,
            int entryCount = 0,
            bool isAsync = false)
        {
            using (var context = _contextCreator())
            {
                var actual = isAsync
                    ? await DummyAsync()
                    : Dummy();

                var expected = expectedQuery(ExpectedData.Set<TItem1>()).ToArray();

                var firstNonNullableElement = expected.FirstOrDefault(e => e != null);
                if (firstNonNullableElement != null)
                {
                    if (!assertOrder && elementSorter == null)
                    {
                        _entitySorters.TryGetValue(firstNonNullableElement.GetType(), out elementSorter);
                    }

                    if (elementAsserter == null)
                    {
                        _entityAsserters.TryGetValue(firstNonNullableElement.GetType(), out elementAsserter);
                    }
                }

                TestHelpers.AssertResults(
                    expected,
                    elementSorter,
                    elementAsserter,
                    assertOrder);
            }
        }

        // two arguments

        public virtual Task AssertQuery<TItem1, TItem2>(
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<object>> query,
            Func<dynamic, object> elementSorter = null,
            Action<dynamic, dynamic> elementAsserter = null,
            bool assertOrder = false,
            int entryCount = 0,
            bool isAsync = false)
            where TItem1 : class
            where TItem2 : class
            => AssertQuery(query, query, elementSorter, elementAsserter, assertOrder, entryCount, isAsync);

        public override async Task AssertQuery<TItem1, TItem2>(
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<object>> actualQuery,
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<object>> expectedQuery,
            Func<dynamic, object> elementSorter = null,
            Action<dynamic, dynamic> elementAsserter = null,
            bool assertOrder = false,
            int entryCount = 0,
            bool isAsync = false)
        {
            using (var context = _contextCreator())
            {
                var actual = isAsync
                    ? await DummyAsync()
                    : Dummy();

                var expected = expectedQuery(
                    ExpectedData.Set<TItem1>(),
                    ExpectedData.Set<TItem2>()).ToArray();

                var firstNonNullableElement = expected.FirstOrDefault(e => e != null);
                if (firstNonNullableElement != null)
                {
                    if (!assertOrder && elementSorter == null)
                    {
                        _entitySorters.TryGetValue(firstNonNullableElement.GetType(), out elementSorter);
                    }

                    if (elementAsserter == null)
                    {
                        _entityAsserters.TryGetValue(firstNonNullableElement.GetType(), out elementAsserter);
                    }
                }

                TestHelpers.AssertResults(
                    expected,
                    elementSorter,
                    elementAsserter,
                    assertOrder);
            }
        }

        // three arguments
        public virtual Task AssertQuery<TItem1, TItem2, TItem3>(
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<TItem3>, IQueryable<object>> query,
            Func<dynamic, object> elementSorter = null,
            Action<dynamic, dynamic> elementAsserter = null,
            bool assertOrder = false,
            int entryCount = 0,
            bool isAsync = false)
            where TItem1 : class
            where TItem2 : class
            where TItem3 : class
            => AssertQuery(query, query, elementSorter, elementAsserter, assertOrder, entryCount, isAsync);

        public override async Task AssertQuery<TItem1, TItem2, TItem3>(
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<TItem3>, IQueryable<object>> actualQuery,
            Func<IQueryable<TItem1>, IQueryable<TItem2>, IQueryable<TItem3>, IQueryable<object>> expectedQuery,
            Func<dynamic, object> elementSorter = null,
            Action<dynamic, dynamic> elementAsserter = null,
            bool assertOrder = false,
            int entryCount = 0,
            bool isAsync = false)
        {
            using (var context = _contextCreator())
            {
                var actual = isAsync
                    ? await DummyAsync()
                    : Dummy();

                var expected = expectedQuery(
                    ExpectedData.Set<TItem1>(),
                    ExpectedData.Set<TItem2>(),
                    ExpectedData.Set<TItem3>()).ToArray();

                var firstNonNullableElement = expected.FirstOrDefault(e => e != null);
                if (firstNonNullableElement != null)
                {
                    if (!assertOrder && elementSorter == null)
                    {
                        _entitySorters.TryGetValue(firstNonNullableElement.GetType(), out elementSorter);
                    }

                    if (elementAsserter == null)
                    {
                        _entityAsserters.TryGetValue(firstNonNullableElement.GetType(), out elementAsserter);
                    }
                }

                TestHelpers.AssertResults(
                    expected,
                    elementSorter,
                    elementAsserter,
                    assertOrder);
            }
        }

        #endregion

        private class DefaultSetExtractor : ISetExtractor
        {
            public override IQueryable<TEntity> Set<TEntity>(DbContext context)
            {
                var entityOrQueryType = context.Model.FindEntityType(typeof(TEntity));

                return entityOrQueryType.IsQueryType
                        ? (IQueryable<TEntity>)context.Query<TEntity>()
                        : context.Set<TEntity>();
            }
        }
    }
}
