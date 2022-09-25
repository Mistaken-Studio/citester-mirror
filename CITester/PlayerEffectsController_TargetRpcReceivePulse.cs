// -----------------------------------------------------------------------
// <copyright file="PlayerEffectsController_TargetRpcReceivePulse.cs" company="Mistaken">
// Copyright (c) Mistaken. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using HarmonyLib;
using InventorySystem;
using Mirror;
using PlayerStatsSystem;

namespace Mistaken.CITester
{
    [HarmonyPatch(typeof(PlayerEffectsController), nameof(PlayerEffectsController.TargetRpcReceivePulse))]
    internal static class PlayerEffectsController_TargetRpcReceivePulse
    {
#pragma warning disable SA1313 // Parameter names should begin with lower-case letter
        private static bool Prefix(PlayerEffectsController __instance, byte effectIndex)
#pragma warning restore SA1313 // Parameter names should begin with lower-case letter
        {
            if (__instance.connectionToClient == null)
                return false;
            return true;
        }
    }
}
