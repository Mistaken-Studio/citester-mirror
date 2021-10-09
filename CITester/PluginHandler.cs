// -----------------------------------------------------------------------
// <copyright file="PluginHandler.cs" company="Mistaken">
// Copyright (c) Mistaken. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using Exiled.API.Enums;
using Exiled.API.Features;
using HarmonyLib;

namespace Mistaken.CITester
{
    /// <inheritdoc/>
    public class PluginHandler : Plugin<Config>
    {
        /// <inheritdoc/>
        public override string Author => "Mistaken Devs";

        /// <inheritdoc/>
        public override string Name => "CI Tester";

        /// <inheritdoc/>
        public override string Prefix => "MCI";

        /// <inheritdoc/>
        public override PluginPriority Priority => PluginPriority.Lowest;

        /// <inheritdoc/>
        public override Version RequiredExiledVersion => new Version(3, 0, 3);

        /// <inheritdoc/>
        public override void OnEnabled()
        {
            Instance = this;

            IdleMode.PauseIdleMode = true;

            Exiled.Events.Events.DisabledPatchesHashSet.Add(typeof(PlayerPositionManager).GetMethod("TransmitData", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance));
            Exiled.Events.Events.DisabledPatchesHashSet.Add(typeof(PlayableScps.Scp096).GetMethod(nameof(PlayableScps.Scp096.AddTarget)));
            Exiled.Events.Events.Instance.ReloadDisabledPatches();

            var harmony = new Harmony("mistaken.citester");
            harmony.PatchAll();

            new CIModule(this);

            API.Diagnostics.Module.OnEnable(this);

            base.OnEnabled();
        }

        /// <inheritdoc/>
        public override void OnDisabled()
        {
            IdleMode.PauseIdleMode = false;

            API.Diagnostics.Module.OnDisable(this);

            base.OnDisabled();
        }

        internal static PluginHandler Instance { get; private set; }
    }
}
