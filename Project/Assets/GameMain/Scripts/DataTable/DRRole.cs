using System.Collections.Generic;
using GameFramework.DataTable;

namespace FYProject
{
    /// <summary>
    /// 角色表。
    /// </summary>
    public class DRRole : IDataRow
    {
        private const int MaxAttackCount = 3; // 最大攻击动画数量
        private const int MaxDamageCount = 3; // 最大受伤动画数量
        private const int MaxWeaponCount = 3; // 最大武器数量
        private const int MaxArmorCount = 3; // 最大装甲数量

        private int[] m_AttackIds = new int[MaxAttackCount];
        private int[] m_DamageIds = new int[MaxDamageCount];
        private int[] m_WeaponIds = new int[MaxWeaponCount];
        private int[] m_ArmorIds = new int[MaxArmorCount];

        /// <summary>
        /// 角色编号。
        /// </summary>
        public int Id
        {
            get;
            private set;
        }

        /// <summary>
        /// 死亡特效编号。
        /// </summary>
        public int DeadEffectId
        {
            get;
            private set;
        }

        /// <summary>
        /// 死亡声音编号。
        /// </summary>
        public int DeadSoundId
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取攻击动画编号
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int GetAttackIds(int index)
        {
            return index < m_AttackIds.Length ? m_AttackIds[index] : 0;
        }

        /// <summary>
        /// 获取受伤动画编号
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int GetDamageIds(int index)
        {
            return index < m_DamageIds.Length ? m_DamageIds[index] : 0;
        }

        /// <summary>
        /// 获取武器编号
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int GetWeaponIds(int index)
        {
            return index < m_WeaponIds.Length ? m_WeaponIds[index] : 0;
        }

        /// <summary>
        /// 获取装甲编号
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int GetArmorIds(int index)
        {
            return index < m_ArmorIds.Length ? m_ArmorIds[index] : 0;
        }

        public void ParseDataRow(string dataRowText)
        {
            string[] text = DataTableExtension.SplitDataRow(dataRowText);
            int index = 0;
            index++;
            Id = int.Parse(text[index++]);
            index++;
            for (int i = 0; i < MaxAttackCount; i++)
            {
                m_AttackIds[i] = int.Parse(text[index++]);
            }
            for (int i = 0; i < MaxDamageCount; i++)
            {
                m_DamageIds[i] = int.Parse(text[index++]);
            }
            for (int i = 0; i < MaxWeaponCount; i++)
            {
                m_WeaponIds[i] = int.Parse(text[index++]);
            }
            for (int i = 0; i < MaxArmorCount; i++)
            {
                m_ArmorIds[i] = int.Parse(text[index++]);
            }
            DeadEffectId = int.Parse(text[index++]);
            DeadSoundId = int.Parse(text[index++]);
        }

        private void AvoidJIT()
        {
            new Dictionary<int, DRRole>();
        }

    }
}
