// -----------------------------------------------------------------------
// <copyright file="PlayerStats_TargetReceiveSpecificDeathReason.cs" company="Mistaken">
// Copyright (c) Mistaken. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using HarmonyLib;
using InventorySystem;
using Mirror;
using PlayerStatsSystem;

namespace Mistaken.CITester
{
    [HarmonyPatch(typeof(PlayerStats), nameof(PlayerStats.TargetReceiveSpecificDeathReason))]
    internal static class PlayerStats_TargetReceiveSpecificDeathReason
    {
#pragma warning disable SA1313 // Parameter names should begin with lower-case letter
        private static bool Prefix(PlayerStats __instance, DamageHandlerBase handler)
#pragma warning restore SA1313 // Parameter names should begin with lower-case letter
        {
            if (__instance.connectionToClient == null)
                return false;
            return true;
        }
    }
}
