using FYProject;
using GameFramework.Event;
using GameFramework.Sound;
using UnityEngine;

public class Test : MonoBehaviour
{
    int soundId = 0;

    void Start()
    {
        GameEntry.Event.Subscribe(UnityGameFramework.Runtime.PlaySoundSuccessEventArgs.EventId, OnPlaySoundSuccess);
    }

    ISoundAgent soundAgent;

    void OnPlaySoundSuccess(object sender, GameEventArgs e)
    {
        UnityGameFramework.Runtime.PlaySoundSuccessEventArgs ne = (UnityGameFramework.Runtime.PlaySoundSuccessEventArgs)e;

        soundAgent = ne.SoundAgent;
    }

    private void OnGUI()
    {
        if (GUILayout.Button("PlaySound1"))
        {
            soundId = PlaySound("click");
        }

        if (GUILayout.Button("ResumeSound1"))
        {
            if (soundAgent == null)
            {
                Debug.Log("SoundAgent is null");
            }
            else
            {
                soundAgent.Play();
            }
        }

    }

    public int PlaySound(string assetName)
    {
        PlaySoundParams playSoundParams = new PlaySoundParams();
        playSoundParams.Priority = 0;
        playSoundParams.Loop = false;
        playSoundParams.VolumeInSoundGroup = 1;
        playSoundParams.SpatialBlend = 0f;

        return GameEntry.Sound.PlaySound(AssetUtility.GetUISoundAsset(assetName), "UISound", Constant.AssetPriority.UISoundAsset, playSoundParams);
    }

    public void ResumeSound(int seriaId)
    {
        GameEntry.Sound.ResumeSound(seriaId);
    }
}
