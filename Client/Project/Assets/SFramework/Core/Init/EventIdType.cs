public static class EventIdType
{
    public const string OnFocusChange = "1";

    public const string InitSceneStart = "InitSceneStart";
    public const string LoginFinish = "LoginFinish";
    public const string EnterMapFinish = "EnterMapFinish";

    //public const string CameraChange = "CameraChange";  //摄像机视角切换
    //public const string SelectRankHorse = "SelectRankHorse";    //选择视角马匹
    public const string RecvRoomSettle = "RecvRoomSettle";    //收到结算消息
    public const string RecvCombatRoomSettle = "RecvCombatRoomSettle";    //收到对抗赛结算消息
    public const string UpdateActivityOpenInfo = "UpdateActivityOpenInfo";    //更新活动开启信息
    public const string UpdateCombatPanelInfo = "UpdateCombatPanelInfo";    //更新对抗赛界面信息
    public const string CombatLaunchChallenge = "CombatLaunchChallenge";    //匹配成功

    public const string UpdateCombatMatchList = "UpdateCombatMatchList";    //更新对抗赛匹配列表
    public const string UpdateCanRaceHorse = "UpdateCanRaceHorse";    //更新选马界面
    public const string UpdateCompetitions = "UpdateCompetitions";    //更新赛事信息
    public const string UpdateCanSelectMember = "UpdateCanSelectMember";    //获取选人信息
    public const string UpdateClubGameSeatInfo = "UpdateClubGameSeatInfo";    //更新俱乐部赛阵容信息
    public const string UpdateWeekRankingList = "UpdateWeekRankingList";    //更新排行榜信息
    public const string UpdateSeason2RankingList = "UpdateSeason2RankingList";
    public const string UpdateMatchRecord = "UpdateMatchRecord";    //更新战斗记录

    public const string UpdateRecorderRed = "UpdateRecorderRed";    //3v3记录红点刷新

    public const string GamePathSelected = "GamePathSelected";//比赛场地确认了
    public const string GameFieldCameraInited = "GameFieldCameraInited";//比赛中主要场景camera完成
    public const string GamePathDataInited = "GamePathDataInited";//赛道数据反序列化完成 
    public const string GameMatchDisposed = "GameMatchDisposed";//比赛清理内存

    public const string QuestFeatCameraOutputTarget = "QuestFeatCameraOutputTarget";//请求创建默认的用于显示feature效果的目标

    public const string UpdateCoin = "UpdateCoin";    //更新战斗记录
    public const string UpdateItem = "UpdateItem";  //更新道具
    public const string GetOneHorseMatchInfo = "GetOneHorseMatchInfo";    //更新战斗记录
    public const string DetentionCoin = "DetentionCoin";
}
