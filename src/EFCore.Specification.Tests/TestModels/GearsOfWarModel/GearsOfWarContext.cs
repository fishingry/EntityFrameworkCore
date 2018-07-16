// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Microsoft.EntityFrameworkCore.TestModels.GearsOfWarModel
{
    public class GearsOfWarContext
    {
        public static void Seed()
        {
            var squads = GearsOfWarData.CreateSquads();
            var gears = GearsOfWarData.CreateGears();

            GearsOfWarData.WireUp(squads, gears);
        }
    }
}
