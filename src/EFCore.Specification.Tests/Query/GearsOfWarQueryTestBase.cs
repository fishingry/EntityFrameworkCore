// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.TestModels.GearsOfWarModel;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Microsoft.EntityFrameworkCore.TestUtilities.Xunit;
using Xunit;

// ReSharper disable AccessToModifiedClosure
// ReSharper disable SimplifyConditionalTernaryExpression
// ReSharper disable ArgumentsStyleAnonymousFunction
// ReSharper disable ArgumentsStyleOther
// ReSharper disable PossibleMultipleEnumeration
// ReSharper disable EqualExpressionComparison
// ReSharper disable InconsistentNaming
// ReSharper disable AccessToDisposedClosure
// ReSharper disable StringEndsWithIsCultureSpecific
// ReSharper disable ReplaceWithSingleCallToSingle
// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore.Query
{
    public abstract class GearsOfWarQueryTestBase<TFixture> : QueryTestBase<TFixture>
        where TFixture : GearsOfWarQueryFixtureBase, new()
    {
        protected GearsOfWarQueryTestBase(TFixture fixture)
            : base(fixture)
        {
        }

        // Remember to add any new tests to Async version of this test class

        [ConditionalFact]
        public virtual void Select_subquery_projecting_single_constant_of_non_mapped_type()
        {
            AssertQuery<Squad>(
                ss => ss.Select(s => new { s.Name, Gear = s.Members.Where(g => g.HasSoulPatch).Select(g => new MyDTO()).FirstOrDefault() }),
                elementSorter: e => e.Name,
                elementAsserter: (e, a) => Assert.Equal(e.Name, a.Name));
        }

        public class MyDTO
        {
        }

        // Remember to add any new tests to Async version of this test class

        protected GearsOfWarContext CreateContext() => Fixture.CreateContext();

        protected virtual void ClearLog()
        {
        }
    }
}
