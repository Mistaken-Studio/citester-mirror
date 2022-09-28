// -----------------------------------------------------------------------
// <copyright file="GhostMode.cs" company="Mistaken">
// Copyright (c) Mistaken. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using HarmonyLib;

namespace Gamer.CITester
{
    [HarmonyPatch(typeof(PlayerPositionManager), "TransmitData")]
    internal static class GhostMode
    {
#pragma warning disable IDE0051 // Usuń nieużywane prywatne składowe
#pragma warning disable SA1313 // Parameter names should begin with lower-case letter
        private static bool Prefix(PlayerPositionManager __instance)
#pragma warning restore SA1313 // Parameter names should begin with lower-case letter
#pragma warning restore IDE0051 // Usuń nieużywane prywatne składowe
        {
            return false;
        }
    }
}
