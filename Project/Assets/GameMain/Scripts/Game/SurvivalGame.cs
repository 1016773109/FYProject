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

            for (int i = 0; i < Random.Range(minNodeCount, maxNodeCount); i++)
            {
                var nodeData = new MapNodeData(GameEntry.Entity.GenerateSerialId(), nodeTypeId);
                nodeData.NodeType = (MapNodeType)Random.Range(0, System.Enum.GetNames(typeof(MapNodeType)).Length);
                GameEntry.Entity.ShowNode(nodeData);
            }

        }


    }
}
