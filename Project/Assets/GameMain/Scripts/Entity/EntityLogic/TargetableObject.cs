using GameFramework;
using UnityEngine;

namespace FYProject
{
    public abstract class TargetableObject : Entity
    {
        [SerializeField]
        private TargetableObjectData m_TargetableObjectData = null;

        public bool IsDead
        {
            get
            {
                return m_TargetableObjectData.HP <= 0;
            }
        }

        public void ApplyDamage(Entity attacker, int damageHP)
        {
            float fromHPRotio = m_TargetableObjectData.HPRatio;
            m_TargetableObjectData.HP -= damageHP;
            float toHPRotio = m_TargetableObjectData.HPRatio;
            if (fromHPRotio > toHPRotio)
            {
                //...
            }

            if (m_TargetableObjectData.HP <= 0)
            {
                OnDead(attacker);
            }
        }

        protected virtual void OnDead(Entity attacker)
        {
            GameEntry.Entity.HideEntity(this);
        }

#if UNITY_2017_3_OR_NEWER
        protected override void OnInit(object userData)
#else
        protected internal override void OnInit(object userData)
#endif
        {
            base.OnInit(userData);
            gameObject.SetLayerRecursively(Constant.Layer.TargetableObjectLayerId);
        }

#if UNITY_2017_3_OR_NEWER
        protected override void OnShow(object userData)
#else
        protected internal override void OnShow(object userData)
#endif
        {
            base.OnShow(userData);

            m_TargetableObjectData = userData as TargetableObjectData;

            if (m_TargetableObjectData == null)
            {
                Log.Error("Targetable object data is invalid.");
                return;
            }
        }

        //public void OnTriggerEnter(Collider other)
        //{
        //    Entity entity = other.gameObject.GetComponent<Entity>();
        //    if (entity == null)
        //    {
        //        return;
        //    }

        //    if (entity is TargetableObject && entity.Id >= Id)
        //    {
        //        // 碰撞事件由 Id 小的一方处理，避免重复处理
        //        return;
        //    }

        //}

    }
}
