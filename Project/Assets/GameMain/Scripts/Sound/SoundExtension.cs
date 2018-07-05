using GameFramework;
using GameFramework.Sound;
using UnityGameFramework.Runtime;

namespace FYProject
{
    public static class SoundExtension
    {
        private const float FadeVolumeDuration = 1f;


        public static int? PlayUISound(this SoundComponent soundComponent, int uiSoundId, object userData = null)
        {
            var dtUISound = GameEntry.DataTable.GetDataTable<DRUISound>();
            var drUISound = dtUISound.GetDataRow(uiSoundId);
            if (drUISound == null)
            {
                Log.Warning("Can not load UI sound '{0}' from data table.", uiSoundId.ToString());
                return null;
            }

            PlaySoundParams playSoundParams = new PlaySoundParams();
            playSoundParams.Priority = drUISound.Priority;
            playSoundParams.Loop = false;
            playSoundParams.VolumeInSoundGroup = drUISound.Volume;
            playSoundParams.SpatialBlend = 0f;

            return soundComponent.PlaySound(AssetUitity.GetUISoundAsset(drUISound.AssetName), "UISound", Constant.AssetPriority.UISoundAsset, playSoundParams, userData);
        }

        public static int? PlayMusic(this SoundComponent soundComponent, int musicId, object userData = null)
        {
            var dtMusic = GameEntry.DataTable.GetDataTable<DRMusic>();
            var drMusic = dtMusic.GetDataRow(musicId);
            if (drMusic == null)
            {
                Log.Warning("Can not load music '{0}' from data table.", musicId.ToString());
                return null;
            }

            PlaySoundParams playSoundParams = new PlaySoundParams();
            playSoundParams.Priority = 64;
            playSoundParams.Loop = true;
            playSoundParams.VolumeInSoundGroup = 1f;
            playSoundParams.FadeInSeconds = FadeVolumeDuration;
            playSoundParams.SpatialBlend = 0f;

            return soundComponent.PlaySound(AssetUitity.GetMusicAsset(drMusic.AssetName), "Music", Constant.AssetPriority.MusicAsset, playSoundParams, userData);
        }


    }
}
