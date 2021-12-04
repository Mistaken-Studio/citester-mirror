// -----------------------------------------------------------------------
// <copyright file="PlayerStats_SyncedStatBase.cs" company="Mistaken">
// Copyright (c) Mistaken. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using HarmonyLib;
using UnityEngine;

namespace Mistaken.CITester
{
    [HarmonyPatch(typeof(PlayerStatsSystem.SyncedStatBase), nameof(PlayerStatsSystem.SyncedStatBase.Update))]
    internal static class PlayerStats_SyncedStatBase
    {
        private static bool Prefix()
        {
            return false;
        }
    }
}
