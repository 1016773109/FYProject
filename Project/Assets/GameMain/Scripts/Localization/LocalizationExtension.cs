using GameFramework;
using UnityGameFramework.Runtime;

namespace FYProject
{
    public static class LocalizationExtension
    {
        public static void LoadDictionary(this LocalizationComponent localizationComponent, string dictionaryName, object userData = null)
        {
            if (dictionaryName.IsNullOrEmpty())
            {
                Log.Warning("Dictionary name is invalid.");
                return;
            }

            localizationComponent.LoadDictionary(dictionaryName, AssetUitity.GetConfigAsset(dictionaryName), Constant.AssetPriority.ConfigAsset, userData);
        }

    }
}
