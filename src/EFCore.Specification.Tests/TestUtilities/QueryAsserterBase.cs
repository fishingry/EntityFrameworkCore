// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Linq;

namespace Microsoft.EntityFrameworkCore.TestUtilities
{
    public abstract class QueryAsserterBase
    {
        public abstract void AssertQuery<TItem1>(
            Func<IQueryable<TItem1>, IQueryable<object>> expectedQuery,
            Func<dynamic, object> elementSorter = null)
            where TItem1 : class;
    }
}
