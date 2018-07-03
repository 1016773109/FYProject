using GameFramework;
using System;
using UnityGameFramework.Runtime;

namespace FYProject
{
    public static class DataTableExtension
    {
        private const string DataRowClassPrefixName = "FYProject.DR";
        private static readonly string[] ColumnSplit = new string[] { "\t" };

        public static void LoadDataTable(this DataTableComponent dataTableComponent, string dataTableName, object userData = null)
        {
            if (dataTableName.IsNullOrEmpty())
            {
                Log.Warning("Data table name is invalid.");
                return;
            }

            var splitNames = dataTableName.Split('_');
            if (splitNames.Length > 2)
            {
                Log.Warning("Data table name is invalid.");
                return;
            }

            var dataRowClassName = DataRowClassPrefixName + splitNames[0];
            var dataRowType = Type.GetType(dataRowClassName);
            if (dataRowType == null)
            {
                Log.Warning("Can not get data row type with class name '{0}'.", dataRowClassName);
                return;
            }

            var dataTableNameInType = splitNames.Length > 1 ? splitNames[1] : null;
            dataTableComponent.LoadDataTable(dataRowType, dataTableName, dataTableNameInType, AssetUitity.GetDataTableAsset(dataTableName), Constant.AssetPriority.DataTableAsset, userData);
            Log.Debug("<color=green> dataRowType = {0}, dataTableName = {1}, dataTableNameInType = {2}, AssetUitity.GetDataTableAsset(dataTableName) = {3}</color>", dataRowType, dataTableName, dataTableNameInType, AssetUitity.GetDataTableAsset(dataTableName));
        }

        public static string[] SplitDataRow(string dataRowText)
        {
            return dataRowText.Split(ColumnSplit, StringSplitOptions.None);
        }

    }
}
