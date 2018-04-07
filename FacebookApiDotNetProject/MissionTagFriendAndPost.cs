using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace FacebookApiDotNetProject_BeSocial_Logic
{
    public class MissionTagFriendAndPost : ISocialMission
    {
        public string Description { get; set; }

        public GameModel MissionModel { get; set; }

        public int ScoreValue { get; set; }

        public MissionTagFriendAndPost(GameModel i_ModelInput)
        {
            MissionModel = i_ModelInput;
            ScoreValue = 3;
            Description = string.Format(
@"Write a post and Tag a friend in it.
Mission score value: {0} points", 
ScoreValue);
        }

        public bool IsFulfilled()
        {
            return MissionModel.SelectedFriend != null && !string.IsNullOrWhiteSpace(MissionModel.PostText);
        }
    }
}
