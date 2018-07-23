using GameFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FYProject
{
    public class MapNode : Entity
    {
        private MapNodeData mapNodeData;


        protected internal override void OnInit(object userData)
        {
            base.OnInit(userData);
        }

        protected internal override void OnShow(object userData)
        {
            base.OnShow(userData);

            mapNodeData = userData as MapNodeData;
            if (mapNodeData == null)
            {
                Log.Error("MapNode data is invalid.");
                return;
            }

            switch (mapNodeData.MapNodeType)
            {
                case MapNodeType.Fight:
                    {
                        gameObject.AddComponent<FightNodeButton>();
                    }
                    break;
                case MapNodeType.Shop:
                    {
                        gameObject.AddComponent<FightNodeButton>();
                    }
                    break;
            }
        }


    }
}
