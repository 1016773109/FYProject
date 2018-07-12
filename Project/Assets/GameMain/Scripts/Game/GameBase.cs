using GameFramework;
using GameFramework.Event;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace FYProject
{
    public abstract class GameBase
    {
        private const int playerTypeId = 10000;

        public abstract GameMode GameMode
        {
            get;
        }

        public bool GameOver
        {
            get;
            private set;
        }

        private Player m_Player = null;

        public virtual void Initialize()
        {
            GameEntry.Event.Subscribe(ShowEntitySuccessEventArgs.EventId, ShowEntitySuccessEvent);
            GameEntry.Event.Subscribe(ShowEntityFailureEventArgs.EventId, ShowEntityFailureEvent);

            //主角创建
            var playerData = new PlayerData(GameEntry.Entity.GenerateSerialId(), playerTypeId);
            playerData.Name = "MyPlayer";
            playerData.Position = Vector3.zero;
            GameEntry.Entity.ShowPlayer(playerData);

            GameOver = false;
            m_Player = null;
        }

        public virtual void Shutdown()
        {
            GameEntry.Event.Unsubscribe(ShowEntitySuccessEventArgs.EventId, ShowEntitySuccessEvent);
            GameEntry.Event.Unsubscribe(ShowEntityFailureEventArgs.EventId, ShowEntityFailureEvent);
        }

        public virtual void Update(float elapseSeconds, float realElapseSeconds)
        {
            if (m_Player != null && m_Player.IsDead)
            {
                GameOver = true;
                return;
            }
        }

        private void ShowEntitySuccessEvent(object sender, GameEventArgs e)
        {
            ShowEntitySuccessEventArgs ne = (ShowEntitySuccessEventArgs)e;
            if (ne.EntityLogicType == typeof(Player))
            {
                m_Player = (Player)ne.Entity.Logic;
            }
        }

        private void ShowEntityFailureEvent(object sender, GameEventArgs e)
        {
            ShowEntityFailureEventArgs ne = (ShowEntityFailureEventArgs)e;
            Log.Warning("Show entity failure with error message '{0}'.", ne.ErrorMessage);
        }

    }
}
