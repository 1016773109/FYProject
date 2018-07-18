using System.Collections.Generic;
using GameFramework.DataTable;

namespace FYProject
{
    /// <summary>
    /// 地图节点表。
    /// </summary>
    public class DRMapNode : IDataRow
    {
        /// <summary>
        /// 地图节点编号
        /// </summary>
        public int Id
        {
            get;
            private set;
        }
        /// <summary>
        /// 图标编号
        /// </summary>
        public int IconId
        {
            get;
            private set;
        }

        public void ParseDataRow(string dataRowText)
        {
            string[] text = DataTableExtension.SplitDataRow(dataRowText);
            int index = 0;
            index++;
            Id = int.Parse(text[index++]);
            index++;
            IconId = int.Parse(text[index++]);
        }

        private void AvoidJIT()
        {
            new Dictionary<int, DRMapNode>();
        }

    }
}
