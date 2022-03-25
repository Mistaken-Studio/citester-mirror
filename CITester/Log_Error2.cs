// -----------------------------------------------------------------------
// <copyright file="Log_Error2.cs" company="Mistaken">
// Copyright (c) Mistaken. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using Exiled.API.Features;
using HarmonyLib;
using Mistaken.API.Diagnostics;

namespace Mistaken.CITester
{
    [HarmonyPatch(typeof(Log), nameof(Log.Error), typeof(string))]
    internal static class Log_Error2
    {
        private static bool Prefix(string message)
        {
            MasterHandler.LogError(new Exception(message), null, "Error Log Catch");
            return true;
        }
    }
}
