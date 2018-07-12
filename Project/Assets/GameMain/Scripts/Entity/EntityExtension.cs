﻿using GameFramework;
using System;
using UnityGameFramework.Runtime;

namespace FYProject
{
    public static class EntityExtension
    {
        // 关于 EntityId 的约定：
        // 0 为无效
        // 正值用于和服务器通信的实体（如玩家角色、NPC、怪等，服务器只产生正值）
        // 负值用于本地生成的临时实体（如特效、FakeObject等）
        //目前无服务器
        private static int s_SerialId = 0;


        public static void ShowPlayer(this EntityComponent entityComponent, PlayerData data)
        {
            entityComponent.ShowEntity(typeof(Player), "Player", Constant.AssetPriority.PlayerAsset, data);
        }

        public static void ShowEntity(this EntityComponent entityComponent, Type logicType, string entiyGroup, int priority, EntityData data)
        {
            if (data == null)
            {
                Log.Warning("Data is invalid.");
                return;
            }

            var dtEntity = GameEntry.DataTable.GetDataTable<DREntity>();
            var drEntity = dtEntity.GetDataRow(data.TypeId);
            if (drEntity == null)
            {
                Log.Warning("Can not load entity id '{0}' from data table.", data.TypeId.ToString());
                return;
            }

            entityComponent.ShowEntity(data.Id, logicType, AssetUtility.GetEntityAsset(drEntity.AssetName), entiyGroup, priority, data);
        }

        public static int GenerateSerialId(this EntityComponent entityComponent)
        {
            return --s_SerialId;
        }

        public static void HideEntity(this EntityComponent entityComponent, Entity entity)
        {
            entityComponent.HideEntity(entity.Entity);
        }
    }
}
