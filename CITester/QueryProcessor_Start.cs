// -----------------------------------------------------------------------
// <copyright file="QueryProcessor_Start.cs" company="Mistaken">
// Copyright (c) Mistaken. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using HarmonyLib;
using Mirror;
using RemoteAdmin;

namespace Mistaken.CITester
{
    [HarmonyPatch(typeof(QueryProcessor), nameof(QueryProcessor.Start))]
    internal static class QueryProcessor_Start
    {
        private static bool Prefix()
        {
            return false;
        }
    }
}
