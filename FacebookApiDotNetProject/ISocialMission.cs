namespace FacebookApiDotNetProject_BeSocial_Logic
{
    public interface ISocialMission
    {
        string Description { get; set; }

        GameModel MissionModel { get; set; }

        int ScoreValue { get; set; }

        bool IsFulfilled();
    }
}