// -----------------------------------------------------------------------
// <copyright file="MirrorExtensions_SendFakeSyncVar.cs" company="Mistaken">
// Copyright (c) Mistaken. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using Exiled.API.Extensions;
using Exiled.API.Features;
using HarmonyLib;
using Mirror;

namespace Mistaken.CITester
{
    [HarmonyPatch(typeof(MirrorExtensions), nameof(MirrorExtensions.SendFakeSyncVar))]
    internal static class MirrorExtensions_SendFakeSyncVar
    {
        private static bool Prefix(Player target, NetworkIdentity behaviorOwner, Type targetType, string propertyName, object value)
        {
            if (target.Connection == null)
                return false;
            return true;
        }
    }
}
