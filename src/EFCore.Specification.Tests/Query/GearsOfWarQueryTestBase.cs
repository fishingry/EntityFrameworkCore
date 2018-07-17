// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Linq;
using Microsoft.EntityFrameworkCore.TestModels.GearsOfWarModel;
using Xunit;

namespace Microsoft.EntityFrameworkCore.Query
{
    public abstract class GearsOfWarQueryTestBase<TFixture> : QueryTestBase<TFixture>
        where TFixture : GearsOfWarQueryFixtureBase, new()
    {
        protected GearsOfWarQueryTestBase(TFixture fixture)
            : base(fixture)
        {
        }

        [Fact]
        public virtual void Select_subquery_projecting_single_constant_of_non_mapped_type()
        {
            AssertQuery<Squad>(
                ss => ss.Select(s => new { s.Name, Gear = s.Members.Where(g => g.HasSoulPatch).Select(g => new MyDTO()).FirstOrDefault() }),
                elementSorter: e => e.Name,
                elementAsserter: (e, a) => { });
        }

        public class MyDTO
        {
        }
    }
}
