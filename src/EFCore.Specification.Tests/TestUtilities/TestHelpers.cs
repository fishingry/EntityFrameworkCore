// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Microsoft.EntityFrameworkCore.TestUtilities
{
    public abstract class TestHelpers
    {
        public static int AssertResults<T>(
            IList<T> expected,
            Func<T, object> elementSorter,
            Action<T, T> elementAsserter,
            bool verifyOrdered)
        {
            if (elementSorter == null && !verifyOrdered)
            {
                return expected.Count;
            }

            elementSorter = elementSorter ?? (e => e);
            elementAsserter = elementAsserter ?? Assert.Equal;
            if (!verifyOrdered)
            {
                expected = expected.OrderBy(elementSorter).ToList();
            }

            return expected.Count;
        }
    }
}
