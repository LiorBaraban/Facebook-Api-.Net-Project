using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookApiDotNetProject_BeSocial_Logic
{
    public class MissionUploadPhoto : ISocialMission
    {
        public string Description { get; set; }

        public GameModel MissionModel { get; set; }

        public int ScoreValue { get; set; }

        public MissionUploadPhoto(GameModel i_ModelInput)
        {
            MissionModel = i_ModelInput;
            ScoreValue = 3;
            Description = string.Format(
@"Upload a picture to facebook.
Mission score value: {0} points",
ScoreValue);
        }

        public bool IsFulfilled()
        {
            bool isFulfilled = false;
            if (MissionModel.PictureUrl != null)
            {
                if (MissionModel.PictureUrl.Contains(".jpg"))
                {
                    isFulfilled = true;
                }
                else if (MissionModel.PictureUrl.Contains(".jpeg"))
                {
                    isFulfilled = true;
                }
                else if (MissionModel.PictureUrl.Contains(".png"))
                {
                    isFulfilled = true;
                }
                else if (MissionModel.PictureUrl.Contains(".gif"))
                {
                    isFulfilled = true;
                }
            }

            return isFulfilled;
        }
    }
}