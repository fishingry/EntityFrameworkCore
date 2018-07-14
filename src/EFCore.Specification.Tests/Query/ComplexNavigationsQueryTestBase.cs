// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.TestModels.ComplexNavigationsModel;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Microsoft.EntityFrameworkCore.TestUtilities.Xunit;
using Xunit;

// ReSharper disable ConvertClosureToMethodGroup
// ReSharper disable PossibleUnintendedReferenceComparison
// ReSharper disable ArgumentsStyleLiteral
// ReSharper disable PossibleMultipleEnumeration
// ReSharper disable UnusedVariable
// ReSharper disable EqualExpressionComparison
// ReSharper disable AccessToDisposedClosure
// ReSharper disable StringStartsWithIsCultureSpecific
// ReSharper disable InconsistentNaming
// ReSharper disable MergeConditionalExpression
// ReSharper disable ReplaceWithSingleCallToSingle
// ReSharper disable ReturnValueOfPureMethodIsNotUsed
// ReSharper disable ConvertToExpressionBodyWhenPossible
namespace Microsoft.EntityFrameworkCore.Query
{
    public abstract class ComplexNavigationsQueryTestBase<TFixture> : QueryTestBase<TFixture>
        where TFixture : ComplexNavigationsQueryFixtureBase, new()
    {
        protected ComplexNavigationsContext CreateContext()
        {
            return Fixture.CreateContext();
        }

        protected ComplexNavigationsQueryTestBase(TFixture fixture)
            : base(fixture)
        {
        }

        private class ProjectedDto<T>
        {
            public T Value { get; set; }
        }
    }
}
