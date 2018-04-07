using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookApiDotNetProject_BeSocial_Logic
{
    public class MissionTagAFriendAndShareALink : ISocialMission
    {
        public string Description { get; set; }

        public GameModel MissionModel { get; set; }

        public int ScoreValue { get; set; }

        public MissionTagAFriendAndShareALink(GameModel i_ModelInput)
        {
            MissionModel = i_ModelInput;
            ScoreValue = 4;
            Description = string.Format(
@"Share a any link that you choose, and tag a friend in it
The link you provide must have a full address path INCLUDING http:// at the beginning 
Mission score value: {0} points",
ScoreValue);
        }

        public bool IsFulfilled()
        {
            bool isFulfilled = false;
            if (!string.IsNullOrEmpty(MissionModel.LinkUrl) && MissionModel.SelectedFriend != null)
            {
                try
                {
                    ITester connectionTester = new ConnectionTester(MissionModel.LinkUrl);
                    isFulfilled = connectionTester.Test();
                }
                catch (Exception ex)
                {
                    throw new Exception("The url you have supplied isn't valid", ex);
                }
            }

            return isFulfilled;
        }
    }
}
