// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.TestModels.GearsOfWarModel;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace Microsoft.EntityFrameworkCore.Query
{
    public abstract class GearsOfWarQueryFixtureBase : SharedStoreFixtureBase, IQueryFixtureBase
    {
        protected GearsOfWarQueryFixtureBase()
        {
            var entitySorters = new Dictionary<Type, Func<dynamic, object>>();
            var entityAsserters = new Dictionary<Type, Action<dynamic, dynamic>>();

            QueryAsserter = new QueryAsserter(
                new GearsOfWarData(),
                entitySorters,
                entityAsserters);
        }

        public QueryAsserterBase QueryAsserter { get; set; }
    }
}
