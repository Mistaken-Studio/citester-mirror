// -----------------------------------------------------------------------
// <copyright file="ServerConsole_Disconnect.cs" company="Mistaken">
// Copyright (c) Mistaken. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using HarmonyLib;
using Mirror;
using UnityEngine;

namespace Mistaken.CITester
{
    [HarmonyPatch(typeof(ServerConsole), nameof(ServerConsole.Disconnect), typeof(NetworkConnection), typeof(string))]
    internal static class ServerConsole_Disconnect
    {
        private static bool Prefix(NetworkConnection conn, string message)
        {
            return false;
        }
    }
}
