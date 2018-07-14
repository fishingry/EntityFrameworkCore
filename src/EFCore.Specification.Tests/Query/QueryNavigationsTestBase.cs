// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.TestModels.Northwind;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Microsoft.EntityFrameworkCore.TestUtilities.Xunit;
using Xunit;

// ReSharper disable UnusedVariable
// ReSharper disable ConvertToExpressionBodyWhenPossible
// ReSharper disable InconsistentNaming
// ReSharper disable PossibleMultipleEnumeration
// ReSharper disable ReplaceWithSingleCallToFirstOrDefault
// ReSharper disable ReplaceWithSingleCallToAny
// ReSharper disable ReplaceWithSingleCallToFirst
// ReSharper disable StringStartsWithIsCultureSpecific
// ReSharper disable UseCollectionCountProperty
// ReSharper disable AccessToDisposedClosure
// ReSharper disable PossibleUnintendedReferenceComparison
namespace Microsoft.EntityFrameworkCore.Query
{
    public abstract class QueryNavigationsTestBase<TFixture> : QueryTestBase<TFixture>
        where TFixture : NorthwindQueryFixtureBase<NoopModelCustomizer>, new()
    {
        protected QueryNavigationsTestBase(TFixture fixture)
            : base(fixture)
        {
        }

        protected NorthwindContext CreateContext() => Fixture.CreateContext();

        protected virtual void ClearLog()
        {
        }
    }
}
