﻿using GameFramework.DataTable;
using System.Collections.Generic;

namespace FYProject
{
    /// <summary>
    /// 音乐配置表。
    /// </summary>
    public class DRMusic : IDataRow
    {
        /// <summary>
        /// 音乐编号。
        /// </summary>
        public int Id
        {
            get;
            private set;
        }

        /// <summary>
        /// 资源名称。
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
            new Dictionary<int, DRMusic>();
        }
    }
}