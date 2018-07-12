﻿using UnityEngine;
using UnityEngine.UI;
using GameFramework;

namespace FYProject
{
    public class AboutForm : UGuiForm
    {
        [SerializeField]
        private RectTransform m_Transform = null;

        [SerializeField]
        private float m_ScrollSpeed = 1f;

        private float m_InitPosition = 0f;

        private int m_Music = 3;//音乐编号

#if UNITY_2018_OR_NEWER
        protected override void OnInit(object userData)
#else
        protected internal override void OnInit(object userData)
#endif
        {
            base.OnInit(userData);

            CanvasScaler canvasScaler = GetComponentInChildren<CanvasScaler>();
            if (canvasScaler == null)
            {
                Log.Warning("Can not find CanvasScaler component.");
                return;
            }
            //referenceResolution??
            m_InitPosition = -0.5f * canvasScaler.referenceResolution.x * Screen.height / Screen.width;
        }
#if UNITY_2018_OR_NEWER
        protected override void OnOpen(object userData)
#else
        protected internal override void OnOpen(object userData)
#endif    
        {
            base.OnOpen(userData);

            m_Transform.SetLocalPositionY(m_InitPosition);

            //改变背景音乐
            GameEntry.Sound.PlayMusic(m_Music);
        }
#if UNITY_2018_OR_NEWER
        protected override void OnClose(object userData)
#else
        protected internal override void OnClose(object userData)
#endif
        {
            base.OnClose(userData);

            //还原菜单背景音乐
            GameEntry.Sound.PlayMusic(((ProcedureMenu)userData).GetBackgroundMusic());
        }
#if UNITY_2018_OR_NEWER
        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
#else
        protected internal override void OnUpdate(float elapseSeconds, float realElapseSeconds)
#endif
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            m_Transform.AddLocalPositionY(m_ScrollSpeed * elapseSeconds);
            if (m_Transform.localPosition.y > m_Transform.sizeDelta.y - m_InitPosition)
            {
                m_Transform.SetLocalPositionY(m_InitPosition);
            }
        }

    }
}
