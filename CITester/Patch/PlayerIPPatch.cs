// -----------------------------------------------------------------------
// <copyright file="PlayerIPPatch.cs" company="Mistaken">
// Copyright (c) Mistaken. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Exiled.API.Features;
using HarmonyLib;

namespace Mistaken.CITester
{
#pragma warning disable IDE0060 // Usuń nieużywany parametr
    [HarmonyPatch(typeof(Player), "get_IPAddress")]
    internal static class PlayerIPPatch
    {
#pragma warning disable SA1313 // Parameter names should begin with lower-case letter
        private static bool Prefix(Player __instance, ref string __result)
#pragma warning restore SA1313 // Parameter names should begin with lower-case letter
        {
            __result = __instance.ReferenceHub.queryProcessor._ipAddress;
            return false;
        }
    }
}
