// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.EntityFrameworkCore.TestModels.GearsOfWarModel;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace Microsoft.EntityFrameworkCore.Query
{
    public abstract class GearsOfWarQueryFixtureBase : IQueryFixtureBase
    {
        protected GearsOfWarQueryFixtureBase()
        {
            GearsOfWarContext.Seed();

            QueryAsserter = new QueryAsserter();
        }

        public QueryAsserterBase QueryAsserter { get; set; }
    }
}
