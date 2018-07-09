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


            var playerData = new PlayerData(GameEntry.Entity.GenerateSerialId(), playerTypeId);
            playerData.Name = "";
            playerData.Position = Vector3.zero;
            GameEntry.Entity.ShowPlayer(playerData);
            //TODO 主角创建
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

        }

        private void ShowEntitySuccessEvent(object sender, GameEventArgs e)
        {
            ShowEntitySuccessEventArgs ne = (ShowEntitySuccessEventArgs)e;
            //...
        }

        private void ShowEntityFailureEvent(object sender, GameEventArgs e)
        {
            ShowEntityFailureEventArgs ne = (ShowEntityFailureEventArgs)e;
            Log.Warning("Show entity failure with error message '{0}'.", ne.ErrorMessage);
        }


    }
}
