// -----------------------------------------------------------------------
// <copyright file="QueryProcessor_TargetSyncGameplayData.cs" company="Mistaken">
// Copyright (c) Mistaken. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using HarmonyLib;
using Mirror;
using RemoteAdmin;

namespace Mistaken.CITester
{
    [HarmonyPatch(typeof(QueryProcessor), nameof(QueryProcessor.TargetSyncGameplayData))]
    internal static class QueryProcessor_TargetSyncGameplayData
    {
        private static bool Prefix(NetworkConnection conn, bool gd)
        {
            if (conn == null)
                return false;
            return true;
        }
    }
}
