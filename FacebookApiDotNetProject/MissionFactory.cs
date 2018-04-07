using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookApiDotNetProject_BeSocial_Logic
{
    public static class MissionFactory
    {
        public static LinkedList<ISocialMission> CreateMissionList(GameModel i_Model, Func<List<ISocialMission>,LinkedList<ISocialMission>> i_MissionListStrategy)
        {
            List<ISocialMission> newMissionList = new List<ISocialMission>();

            newMissionList.Add(new MissionShareALink(i_Model));
            newMissionList.Add(new MissionTagAFriendAndShareALink(i_Model));
            newMissionList.Add(new MissionTagFriendAndPost(i_Model));
            newMissionList.Add(new MissionUploadPhoto(i_Model));
            newMissionList.Add(new MissionWriteALongPost(i_Model));
            newMissionList.Add(new MissionWriteAPost(i_Model));

            //insert strategy method in here.
            LinkedList<ISocialMission> returnedMissionList = i_MissionListStrategy.Invoke(newMissionList);

            //LinkedList<ISocialMission> randomizedMissionList = randomizeMissionsOrder(newMissionList);
            return returnedMissionList;
        }

        public static LinkedList<ISocialMission> RandomizeMissionsOrder(List<ISocialMission> i_TempList)
        {
            LinkedList<ISocialMission> randomizedMissionList = new LinkedList<ISocialMission>();
            Random rand = new Random();
            ISocialMission tempMissionPlaceholder;
            int n = i_TempList.Count;
            while (n > 1)
            {
                n--;
                int i = rand.Next(n + 1);
                tempMissionPlaceholder = i_TempList[i];
                i_TempList[i] = i_TempList[n];
                i_TempList[n] = tempMissionPlaceholder;
            }

            foreach (ISocialMission tempMission in i_TempList)
            {
                randomizedMissionList.AddFirst(tempMission);
            }

            return randomizedMissionList;
        }


        public static LinkedList<ISocialMission> OrderMissionsFromEasyToHard(List<ISocialMission> i_TempList)
        {
            LinkedList<ISocialMission> orderedMissionFromEasyToHard = new LinkedList<ISocialMission>();
            int n = i_TempList.Count;

            ISocialMission tempMission;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    if (i_TempList[j].ScoreValue > i_TempList[j + 1].ScoreValue)
                    {
                        tempMission = i_TempList[j + 1];
                        i_TempList[j + 1] = i_TempList[j];
                        i_TempList[j] = tempMission;
                    }
                }
            }
            foreach (ISocialMission mission in i_TempList)
            {
                orderedMissionFromEasyToHard.AddLast(mission);
            }
            return orderedMissionFromEasyToHard;
        }

        public static LinkedList<ISocialMission> OnlyHardMissions(List<ISocialMission> i_TempList)
        {
            LinkedList<ISocialMission> onlyHardMissions = new LinkedList<ISocialMission>();

            foreach(ISocialMission mission in i_TempList)
            {
                if (mission.ScoreValue >= 3)
                {
                    onlyHardMissions.AddFirst(mission);
                }
            }
            return onlyHardMissions;
        }
    }


}
