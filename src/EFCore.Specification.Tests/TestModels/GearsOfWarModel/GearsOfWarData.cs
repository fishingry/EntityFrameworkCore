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
                new Squad { Id = 1, Name = "Delta" },
                new Squad { Id = 2, Name = "Kilo" }
            };

        public static IReadOnlyList<Gear> CreateGears()
            => new List<Gear>
            {
                new Gear
                {
                    Nickname = "Dom",
                    FullName = "Dominic Santiago",
                    HasSoulPatch = false,
                    SquadId = 1,
                    Rank = MilitaryRank.Corporal,
                    CityOrBirthName = "Ephyra",
                    LeaderNickname = "Marcus",
                    LeaderSquadId = 1
                },
                new Gear
                {
                    Nickname = "Cole Train",
                    FullName = "Augustus Cole",
                    HasSoulPatch = false,
                    SquadId = 1,
                    Rank = MilitaryRank.Private,
                    CityOrBirthName = "Hanover",
                    LeaderNickname = "Marcus",
                    LeaderSquadId = 1
                },
                new Gear
                {
                    Nickname = "Paduk",
                    FullName = "Garron Paduk",
                    HasSoulPatch = false,
                    SquadId = 2,
                    Rank = MilitaryRank.Private,
                    CityOrBirthName = "Unknown",
                    LeaderNickname = "Baird",
                    LeaderSquadId = 1
                },
                new Officer
                {
                    Nickname = "Baird",
                    FullName = "Damon Baird",
                    HasSoulPatch = true,
                    SquadId = 1,
                    Rank = MilitaryRank.Corporal,
                    CityOrBirthName = "Unknown",
                    LeaderNickname = "Marcus",
                    LeaderSquadId = 1
                },
                new Officer
                {
                    Nickname = "Marcus",
                    FullName = "Marcus Fenix",
                    HasSoulPatch = true,
                    SquadId = 1,
                    Rank = MilitaryRank.Sergeant,
                    CityOrBirthName = "Jacinto"
                }
            };

        public static void WireUp(
            IReadOnlyList<Squad> squads,
            IReadOnlyList<Gear> gears)
        {

            squads[0].Members = new List<Gear> { gears[0], gears[1], gears[3], gears[4] };
            squads[1].Members = new List<Gear> { gears[2] };

            // dom
            gears[0].Squad = squads[0];

            // cole
            gears[1].Squad = squads[0];

            // paduk
            gears[2].Squad = squads[1];

            // baird
            gears[3].Squad = squads[0];
            ((Officer)gears[3]).Reports = new List<Gear> { gears[2] };

            // marcus
            gears[4].Squad = squads[0];
            ((Officer)gears[4]).Reports = new List<Gear> { gears[0], gears[1], gears[3] };
        }
    }
}
