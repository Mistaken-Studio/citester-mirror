// -----------------------------------------------------------------------
// <copyright file="PlayerMovementSync_TargetForcePosition.cs" company="Mistaken">
// Copyright (c) Mistaken. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using HarmonyLib;
using Mirror;
using UnityEngine;

namespace Mistaken.CITester
{
    [HarmonyPatch(typeof(PlayerMovementSync), nameof(PlayerMovementSync.TargetForcePosition))]
    internal static class PlayerMovementSync_TargetForcePosition
    {
        private static bool Prefix(NetworkConnection conn, Vector3 pos)
        {
            if (conn == null)
                return false;
            return true;
        }
    }
}
