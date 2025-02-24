using BepInEx;
using System;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace SubscribeBoard
{
    public class SubscribeBoardPlugin : BaseUnityPlugin // Renamed from Plugin to SubscribeBoardPlugin
    {
        private AssetBundle assetBundle;

        // Initialize method to load the asset bundle and spawn the object
        void Awake()
        {
            try
            {
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("SubscribeBoard.res.subscribes"))
                {
                    if (stream == null)
                    {
                        Debug.LogError("Failed to load resource stream. Please make an issue, as gabora helped me write this.");
                        return;
                    }

                    assetBundle = AssetBundle.LoadFromStream(stream);
                }

                GameObject subscribeBoard = Instantiate(assetBundle.LoadAsset<GameObject>("SubscribeBoard"));
                subscribeBoard.transform.position = new Vector3(-62.732f, 12.9482f, -83.786f);
                subscribeBoard.transform.rotation = Quaternion.Euler(0, 96, 0);
            }
            catch (Exception ex)
            {
                Debug.LogError($"An error occurred while loading the asset bundle: {ex.Message}");
            }
        }
    }
}
