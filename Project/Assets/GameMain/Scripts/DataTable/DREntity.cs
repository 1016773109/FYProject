﻿using System.Collections.Generic;
using GameFramework.DataTable;

namespace FYProject
{
    public class DREntity : IDataRow
    {
        /// <summary>
        /// 实体编号
        /// </summary>
        public int Id
        {
            get;
            private set;
        }

        /// <summary>
        /// 资源名称
        /// </summary>
        public string AssetName
        {
            get;
            private set;
        }

        public void ParseDataRow(string dataRowText)
        {
            var text = DataTableExtension.SplitDataRow(dataRowText);
            int index = 0;
            index++;
            Id = int.Parse(text[index++]);
            index++;
            AssetName = text[index++];
        }

        private void AvoidJIT()
        {
            new Dictionary<int, DREntity>();
        }
    }
}
