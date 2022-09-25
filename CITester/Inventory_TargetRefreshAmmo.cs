// -----------------------------------------------------------------------
// <copyright file="Inventory_TargetRefreshAmmo.cs" company="Mistaken">
// Copyright (c) Mistaken. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using HarmonyLib;
using InventorySystem;
using Mirror;
using PlayerStatsSystem;

namespace Mistaken.CITester
{
    [HarmonyPatch(typeof(Inventory), nameof(Inventory.TargetRefreshAmmo))]
    internal static class Inventory_TargetRefreshAmmo
    {
#pragma warning disable SA1313 // Parameter names should begin with lower-case letter
        private static bool Prefix(Inventory __instance, byte[] keys, ushort[] values)
#pragma warning restore SA1313 // Parameter names should begin with lower-case letter
        {
            if (__instance.connectionToClient == null)
                return false;
            return true;
        }
    }
}
