using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookApiDotNetProject_BeSocial_Logic
{
    public class MissionWriteAPost : ISocialMission
    {
        public string Description { get; set; }

        public GameModel MissionModel { get; set; }

        public int ScoreValue { get; set; }

        public MissionWriteAPost(GameModel i_ModelInput)
        {
            MissionModel = i_ModelInput;
            ScoreValue = 1;
            Description = string.Format(
@"Write a simple post.
Mission score value: {0} points", 
ScoreValue);
                    }

        public bool IsFulfilled()
        {
            return !string.IsNullOrEmpty(MissionModel.PostText) && string.IsNullOrEmpty(MissionModel.LinkUrl) && string.IsNullOrEmpty(MissionModel.LinkUrl);
        }
    }
}
