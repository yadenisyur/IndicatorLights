﻿using UnityEngine;

namespace IndicatorLights
{
    /// <summary>
    /// These are the logical identifiers of default colors that the modules in this
    /// assembly will use if not told otherwise via config.
    /// 
    /// Each of these has a corresponding setting in Configuration to supply a value.
    /// </summary>
    public enum DefaultColor
    {
        // Maintenance note: any time a value is added to this list, need to update
        // the DefaultValue and Value extension methods.

        /// <summary>
        /// The color used for lights that are "turned off".
        /// Defaults to black.
        /// </summary>
        Off,

        /// <summary>
        /// The "on" color used for user-toggleable lights.
        /// Defaults to bright green.
        /// </summary>
        ToggleLED,

        /// <summary>
        /// The color used to indicate that a resource container is nearly full.
        /// Defaults to bright green.
        /// </summary>
        HighResource,

        /// <summary>
        /// The color used to indicate that a resource container is partially full.
        /// Defaults to yellow.
        /// </summary>
        MediumResource,

        /// <summary>
        /// The color used to indicate that a resource container is nearly empty.
        /// Defaults to red.
        /// </summary>
        LowResource,

        /// <summary>
        /// The color used to indicate that a reaction wheel is having a problem and can't function properly.
        /// Defaults to red.
        /// </summary>
        ReactionWheelProblem,

        /// <summary>
        /// The color used to indicate that a reaction wheel is set to "normal" mode (pilot + SAS).
        /// Defaults to green.
        /// </summary>
        ReactionWheelNormal,

        /// <summary>
        /// The color used to indicate that a reaction wheel is set to "pilot only" mode.
        /// Defaults to blue.
        /// </summary>
        ReactionWheelPilotOnly,

        /// <summary>
        /// The color used to indicate that a reaction wheel is set to "SAS only" mode.
        /// Defaults to yellow.
        /// </summary>
        ReactionWheelSASOnly,

        /// <summary>
        /// The color used to indicate that a docking port has crossfeed enabled.
        /// Defaults to green.
        /// </summary>
        DockingCrossfeedOn,

        /// <summary>
        /// The color used to indicate that a docking port has crossfeed disabled.
        /// Defaults to red.
        /// </summary>
        DockingCrossfeedOff,

        /// <summary>
        /// The color used to indicate that a crewable slot contains a pilot.
        /// Defaults to orange.
        /// </summary>
        CrewPilot,

        /// <summary>
        /// The color used to indicate that a crewable slot contains an engineer.
        /// Defaults to green.
        /// </summary>
        CrewEngineer,

        /// <summary>
        /// The color used to indicate that a crewable slot contains a scientist.
        /// Defaults to blue.
        /// </summary>
        CrewScientist,

        /// <summary>
        /// The color used to indicate that a crewable slot contains a tourist.
        /// Defaults to white.
        /// </summary>
        CrewTourist,

        /// <summary>
        /// The color associated with liquid fuel + oxidizer resources.
        /// Defaults to cyan.
        /// </summary>
        ResourceLFO,

        /// <summary>
        /// The color associated with liquid fuel resources.
        /// Defaults to green.
        /// </summary>
        ResourceLiquidFuel,

        /// <summary>
        /// The color associated with oxidizer resources.
        /// Defaults to blue.
        /// </summary>
        ResourceOxidizer,

        /// <summary>
        /// The color associated with monopropellant resources.
        /// Defaults to yellow.
        /// </summary>
        ResourceMonopropellant,

    }

    public static class DefaultColorExtensions
    {
        /// <summary>
        /// Get the name of the enum as listed in the configuration file.
        /// </summary>
        /// <param name="defaultColor"></param>
        /// <returns></returns>
        public static string ConfigurationName(this DefaultColor defaultColor)
        {
            return defaultColor.ToString() + "Color";
        }

        /// <summary>
        /// Gets the default value to use for this color if no configuration is available.
        /// </summary>
        /// <param name="defaultColor"></param>
        /// <returns></returns>
        public static Color DefaultValue(this DefaultColor defaultColor)
        {
            switch (defaultColor)
            {
                case DefaultColor.Off:
                    return Color.black;
                case DefaultColor.ToggleLED:
                    return Color.green;
                case DefaultColor.HighResource:
                    return Color.green;
                case DefaultColor.MediumResource:
                    return Color.yellow * 0.7f;
                case DefaultColor.LowResource:
                    return Color.red * 0.5f;
                case DefaultColor.ReactionWheelProblem:
                    return Color.red;
                case DefaultColor.ReactionWheelNormal:
                    return Color.green;
                case DefaultColor.ReactionWheelPilotOnly:
                    return Color.blue;
                case DefaultColor.ReactionWheelSASOnly:
                    return Color.yellow * 0.7f;
                case DefaultColor.DockingCrossfeedOn:
                    return Color.green * 0.7f;
                case DefaultColor.DockingCrossfeedOff:
                    return Color.red * 0.6f;
                case DefaultColor.CrewPilot:
                    return Color.Lerp(new Color(0.5f, 0.3f, 0, 1), Color.gray, 0.1f);
                case DefaultColor.CrewEngineer:
                    return Color.Lerp(Color.green * 0.6f, Color.gray, 0.1f);
                case DefaultColor.CrewScientist:
                    return Color.Lerp(Color.blue, Color.gray, 0.1f);
                case DefaultColor.CrewTourist:
                    return Color.gray;
                case DefaultColor.ResourceLFO:
                    return Color.Lerp(DefaultColor.ResourceLiquidFuel.DefaultValue(), DefaultColor.ResourceOxidizer.DefaultValue(), 0.5f);
                case DefaultColor.ResourceLiquidFuel:
                    return Color.green;
                case DefaultColor.ResourceOxidizer:
                    return new Color(0.1f, 0.4f, 1, 1);
                case DefaultColor.ResourceMonopropellant:
                    return 0.9f * new Color(0.9f, 0.76f, 0, 1);
                default:
                    // this should only happen if there's a bug... pick an odd color to make it obvious
                    return Color.magenta;
            }
        }

        /// <summary>
        /// Gets the value for this color, as specified in the configuration file.
        /// </summary>
        /// <param name="defaultColor"></param>
        /// <returns></returns>
        public static Color Value(this DefaultColor defaultColor)
        {
            switch (defaultColor)
            {
                case DefaultColor.Off:
                    return defaultColor.DefaultValue();
                case DefaultColor.ToggleLED:
                    return Configuration.toggleLEDColor;
                case DefaultColor.HighResource:
                    return Configuration.highResourceColor;
                case DefaultColor.MediumResource:
                    return Configuration.mediumResourceColor;
                case DefaultColor.LowResource:
                    return Configuration.lowResourceColor;
                case DefaultColor.ReactionWheelProblem:
                    return Configuration.reactionWheelProblemColor;
                case DefaultColor.ReactionWheelNormal:
                    return Configuration.reactionWheelNormalColor;
                case DefaultColor.ReactionWheelPilotOnly:
                    return Configuration.reactionWheelPilotOnlyColor;
                case DefaultColor.ReactionWheelSASOnly:
                    return Configuration.reactionWheelSasOnlyColor;
                case DefaultColor.DockingCrossfeedOn:
                    return Configuration.dockingCrossfeedOnColor;
                case DefaultColor.DockingCrossfeedOff:
                    return Configuration.dockingCrossfeedOffColor;
                case DefaultColor.CrewPilot:
                    return Configuration.crewPilotColor;
                case DefaultColor.CrewEngineer:
                    return Configuration.crewEngineerColor;
                case DefaultColor.CrewScientist:
                    return Configuration.crewScientistColor;
                case DefaultColor.CrewTourist:
                    return Configuration.crewTouristColor;
                case DefaultColor.ResourceLFO:
                    return Configuration.lfoColor;
                case DefaultColor.ResourceLiquidFuel:
                    return Configuration.liquidFuelColor;
                case DefaultColor.ResourceOxidizer:
                    return Configuration.oxidizerColor;
                case DefaultColor.ResourceMonopropellant:
                    return Configuration.monopropellantColor;
                default:
                    return defaultColor.DefaultValue();
            }
        }
    }
}