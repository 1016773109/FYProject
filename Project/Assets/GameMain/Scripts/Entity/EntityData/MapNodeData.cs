using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FYProject
{
    public class MapNodeData : EntityData
    {
        public MapNodeData(int entityId, int typeId) : base(entityId, typeId)
        {
            var dtMapNodeData = GameEntry.DataTable.GetDataTable<DRMapNode>();
            var drMapNodeData = dtMapNodeData.GetDataRow(TypeId);
            if (drMapNodeData == null)
            {
                return;
            }

        }


        public MapNodeType MapNodeType
        {
            get;
            set;
        }



    }
}
