// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.TestModels.Northwind;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Microsoft.EntityFrameworkCore.TestUtilities.Xunit;
using Xunit;

// ReSharper disable InconsistentNaming

namespace Microsoft.EntityFrameworkCore.Query
{
    public abstract class GroupByQueryTestBase<TFixture> : QueryTestBase<TFixture>
        where TFixture : NorthwindQueryFixtureBase<NoopModelCustomizer>, new()
    {
        protected GroupByQueryTestBase(TFixture fixture)
            : base(fixture)
        {
        }

        protected NorthwindContext CreateContext() => Fixture.CreateContext();

        protected virtual void ClearLog()
        {
        }

        [ConditionalFact]
        public virtual void GroupBy_Composite_Select_Dto_Sum_Min_Key_flattened_Max_Avg()
        {
            AssertQuery<Order>(
                os => os.GroupBy(o => new { o.CustomerID, o.EmployeeID }).Select(
                    g =>
                        new CompositeDto
                        {
                            Sum = g.Sum(o => o.OrderID),
                            Min = g.Min(o => o.OrderID),
                            CustomerId = g.Key.CustomerID,
                            EmployeeId = g.Key.EmployeeID,
                            Max = g.Max(o => o.OrderID),
                            Avg = g.Average(o => o.OrderID)
                        }),
                e => e.CustomerId + " " + e.EmployeeId);
        }

        protected class CompositeDto
        {
            public int Sum { get; set; }
            public int Min { get; set; }
            public int Max { get; set; }
            public double Avg { get; set; }
            public string CustomerId { get; set; }
#if Test20
            public int? EmployeeId { get; set; }
#else
            public uint? EmployeeId { get; set; }
#endif

            public override bool Equals(object obj)
            {
                if (obj is null)
                {
                    return false;
                }

                if (ReferenceEquals(this, obj))
                {
                    return true;
                }

                return obj.GetType() == GetType() && Equals((CompositeDto)obj);
            }

            public override int GetHashCode() => 0;

            private bool Equals(CompositeDto other)
                => Sum == other.Sum
                    && Min == other.Min
                    && Max == other.Max
                    && Avg == other.Avg
                    && EmployeeId == other.EmployeeId
                    && string.Equals(CustomerId, other.CustomerId);
        }
    }
}
