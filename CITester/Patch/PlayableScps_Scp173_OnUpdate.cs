// -----------------------------------------------------------------------
// <copyright file="PlayableScps_Scp173_OnUpdate.cs" company="Mistaken">
// Copyright (c) Mistaken. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using HarmonyLib;
using UnityEngine;

namespace Mistaken.CITester
{
    [HarmonyPatch(typeof(PlayableScps.Scp173), nameof(PlayableScps.Scp173.OnUpdate))]
    internal static class PlayableScps_Scp173_OnUpdate
    {
        private static bool Prefix()
        {
            return false;
        }
    }
}
