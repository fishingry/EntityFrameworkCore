// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.TestUtilities;

namespace Microsoft.EntityFrameworkCore.TestModels.GearsOfWarModel
{
    public class GearsOfWarData : IExpectedData
    {
        public IReadOnlyList<Gear> Gears { get; }
        public IReadOnlyList<Squad> Squads { get; }

        public GearsOfWarData()
        {
            Squads = CreateSquads();
            Gears = CreateGears();

            WireUp(Squads, Gears);
        }

        public virtual IQueryable<TEntity> Set<TEntity>()
            where TEntity : class
        {
            if (typeof(TEntity) == typeof(Gear))
            {
                return (IQueryable<TEntity>)Gears.AsQueryable();
            }

            if (typeof(TEntity) == typeof(Squad))
            {
                return (IQueryable<TEntity>)Squads.AsQueryable();
            }

            throw new InvalidOperationException("Invalid entity type: " + typeof(TEntity));
        }

        public static IReadOnlyList<Squad> CreateSquads()
            => new List<Squad>
            {
                new Squad { Name = "Delta" },
                new Squad { Name = "Kilo" }
            };

        public static IReadOnlyList<Gear> CreateGears()
            => new List<Gear>
            {
                new Gear
                {
                    HasSoulPatch = false,
                },
                new Gear
                {
                    HasSoulPatch = false,
                },
                new Gear
                {
                    HasSoulPatch = false,
                },
            };

        public static void WireUp(
            IReadOnlyList<Squad> squads,
            IReadOnlyList<Gear> gears)
        {
            squads[0].Members = new List<Gear> { gears[0], gears[1]};
            squads[1].Members = new List<Gear> { gears[2] };
        }
    }
}
