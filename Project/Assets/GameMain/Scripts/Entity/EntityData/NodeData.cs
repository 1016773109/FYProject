using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FYProject
{
    public class NodeData : EntityData
    {
        public NodeData(int entityId, int typeId) : base(entityId, typeId)
        {
        }


        public NodeType NodeType
        {
            get;
            set;
        }



    }
}
