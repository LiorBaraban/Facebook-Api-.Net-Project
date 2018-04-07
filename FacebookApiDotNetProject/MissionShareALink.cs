using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;

namespace FacebookApiDotNetProject_BeSocial_Logic
{
    public class MissionShareALink : ISocialMission 
    {
        public string Description { get; set; }

        public GameModel MissionModel { get; set; }

        public int ScoreValue { get; set; }

        public MissionShareALink(GameModel i_ModelInput)
        {
            MissionModel = i_ModelInput;
            ScoreValue = 2;
            Description = string.Format(
@"Share a website for your choice.
You need to provide a full address INCLUDING INCLUDING http:// at the beginning 
Mission score value: {0} points", 
ScoreValue);
        }

        public bool IsFulfilled()
        {
            bool isFulfilled = false;
            if (!string.IsNullOrEmpty(MissionModel.LinkUrl))
            {
                try
                {
                    ITester connectionTester = new ConnectionTester(MissionModel.LinkUrl);
                    isFulfilled = connectionTester.Test();
                }
                catch (Exception ex)
                {
                    throw new Exception("The url you have supplied is either invalid, or it prevents us from reaching it. Please try again with a different address.", ex);
                }
            }

            return isFulfilled;
        }
    }
}
