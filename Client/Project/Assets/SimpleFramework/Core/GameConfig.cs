    /// <summary>
    /// 游戏配置信息
    /// </summary>
    public class GameConfig
    {
        /// <summary>
        /// 游戏名字
        /// </summary>
        public static string GameName = "SMGame";

        /// <summary>
        /// 游戏版本
        /// <介绍>：(1)1. (2)1. (3)1. (4)0, (1)是大版本更新, (2)是一般更新, (3)是当前版本功能添加, (4)是bug修复. </介绍>
        /// </summary>
        public static string GameVersion { get { return "1.0.0.0"; } }

        /// <summary>
        /// 登录服务器IP地址
        /// </summary>
        public static string LoginIp { get; set; }
        /// <summary>
        /// 登录服务器端口
        /// </summary>
        public static int LoginPort { get; set; }

        /// <summary>
        /// 游戏服务器IP地址
        /// </summary>
        public static string GameIp { get; set; }
        /// <summary>
        /// 游戏服务器端口
        /// </summary>
        public static int GamePort { get; set; }

        /// <summary>
        /// 聊天服务器IP地址
        /// </summary>
        public static string ChatIp { get; set; }
        /// <summary>
        /// 聊天服务器端口
        /// </summary>
        public static int ChatPort { get; set; }
    }
