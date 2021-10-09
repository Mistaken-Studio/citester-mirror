// -----------------------------------------------------------------------
// <copyright file="PlayableScps_Scp096_OnDamage.cs" company="Mistaken">
// Copyright (c) Mistaken. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using HarmonyLib;

namespace Mistaken.CITester
{
    [HarmonyPatch(typeof(PlayableScps.Scp096), nameof(PlayableScps.Scp096.OnDamage))]
    internal static class PlayableScps_Scp096_OnDamage
    {
        private static bool Prefix(PlayerStats.HitInfo info)
        {
            return false;
        }
    }
}
