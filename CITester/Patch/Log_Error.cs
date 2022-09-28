// -----------------------------------------------------------------------
// <copyright file="Log_Error.cs" company="Mistaken">
// Copyright (c) Mistaken. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using Exiled.API.Features;
using HarmonyLib;
using Mistaken.API.Diagnostics;

namespace Mistaken.CITester
{
    [HarmonyPatch(typeof(Log), nameof(Log.Error), typeof(object))]
    internal static class Log_Error
    {
        private static bool Prefix(object message)
        {
            MasterHandler.LogError(new Exception(message.ToString()), null, "Error Log Catch");
            return true;
        }
    }
}
