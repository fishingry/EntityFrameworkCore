// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Microsoft.EntityFrameworkCore.TestModels.GearsOfWarModel
{
    public class GearsOfWarContext : DbContext
    {
        public static readonly string StoreName = "GearsOfWar";

        public GearsOfWarContext(DbContextOptions options)
            : base(options)
        {
        }

        public static void Seed()
        {
            var squads = GearsOfWarData.CreateSquads();
            var missions = GearsOfWarData.CreateMissions();
            var squadMissions = GearsOfWarData.CreateSquadMissions();
            var cities = GearsOfWarData.CreateCities();
            var weapons = GearsOfWarData.CreateWeapons();
            var tags = GearsOfWarData.CreateTags();
            var gears = GearsOfWarData.CreateGears();
            var locustLeaders = GearsOfWarData.CreateLocustLeaders();
            var factions = GearsOfWarData.CreateFactions();
            var locustHighCommands = GearsOfWarData.CreateHighCommands();

            GearsOfWarData.WireUp(squads, missions, squadMissions, cities, weapons, tags, gears, locustLeaders, factions, locustHighCommands);
            GearsOfWarData.WireUp2(locustLeaders, factions);
        }
    }
}
