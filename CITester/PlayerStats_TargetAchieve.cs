// -----------------------------------------------------------------------
// <copyright file="PlayerStats_TargetAchieve.cs" company="Mistaken">
// Copyright (c) Mistaken. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using HarmonyLib;
using Mirror;

namespace Mistaken.CITester
{
    [HarmonyPatch(typeof(PlayerStats), nameof(PlayerStats.TargetAchieve))]
    internal static class PlayerStats_TargetAchieve
    {
        private static bool Prefix(NetworkConnection conn, string key)
        {
            if (conn == null)
                return false;
            return true;
        }
    }
}
