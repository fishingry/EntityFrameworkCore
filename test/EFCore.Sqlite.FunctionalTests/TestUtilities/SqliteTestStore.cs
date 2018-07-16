// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.Data.Sqlite;

namespace Microsoft.EntityFrameworkCore.TestUtilities
{
    public class SqliteTestStore : RelationalTestStore
    {
        public const int CommandTimeout = 30;

        public static SqliteTestStore GetOrCreate(string name, bool sharedCache = true)
            => new SqliteTestStore(name, sharedCache: sharedCache);

        public static SqliteTestStore GetExisting(string name)
            => new SqliteTestStore(name, seed: false);

        public static SqliteTestStore Create(string name, bool sharedCache = true)
            => new SqliteTestStore(name, sharedCache: sharedCache, shared: false);

        private readonly bool _seed;

        private SqliteTestStore(string name, bool seed = true, bool sharedCache = true, bool shared = true)
            : base(name, shared)
        {
            _seed = seed;

            ConnectionString = new SqliteConnectionStringBuilder
            {
                DataSource = Name + ".db",
                Cache = sharedCache ? SqliteCacheMode.Shared : SqliteCacheMode.Private
            }.ToString();

            Connection = new SqliteConnection(ConnectionString);
        }

        public override DbContextOptionsBuilder AddProviderOptions(DbContextOptionsBuilder builder)
            => builder.UseSqlite(Connection, b => b.CommandTimeout(CommandTimeout));

        protected override void Initialize(Func<DbContext> createContext, Action<DbContext> seed)
        {
            if (!_seed)
            {
                return;
            }
            using (var context = createContext())
            {
                if (!context.Database.EnsureCreated())
                {
                    Clean(context);
                }
                seed(context);
            }
        }

        public override void Clean(DbContext context)
            => context.Database.EnsureClean();

        public override void OpenConnection()
        {
            Connection.Open();

            using (var command = Connection.CreateCommand())
            {
                command.CommandText = "PRAGMA foreign_keys=ON;";
                command.ExecuteNonQuery();
            }
        }
    }
}
