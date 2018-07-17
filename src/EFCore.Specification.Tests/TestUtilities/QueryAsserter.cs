// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.EntityFrameworkCore.TestUtilities
{
    public class QueryAsserter: QueryAsserterBase
    {
        private readonly Dictionary<Type, Func<dynamic, object>> _entitySorters;
        private readonly Dictionary<Type, Action<dynamic, dynamic>> _entityAsserters;

        public QueryAsserter(
            IExpectedData expectedData,
            Dictionary<Type, Func<dynamic, object>> entitySorters,
            Dictionary<Type, Action<dynamic, dynamic>> entityAsserters)
        {
            ExpectedData = expectedData;

            _entitySorters = entitySorters ?? new Dictionary<Type, Func<dynamic, object>>();
            _entityAsserters = entityAsserters ?? new Dictionary<Type, Action<dynamic, dynamic>>();
        }
        
        public override void AssertQuery<TItem1>(
            Func<IQueryable<TItem1>, IQueryable<object>> actualQuery,
            Func<IQueryable<TItem1>, IQueryable<object>> expectedQuery,
            Func<dynamic, object> elementSorter = null,
            Action<dynamic, dynamic> elementAsserter = null,
            bool assertOrder = false,
            int entryCount = 0,
            bool isAsync = false)
        {
            var expected = expectedQuery(ExpectedData.Set<TItem1>()).ToArray();

            TestHelpers.AssertResults(
                expected,
                elementSorter,
                elementAsserter,
                assertOrder);
        }
    }
}
