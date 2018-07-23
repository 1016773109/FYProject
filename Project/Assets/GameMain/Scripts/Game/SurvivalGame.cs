using UnityEngine;

namespace FYProject
{
    public class SurvivalGame : GameBase
    {
        private readonly int minNodeCount = 10;
        private readonly int maxNodeCount = 20;
        private const int nodeTypeId = 10001;//TODO

        public override GameMode GameMode
        {
            get
            {
                return GameMode.Survival;
            }
        }


        public override void Initialize()
        {
            base.Initialize();

            //TODO 地图元素创建

            //for (int i = 0; i < Random.Range(minNodeCount, maxNodeCount); i++)
            //{
            //    var nodeData = new MapNodeData(GameEntry.Entity.GenerateSerialId(), nodeTypeId);
            //    nodeData.MapNodeType = (MapNodeType)Random.Range(0, System.Enum.GetNames(typeof(MapNodeType)).Length);
            //    GameEntry.Entity.ShowNode(nodeData);
            //}

            var fightNodeData = new MapNodeData(GameEntry.Entity.GenerateSerialId(), nodeTypeId);
            fightNodeData.MapNodeType = MapNodeType.Fight;
            GameEntry.Entity.ShowNode(fightNodeData);
            fightNodeData.Position = new Vector3(-2, 1, 0);


            var shopNodeData = new MapNodeData(GameEntry.Entity.GenerateSerialId(), nodeTypeId);
            shopNodeData.MapNodeType = MapNodeType.Shop;
            GameEntry.Entity.ShowNode(shopNodeData);
            shopNodeData.Position = new Vector3(-1, 1, 0);


            var treasureBoxNodeData = new MapNodeData(GameEntry.Entity.GenerateSerialId(), nodeTypeId);
            treasureBoxNodeData.MapNodeType = MapNodeType.TreasureBox;
            GameEntry.Entity.ShowNode(treasureBoxNodeData);
            treasureBoxNodeData.Position = new Vector3(0, 1, 0);


            var bonfireNodeData = new MapNodeData(GameEntry.Entity.GenerateSerialId(), nodeTypeId);
            bonfireNodeData.MapNodeType = MapNodeType.Bonfire;
            GameEntry.Entity.ShowNode(bonfireNodeData);
            bonfireNodeData.Position = new Vector3(1, 1, 0);


        }


    }
}
