// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Data.Common;

namespace Microsoft.EntityFrameworkCore.TestUtilities
{
    public abstract class RelationalTestStore : TestStore
    {
        public virtual string ConnectionString { get; protected set; }
        public virtual void OpenConnection() => Connection.Open();

        protected virtual DbConnection Connection { get; set; }

        protected RelationalTestStore(string name, bool shared)
            : base(name, shared)
        {
        }

        public override void Dispose()
        {
        }
    }
}
