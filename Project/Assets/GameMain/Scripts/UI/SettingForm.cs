using GameFramework.Localization;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace FYProject
{
    public class SettingForm : UGuiForm
    {
        //添加语言时添加一条适配数据
        List<LanguageData> LanguageDataList = new List<LanguageData>()
        {
            new LanguageData(){language = Language.ChineseSimplified, languageStr = "Language.ChineseSimplified" },
            new LanguageData(){language = Language.ChineseTraditional, languageStr = "Language.ChineseTraditional" },
            new LanguageData(){language = Language.English, languageStr = "Language.English" },
        };

        internal class LanguageData
        {
            public Language language;
            public string languageStr;
        }

        [SerializeField]
        private Toggle m_MusicMuteToggle = null;

        [SerializeField]
        private Slider m_MusicVolumeSlider = null;

        [SerializeField]
        private Toggle m_SoundMuteToggle = null;

        [SerializeField]
        private Slider m_SoundVolumeSlider = null;

        [SerializeField]
        private Toggle m_UISoundMuteToggle = null;

        [SerializeField]
        private Slider m_UISoundVolumeSlider = null;

        [SerializeField]
        private CanvasGroup m_LanguageTipsCanvasGroup = null;

        //[SerializeField]
        //private Toggle m_EnglishToggle = null;

        //[SerializeField]
        //private Toggle m_ChineseSimplifiedToggle = null;

        //[SerializeField]
        //private Toggle m_ChineseTraditionalToggle = null;

        [SerializeField]
        private Dropdown m_LanguageDropdown = null;


        private Language m_SelectedLanguage = Language.Unspecified;

        public void OnMusicMuteChanged(bool isOn)
        {
            GameEntry.Sound.Mute("Music", !isOn);
            m_MusicVolumeSlider.gameObject.SetActive(isOn);
        }

        public void OnMusicVolumeChanged(float volume)
        {
            GameEntry.Sound.SetVolume("Music", volume);
        }

        public void OnSoundMuteChanged(bool isOn)
        {
            GameEntry.Sound.Mute("Sound", !isOn);
            m_SoundVolumeSlider.gameObject.SetActive(isOn);
        }

        public void OnSoundVolumeChanged(float volume)
        {
            GameEntry.Sound.SetVolume("Sound", volume);
        }

        public void OnUISoundMuteChanged(bool isOn)
        {
            GameEntry.Sound.Mute("UISound", !isOn);
            m_UISoundVolumeSlider.gameObject.SetActive(isOn);
        }

        public void OnUISoundVolumeChanged(float volume)
        {
            GameEntry.Sound.SetVolume("UISound", volume);
        }

        //public void OnEnglishSelected(bool isOn)
        //{
        //    if (!isOn)
        //    {
        //        return;
        //    }

        //    m_SelectedLanguage = Language.English;
        //    RefreshLanguageTips();
        //}

        //public void OnChineseSimplifiedSelected(bool isOn)
        //{
        //    if (!isOn)
        //    {
        //        return;
        //    }

        //    m_SelectedLanguage = Language.ChineseSimplified;
        //    RefreshLanguageTips();
        //}

        //public void OnChineseTraditionalSelected(bool isOn)
        //{
        //    if (!isOn)
        //    {
        //        return;
        //    }

        //    m_SelectedLanguage = Language.ChineseTraditional;
        //    RefreshLanguageTips();
        //}

        public void OnLanguageChanged(int index)
        {
            if (index >= LanguageDataList.Count)
            {
                return;
            }
            m_SelectedLanguage = LanguageDataList[index].language;
            RefreshLanguageTips();
        }

        public void OnSubmitButtonClick()
        {
            if (m_SelectedLanguage == GameEntry.Localization.Language)
            {
                Close();
                return;
            }

            GameEntry.Setting.SetString(Constant.Setting.Language, m_SelectedLanguage.ToString());
            GameEntry.Setting.Save();

            GameEntry.Sound.StopMusic();
            UnityGameFramework.Runtime.GameEntry.Shutdown(ShutdownType.Restart);
        }

#if UNITY_2017_3_OR_NEWER
        protected override void OnOpen(object userData)
#else
        protected internal override void OnInit(object userData)
#endif
        {
            m_LanguageDropdown.ClearOptions();
            var OptionDataList = new List<Dropdown.OptionData>();
            for (int i = 0; i < LanguageDataList.Count; i++)
            {
                OptionDataList.Add(new Dropdown.OptionData() { text = LanguageDataList[i].languageStr });
            }
            m_LanguageDropdown.AddOptions(OptionDataList);

            base.OnInit(userData);
        }

#if UNITY_2017_3_OR_NEWER
        protected override void OnOpen(object userData)
#else
        protected internal override void OnOpen(object userData)
#endif
        {
            base.OnOpen(userData);

            m_MusicMuteToggle.isOn = !GameEntry.Sound.IsMuted("Music");
            m_MusicVolumeSlider.value = GameEntry.Sound.GetVolume("Music");

            m_SoundMuteToggle.isOn = !GameEntry.Sound.IsMuted("Sound");
            m_SoundVolumeSlider.value = GameEntry.Sound.GetVolume("Sound");

            m_UISoundMuteToggle.isOn = !GameEntry.Sound.IsMuted("UISound");
            m_UISoundVolumeSlider.value = GameEntry.Sound.GetVolume("UISound");

            m_SelectedLanguage = GameEntry.Localization.Language;
            for (int i = 0; i < LanguageDataList.Count; i++)
            {
                if (m_SelectedLanguage == LanguageDataList[i].language)
                {
                    m_LanguageDropdown.value = i;
                    break;
                }
            }
            RefreshLanguageTips();
        }

#if UNITY_2017_3_OR_NEWER
        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
#else
        protected internal override void OnUpdate(float elapseSeconds, float realElapseSeconds)
#endif
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            if (m_LanguageTipsCanvasGroup.gameObject.activeSelf)
            {
                m_LanguageTipsCanvasGroup.alpha = 0.5f + 0.5f * Mathf.Sin(Mathf.PI * Time.time);
            }
        }

        private void RefreshLanguageTips()
        {
            m_LanguageTipsCanvasGroup.gameObject.SetActive(m_SelectedLanguage != GameEntry.Localization.Language);
        }

    }
}
