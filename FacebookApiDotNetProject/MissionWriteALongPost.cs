using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookApiDotNetProject_BeSocial_Logic
{
    public class MissionWriteALongPost : ISocialMission
    {
        private int m_NumberOfChars;

        public string Description { get; set; }

        public GameModel MissionModel { get; set; }

        public int ScoreValue { get; set; }

        public MissionWriteALongPost(GameModel i_ModelInput)
        {
            MissionModel = i_ModelInput;
            Random randomNumberOfChars = new Random();
            m_NumberOfChars = randomNumberOfChars.Next(200, 400);
            ScoreValue = 4;
            Description = string.Format(
@"Write a post that is equal or longer than {0} characters.
Mission score value: {1} points",
m_NumberOfChars,
ScoreValue);
        }

        public bool IsFulfilled()
        {
            return MissionModel.PostText.Count() >= m_NumberOfChars && string.IsNullOrEmpty(MissionModel.LinkUrl) && string.IsNullOrEmpty(MissionModel.LinkUrl);
        }
    }
}
