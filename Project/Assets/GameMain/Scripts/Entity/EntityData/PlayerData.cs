using UnityEngine;
using System;

namespace FYProject
{
    [Serializable]
    public class PlayerData : RoleData
    {
        [SerializeField]
        private string m_Name = null;

        public PlayerData(int entityId, int typeId) : base(entityId, typeId, CampType.Player)
        {
        }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                value = m_Name;
            }
        }
    }
}
