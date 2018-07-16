// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Transactions;
using Xunit;

namespace Microsoft.EntityFrameworkCore.TestUtilities
{
    public abstract class TestStore : IDisposable
    {
        private readonly bool _shared;
        private static readonly TestStoreIndex _globalTestStoreIndex = new TestStoreIndex();

        protected TestStore(string name, bool shared)
        {
            Name = name;
            _shared = shared;
        }

        public string Name { get; protected set; }

        protected virtual void Initialize(Func<DbContext> createContext, Action<DbContext> seed)
        {
            using (var context = createContext())
            {
                Clean(context);
                seed(context);
            }
        }

        public abstract DbContextOptionsBuilder AddProviderOptions(DbContextOptionsBuilder builder);
        public abstract void Clean(DbContext context);

        public virtual void Dispose()
        {
        }

        private class DistributedTransactionListener : IDisposable
        {
            public DistributedTransactionListener()
            {
                TransactionManager.DistributedTransactionStarted += DistributedTransactionStarted;
            }

            private void DistributedTransactionStarted(object sender, TransactionEventArgs e)
            {
                Assert.False(true, "Distributed transaction started");
            }

            public void Dispose()
            {
                TransactionManager.DistributedTransactionStarted -= DistributedTransactionStarted;
            }
        }
    }
}
