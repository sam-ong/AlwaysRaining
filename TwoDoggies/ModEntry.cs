using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Tools;
using TwoDoggies.Framework;

namespace TwoDoggies
{
    public class ModEntry : Mod
    {
        //private ModConfig config;
        private readonly HashSet<int> normalWeather = new HashSet<int>
            {
                Game1.weather_sunny,
                Game1.weather_rain,
                Game1.weather_lightning,
                Game1.weather_debris,
                Game1.weather_snow
            };

        /*********
        ** Public methods
        *********/
        /// <summary>The mod entry point, called after the mod is first loaded.</summary>
        /// <param name="helper">Provides simplified APIs for writing mods.</param>
        public override void Entry(IModHelper helper)
        {
            //Events
            helper.Events.GameLoop.SaveLoaded += OnSaveLoaded;
            helper.Events.GameLoop.Saving += OnSaving;
        }


        /*********
        ** Private methods
        *********/
        private void OnSaveLoaded(object sender, SaveLoadedEventArgs e)
        {
            this.HandleNewDay();
        }

        private void OnSaving(object sender, SavingEventArgs e)
        {
            this.HandleNewDay();
        }

        private void HandleNewDay()
        {
            if (!this.normalWeather.Contains(Game1.weatherForTomorrow))
            {
                this.Monitor.Log("it no rain", LogLevel.Debug);
                return;
            }
            this.Monitor.Log("it rain", LogLevel.Debug);
            Game1.weatherForTomorrow = Game1.weather_rain;
        }
    }
}