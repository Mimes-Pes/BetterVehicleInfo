using System.IO;
using System.Reflection;
using BetterVehicleInfo.Modules;
using Harmony;
using SMLHelper.V2.Handlers;

// You can use this file almost as-is. Just change the marked lines below. This will be the main file of each mod that tells Harmony to load your changes.
namespace BetterVehicleInfo     // Change this line to match your mod.
{
    public class MainPatcher
    {
        private static Assembly thisAssembly = Assembly.GetExecutingAssembly();
        private static string ModPath = Path.GetDirectoryName(thisAssembly.Location);
        internal static string AssetsFolder = Path.Combine(ModPath, "Assets");

        public static void Patch()
        {
            var harmony = HarmonyInstance.Create("com.mimes.subnautica.bettervehicleinfo");   // Change this line to match your mod.
            var betterVehicleInfo = new BetterVehicleInfoModule();
            betterVehicleInfo.Patch();
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            Config.Load();
            OptionsPanelHandler.RegisterModOptions(new Options());
        }
    }
}

/*
// Main file of the mod passing info to Harmony to load these changes.
namespace MoonpoolDisplayRepair     // Name of the mod.
{
    public class MainPatcher
    {
        public static void Patch()
        {
            var harmony = HarmonyInstance.Create("com.mimes.subnautica.moonpooldisplayrepair");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            Config.Load();
            OptionsPanelHandler.RegisterModOptions(new Options());
        }

    }
}
*/
