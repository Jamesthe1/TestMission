using System.IO;
using System.Collections.Generic;
using BepInEx;
using UnityEngine;

using MissionLoader;

namespace TestMission {
    [BepInDependency ("MissionLoader")]
    [BepInPlugin (PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin {
        private void Awake () {
            NodeSpawner.SceneReady += SpawnOnLoaded;
            Logger.LogInfo ("Initial loading done!");
            Logger.LogInfo ("Current directory: " + Directory.GetCurrentDirectory ());
        }

        private void SpawnOnLoaded () {
            NodeSpawner.SceneReady -= SpawnOnLoaded;
            Logger.LogInfo ("Loading objects from assets");
            List<Object> objects = AssetManager.LoadAssets (Logger, Resources.AssetBundleRsrc.testmission);
            if (objects == null) {
                Logger.LogWarning ("Failed to load objects, check Unity logs for details");
                return;
            }

            Logger.LogInfo ("Readying node data...");
            List<NamedNodeDatum> namedNodeData = new List<NamedNodeDatum> { new NamedNodeDatum ("MISSION_TEST_001", new List<string> { "NODE_BOARDING_001", "NODE_BRAWL_003" }, "NODE_MIXUP"),
                                                                            new NamedNodeDatum ("MISSION_TEST_002", new List<string> { "NODE_BOARDING_001", "NODE_ROYALGUARD_003" })
                                                                          };
            NodeSpawner.FindAndReadyNodes (namedNodeData, objects);
        }
    }
}
