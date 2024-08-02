using BepInEx;
using System;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.Assertions;

namespace SubscribeBoard
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        AssetBundle bundle;

        void Start()
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SubscribeBoard.res.subscribes");
            bundle = AssetBundle.LoadFromStream(stream);
            if (stream == null)
            {
                Debug.LogError("STREAM IS NULL. NOT LOADING ASSETS");
            }
            stream.Close();

            GameObject untitled0 = Instantiate(bundle.LoadAsset<GameObject>("SubscribeBoard"));
            untitled0.transform.position = new Vector3(-62.732f, 12.9482f, -83.786f);
            untitled0.transform.rotation = Quaternion.Euler(0, 96, 0);
        }
    }
}