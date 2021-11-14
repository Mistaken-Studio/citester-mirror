// -----------------------------------------------------------------------
// <copyright file="CIModule.cs" company="Mistaken">
// Copyright (c) Mistaken. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Linq;
using CustomPlayerEffects;
using Exiled.API.Features;
using Exiled.API.Interfaces;
using Mirror;
using Mistaken.API;
using Mistaken.API.Diagnostics;
using Mistaken.API.Extensions;
using RemoteAdmin;
using UnityEngine;

namespace Mistaken.CITester
{
    internal class CIModule : Module
    {
        public CIModule(IPlugin<IConfig> plugin)
            : base(plugin)
        {
        }

        public override string Name => "CITester";

        public override void OnDisable()
        {
            Exiled.Events.Handlers.Server.WaitingForPlayers -= this.Server_WaitingForPlayers;
            Exiled.Events.Handlers.Server.RoundStarted -= this.Server_RoundStarted;
            Exiled.Events.Handlers.Server.RestartingRound -= this.Server_RestartingRound;
        }

        public override void OnEnable()
        {
            Exiled.Events.Handlers.Server.WaitingForPlayers += this.Server_WaitingForPlayers;
            Exiled.Events.Handlers.Server.RoundStarted += this.Server_RoundStarted;
            Exiled.Events.Handlers.Server.RestartingRound += this.Server_RestartingRound;
        }

        public int SpawnTestObject(string userId)
        {
            Exiled.Events.Handlers.Player.OnPreAuthenticating(new Exiled.Events.EventArgs.PreAuthenticatingEventArgs(userId, null, 0, 0, "PL", 0));
            GameObject obj = UnityEngine.Object.Instantiate<GameObject>(NetworkManager.singleton.playerPrefab);
            CharacterClassManager ccm = obj.GetComponent<CharacterClassManager>();
            obj.transform.localScale = Vector3.one;
            obj.transform.position = new Vector3(0, 6000, 0);
            QueryProcessor component = obj.GetComponent<QueryProcessor>();
            component.NetworkPlayerId = ++testSubjectId;
            component._ipAddress = "127.0.0.WAN";
            ccm.CurClass = RoleType.None;
            obj.GetComponent<PlayerStats>().SetHPAmount(ccm.Classes.SafeGet(RoleType.None).maxHP);
            obj.GetComponent<NicknameSync>().Network_myNickSync = $"Test subject ({testSubjectId})";
            NetworkServer.Spawn(obj);
            PlayerManager.AddPlayer(obj, CustomNetworkManager.slots);
            this.CallDelayed(
                0.1f,
                () =>
                {
                    try
                    {
                        if (!Player.UnverifiedPlayers.TryGetValue(ccm._hub, out Player player))
                        {
                            player = new Exiled.API.Features.Player(ccm._hub);
                            Exiled.API.Features.Player.UnverifiedPlayers.Add(ccm._hub, player);
                            Exiled.API.Features.Player p = player;
                            Exiled.Events.Handlers.Player.OnJoined(new Exiled.Events.EventArgs.JoinedEventArgs(player));

                            // throw new Exception("Player not found");
                        }

                        // Exiled.Events.Handlers.Player.OnJoined(new Exiled.Events.EventArgs.JoinedEventArgs(player));
                        Player.Dictionary.Add(obj, player);
                        player.IsVerified = true;
                        ccm.NetworkIsVerified = true;
                        ccm.UserId = userId;
                        Exiled.Events.Handlers.Player.OnVerified(new Exiled.Events.EventArgs.VerifiedEventArgs(player));
                        if (player.ReferenceHub == null)
                            throw new Exception("RH is null");
                        if (player.ReferenceHub.inventory == null)
                            throw new Exception("INV is null");
                        if (player.ReferenceHub.inventory._hub == null)
                            throw new Exception("INV's CCM is null");
                        this.Log.Info("Player spawned");
                    }
                    catch (Exception ex)
                    {
                        this.Log.Error(ex);
                        MasterHandler.LogError(ex, this, "SpawningDummy");
                    }
                },
                "SpawnTestSubject");
            return testSubjectId;
        }

        private static int testSubjectId = 2;

        private bool success = false;

        private void Server_RestartingRound()
        {
            if (this.success)
            {
                this.Log.Info("!! Test was successful !!");
                this.CallDelayed(1, () => Environment.Exit(0), "Quit");
            }
            else
            {
                this.Log.Error("!! Test FAILED !!");
                this.CallDelayed(1, () => Environment.Exit(1), "Quit");
            }
        }

        private void Server_RoundStarted()
        {
            this.CallDelayed(
                1,
                () =>
                {
                    try
                    {
                        var player1 = Player.Get(2);
                        if (player1 == null)
                            throw new Exception("Player 1 not found");
                        this.Log.Info("Player 1 found");
                        var player2 = Player.Get(3);
                        if (player2 == null)
                            throw new Exception("Player 2 not found");
                        this.Log.Info("Player 2 found");
                        player1.Role = RoleType.Scp173;
                        player2.Role = RoleType.ClassD;
                        player1.Hurt(10000000000, player2, DamageTypes.E11SR);
                        if (player1.IsAlive)
                            throw new Exception("Player 1 did not die");
                        this.Log.Info("Player 1 died");
                        player1.Role = RoleType.NtfCaptain;
                        if (player1.Role != RoleType.NtfCaptain)
                            throw new Exception("Player 1 did not forceclass");
                        this.Log.Info("Player 1 forceclassed");

                        player1.Hurt(80, player2, DamageTypes.E11SR);
                        if (!player1.IsAlive)
                            throw new Exception("Player 1 died when he shouldn't");
                        this.Log.Info("Player 1 didn't die");

                        player1.EnableEffect<Bleeding>();
                        this.Log.Debug(player1.ReferenceHub.playerEffectsController.GetEffect<Bleeding>()?.Hub?.characterClassManager?.IsVerified ?? false, true);
                        if (!player1.GetEffectActive<Bleeding>())
                            throw new Exception("Player 1 don't have bleeding effect when he should");
                        this.Log.Info("Player 1 have bleeding effect");

                        player2.DisplayNickname = "Test";
                        if (player2.GetDisplayName() != "Test")
                            throw new Exception("Player 2 nickname didn't change");
                        this.Log.Info("Player 2's nickname changed");

                        player2.Kill(DamageTypes.Wall);
                        if (player2.IsAlive)
                            throw new Exception("Player 2 did not die|2");
                        this.Log.Info("Player 2 died");

                        Round.IsLocked = false;
                        this.CallDelayed(
                            2,
                            () =>
                            {
                                try
                                {
                                    if (Round.IsStarted)
                                        throw new Exception("Round didn't end");
                                    this.Log.Info("Round ended");

                                    this.success = true;
                                }
                                catch (System.Exception ex)
                                {
                                    this.Log.Error(ex.Message);
                                    this.Log.Error(ex.StackTrace);
                                    MasterHandler.LogError(ex, this, "RoundStart");
                                }
                            },
                            "RoundStart2");
                    }
                    catch (System.Exception ex)
                    {
                        this.Log.Error(ex.Message);
                        this.Log.Error(ex.StackTrace);
                        MasterHandler.LogError(ex, this, "RoundStart");
                        Round.IsLocked = false;
                    }
                },
                "RoundStart1");
        }

        private void Server_WaitingForPlayers()
        {
            Round.IsLocked = true;
            this.SpawnTestObject("76561198134629649@steam");
            this.SpawnTestObject("barwa@northwood");
            this.CallDelayed(
                1,
                () =>
                {
                    try
                    {
                        if (Player.List.Count() != 2)
                            throw new Exception("Unexpected player count, expected 2 but got " + Player.List.Count());
                        this.Log.Info("2 player on server");

                        if (RealPlayers.List.Count() != 2)
                            throw new Exception("Unexpected real players count, expected 2 but got " + RealPlayers.List.Count());
                        this.Log.Info("2 real players on server");

                        // GameCore.RoundStart.singleton.NetworkTimer = 2;
                        Round.Start();
                    }
                    catch (System.Exception ex)
                    {
                        MasterHandler.LogError(ex, this, "WaitingForPlayers");
                        Round.IsLocked = false;
                    }
                },
                "WaitingForPlayers");
        }
    }
}
