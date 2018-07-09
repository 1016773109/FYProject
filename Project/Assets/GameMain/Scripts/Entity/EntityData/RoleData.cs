using System;
using System.Collections.Generic;
using UnityEngine;

namespace FYProject
{
    public abstract class RoleData : TargetableObjectData
    {
        [SerializeField]
        private int m_MaxHP = 0;
        private int m_Attack = 0;
        private int m_Defense = 0;

        //... Anim

        [SerializeField]
        private int m_DeadEffectId = 0;

        [SerializeField]
        private int m_DeadSoundId = 0;

        public RoleData(int entityId, int typeId, CampType camp) : base(entityId, typeId, camp)
        {
            var dtRoleData = GameEntry.DataTable.GetDataTable<DRRole>();
            DRRole drRoleData = dtRoleData.GetDataRow(TypeId);
            if (drRoleData == null)
            {
                return;
            }

            RefreshData();

            //...Anim
            m_DeadEffectId = drRoleData.DeadEffectId;
            m_DeadSoundId = drRoleData.DeadSoundId;

            HP = m_MaxHP;
        }

        /// <summary>
        /// 最大生命
        /// </summary>
        public override int MaxHP
        {
            get
            {
                return m_MaxHP;
            }
        }

        /// <summary>
        /// 防御。
        /// </summary>
        public int Defense
        {
            get
            {
                return m_Defense;
            }
        }

        public int DeadEffectId
        {
            get
            {
                return m_DeadEffectId;
            }
        }

        public int DeadSoundId
        {
            get
            {
                return m_DeadSoundId;
            }
        }

        private void RefreshData()
        {
            m_MaxHP = 0;
            m_Attack = 0;
            m_Defense = 0;

            if (HP > m_MaxHP)
            {
                HP = m_MaxHP;
            }
        }

    }
}
