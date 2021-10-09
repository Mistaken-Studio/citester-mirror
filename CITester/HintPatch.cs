// -----------------------------------------------------------------------
// <copyright file="HintPatch.cs" company="Mistaken">
// Copyright (c) Mistaken. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using HarmonyLib;

namespace Gamer.CITester
{
    [HarmonyPatch(typeof(Hints.HintDisplay), "Show")]
    internal static class HintPatch
    {
#pragma warning disable SA1313 // Parameter names should begin with lower-case letter
        private static bool Prefix(Hints.HintDisplay __instance)
#pragma warning restore SA1313 // Parameter names should begin with lower-case letter
        {
            return false;
        }
    }
}
