// -----------------------------------------------------------------------
// <copyright file="PlayerStatsSystem_SyncedStatMessages_SendAllStats.cs" company="Mistaken">
// Copyright (c) Mistaken. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using HarmonyLib;
using UnityEngine;

namespace Mistaken.CITester
{
    [HarmonyPatch(typeof(PlayerStatsSystem.SyncedStatMessages), nameof(PlayerStatsSystem.SyncedStatMessages.SendAllStats))]
    internal static class PlayerStatsSystem_SyncedStatMessages_SendAllStats
    {
        private static bool Prefix()
        {
            return false;
        }
    }
}
