// -----------------------------------------------------------------------
// <copyright file="Achievements_AchievementHandlerBase_ServerAchieve.cs" company="Mistaken">
// Copyright (c) Mistaken. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using HarmonyLib;
using UnityEngine;

namespace Mistaken.CITester
{
    [HarmonyPatch(typeof(Achievements.AchievementHandlerBase), nameof(Achievements.AchievementHandlerBase.ServerAchieve))]
    internal static class Achievements_AchievementHandlerBase_ServerAchieve
    {
        private static bool Prefix()
        {
            return false;
        }
    }
}
