using GameFramework;
using UnityGameFramework.Runtime;

namespace FYProject
{
    public static class ConfigExtension
    {
        public static void LoadConfig(this ConfigComponent configComponent, string configName, object userData = null)
        {
            if (configName.IsNullOrEmpty())
            {
                Log.Warning("Config name is invalid.");
                return;
            }

            configComponent.LoadConfig(configName, AssetUitity.GetConfigAsset(configName), Constant.AssetPriority.ConfigAsset, userData);
        }

    }
}
