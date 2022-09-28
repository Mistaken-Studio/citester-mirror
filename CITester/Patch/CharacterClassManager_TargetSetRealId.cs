// -----------------------------------------------------------------------
// <copyright file="CharacterClassManager_TargetSetRealId.cs" company="Mistaken">
// Copyright (c) Mistaken. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using HarmonyLib;
using Mirror;

namespace Mistaken.CITester
{
    [HarmonyPatch(typeof(CharacterClassManager), nameof(CharacterClassManager.TargetSetRealId))]
    internal static class CharacterClassManager_TargetSetRealId
    {
        private static bool Prefix(NetworkConnection conn, string userId)
        {
            if (conn == null)
                return false;
            return true;
        }
    }
}
