// -----------------------------------------------------------------------
// <copyright file="PlayerMovementSync_TargetSetRotation.cs" company="Mistaken">
// Copyright (c) Mistaken. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using HarmonyLib;
using Mirror;

namespace Mistaken.CITester
{
    [HarmonyPatch(typeof(PlayerMovementSync), nameof(PlayerMovementSync.TargetSetRotation))]
    internal static class PlayerMovementSync_TargetSetRotation
    {
        private static bool Prefix(NetworkConnection conn, float rot)
        {
            if (conn == null)
                return false;
            return true;
        }
    }
}
