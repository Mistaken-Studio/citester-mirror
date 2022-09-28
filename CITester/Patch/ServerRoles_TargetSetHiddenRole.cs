// -----------------------------------------------------------------------
// <copyright file="ServerRoles_TargetSetHiddenRole.cs" company="Mistaken">
// Copyright (c) Mistaken. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using HarmonyLib;
using Mirror;

namespace Mistaken.CITester
{
    [HarmonyPatch(typeof(ServerRoles), nameof(ServerRoles.TargetSetHiddenRole))]
    internal static class ServerRoles_TargetSetHiddenRole
    {
        private static bool Prefix(NetworkConnection connection, string role)
        {
            if (connection == null)
                return false;
            return true;
        }
    }
}
