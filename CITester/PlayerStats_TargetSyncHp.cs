// -----------------------------------------------------------------------
// <copyright file="PlayerStats_TargetSyncHp.cs" company="Mistaken">
// Copyright (c) Mistaken. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using HarmonyLib;
using Mirror;

namespace Mistaken.CITester
{
    [HarmonyPatch(typeof(PlayerStats), nameof(PlayerStats.TargetSyncHp))]
    internal static class PlayerStats_TargetSyncHp
    {
        private static bool Prefix(NetworkConnection conn, float hp)
        {
            if (conn == null)
                return false;
            return true;
        }
    }
}
