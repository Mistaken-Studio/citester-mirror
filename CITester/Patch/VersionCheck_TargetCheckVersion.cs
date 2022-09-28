// -----------------------------------------------------------------------
// <copyright file="VersionCheck_TargetCheckVersion.cs" company="Mistaken">
// Copyright (c) Mistaken. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using HarmonyLib;
using Mirror;

namespace Mistaken.CITester
{
    [HarmonyPatch(typeof(VersionCheck), nameof(VersionCheck.TargetCheckVersion))]
    internal static class VersionCheck_TargetCheckVersion
    {
        private static bool Prefix(NetworkConnection conn, byte major, byte minor, byte revision)
        {
            if (conn == null)
                return false;
            return true;
        }
    }
}
