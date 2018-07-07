namespace FYProject
{
    public class VersionInfo
    {
        /// <summary>
        /// 强制游戏更新
        /// </summary>
        public bool ForceGameUpdate
        {
            get;
            set;
        }

        /// <summary>
        /// 最新游戏版本
        /// </summary>
        public string LatestGameVersion
        {
            get;
            set;
        }

        /// <summary>
        /// 游戏更新地址
        /// </summary>
        public string GameUpdateUrl
        {
            get;
            set;
        }

    }
}
