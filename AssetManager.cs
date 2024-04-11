using BepInEx.Logging;
using System.Collections.Generic;
using UnityEngine;

namespace TestMission {
    public static class AssetManager {
        private static List<Object> LoadBundle (ManualLogSource logger, AssetBundle bundle) {
            if (bundle == null) {
                logger.LogError ("Asset bundle could not be loaded!");
                return null;
            }
            List<Object> objects = new List<Object> (bundle.LoadAllAssets ());
            bundle.Unload (false);
            logger.LogInfo ("All assets are loaded!");
            return objects;
        }

        /// <summary>
        /// Loads asset bundles from file. DO NOT CALL BEFORE THE SCENE IS LOADED.
        /// </summary>
        /// <param name="logger">The logger to use</param>
        /// <param name="src">The location of the file to read</param>
        /// <returns>A list of the loaded Unity objects</returns>
        public static List<Object> LoadAssets (ManualLogSource logger, string src) {
            logger.LogInfo ("Loading asset bundles from file...");
            AssetBundle bundle = AssetBundle.LoadFromFile (src);
            return LoadBundle (logger, bundle);
        }

        /// <summary>
        /// Loads asset bundles from file. DO NOT CALL BEFORE THE SCENE IS LOADED.
        /// </summary>
        /// <param name="logger">The logger to use</param>
        /// <param name="data">The data of the bundle</param>
        /// <returns>A list of the loaded Unity objects</returns>
        public static List<Object> LoadAssets (ManualLogSource logger, byte[] data) {
            logger.LogInfo ("Loading asset bundles from memory...");
            AssetBundle bundle = AssetBundle.LoadFromMemory (data);
            return LoadBundle (logger, bundle);
        }
    }
}
