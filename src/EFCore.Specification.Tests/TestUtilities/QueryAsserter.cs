// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.TestModels.GearsOfWarModel;

namespace Microsoft.EntityFrameworkCore.TestUtilities
{
    public class QueryAsserter: QueryAsserterBase
    {
        public override void AssertQuery<TItem1>(
            Func<IQueryable<TItem1>, IQueryable<object>> expectedQuery,
            Func<dynamic, object> elementSorter = null)
        {
            var expected = expectedQuery(new GearsOfWarData().Set<TItem1>()).ToArray();

            AssertResults(
                expected,
                elementSorter);
        }

        public int AssertResults<T>(
            IList<T> expected,
            Func<T, object> elementSorter)
        {
            expected = expected.OrderBy(elementSorter).ToList();

            return expected.Count;
        }
    }
}
