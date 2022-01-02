// -----------------------------------------------------------------------
// <copyright file="QueryProcessor_Start.cs" company="Mistaken">
// Copyright (c) Mistaken. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Security.Cryptography;
using HarmonyLib;
using Mirror;
using RemoteAdmin;

namespace Mistaken.CITester
{
    [HarmonyPatch(typeof(QueryProcessor), nameof(QueryProcessor.Start))]
    internal static class QueryProcessor_Start
    {
#pragma warning disable SA1313 // Parameter names should begin with lower-case letter
        private static bool Prefix(QueryProcessor __instance)
#pragma warning restore SA1313 // Parameter names should begin with lower-case letter
        {
            __instance._hub = global::ReferenceHub.GetHub(__instance.gameObject);
            __instance._commandRateLimit = __instance._hub.playerRateLimitHandler.RateLimits[2];
            __instance._roles = __instance._hub.serverRoles;
            __instance.CryptoManager = __instance.GetComponent<RemoteAdminCryptographicManager>();
            __instance.GCT = __instance.GetComponent<global::GameConsoleTransmission>();
            __instance.SignaturesCounter = 0;
            __instance._signaturesCounter = 0;

            __instance.NetworkPlayerId = QueryProcessor._idIterator++;
            __instance._conns = __instance.connectionToClient;
            __instance._ipAddress = "127.0.0.1";
            __instance.NetworkOverridePasswordEnabled = global::ServerStatic.PermissionsHandler.OverrideEnabled;
            if (string.IsNullOrEmpty(QueryProcessor._serverStaticRandom))
            {
                byte[] array;
                using (RandomNumberGenerator randomNumberGenerator = new RNGCryptoServiceProvider())
                {
                    array = new byte[32];
                    randomNumberGenerator.GetBytes(array);
                }

                QueryProcessor._serverStaticRandom = Convert.ToBase64String(array);
                global::ServerConsole.AddLog("Generated round random salt: " + QueryProcessor._serverStaticRandom, ConsoleColor.Gray);
            }

            if (string.IsNullOrEmpty(__instance.ServerRandom))
                __instance.NetworkServerRandom = QueryProcessor._serverStaticRandom;

            __instance._sender = new PlayerCommandSender(__instance);
            return false;
        }
    }
}
