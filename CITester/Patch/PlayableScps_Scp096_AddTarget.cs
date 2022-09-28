// -----------------------------------------------------------------------
// <copyright file="PlayableScps_Scp096_AddTarget.cs" company="Mistaken">
// Copyright (c) Mistaken. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using HarmonyLib;
using UnityEngine;

namespace Mistaken.CITester
{
    [HarmonyPatch(typeof(PlayableScps.Scp096), nameof(PlayableScps.Scp096.AddTarget))]
    internal static class PlayableScps_Scp096_AddTarget
    {
        private static bool Prefix(GameObject target)
        {
            return false;
        }
    }
}
