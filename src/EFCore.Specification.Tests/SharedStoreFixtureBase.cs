// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.EntityFrameworkCore.TestModels.GearsOfWarModel;

namespace Microsoft.EntityFrameworkCore
{
    public abstract class SharedStoreFixtureBase : FixtureBase, IDisposable
    {
        protected SharedStoreFixtureBase()
        {
            GearsOfWarContext.Seed();
        }

        public virtual void Dispose()
        {
        }
    }
}
