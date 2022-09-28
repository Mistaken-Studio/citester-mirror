// -----------------------------------------------------------------------
// <copyright file="CharacterClassManager_TargetConsolePrint.cs" company="Mistaken">
// Copyright (c) Mistaken. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using HarmonyLib;
using Mirror;

namespace Mistaken.CITester
{
    [HarmonyPatch(typeof(CharacterClassManager), nameof(CharacterClassManager.TargetConsolePrint))]
    internal static class CharacterClassManager_TargetConsolePrint
    {
        private static bool Prefix(NetworkConnection connection, string text, string color)
        {
            if (connection == null)
                return false;
            return true;
        }
    }
}
