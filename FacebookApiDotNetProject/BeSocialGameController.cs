using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace FacebookApiDotNetProject_BeSocial_Logic
{
    public sealed class BeSocialGameController
    {
        private static BeSocialGameController s_ControllerInstance = null;
        private static object s_SingeltonLock = new object();
        private static LinkedList<ISocialMission> m_MissionsLinkedList = new LinkedList<ISocialMission>();
        private static LinkedListNode<ISocialMission> m_CurrentMissionNode;
        public Func<List<ISocialMission>, LinkedList<ISocialMission>> m_MissionStrategy = null;
        public event TurnEndedDelegate m_EndTurn;


        public static BeSocialGameController Instance(Func<List<ISocialMission>, LinkedList<ISocialMission>> i_MissionStrategy)
        {
            {
                if (s_ControllerInstance == null)
                {
                    lock (s_SingeltonLock)
                    {
                        if (s_ControllerInstance == null)
                        {
                            s_ControllerInstance =
                                new BeSocialGameController(
                                    new GameModel
                                    {
                                        PostText = null,
                                        SelectedFriend = null,
                                        PictureUrl = null,
                                        LinkUrl = null
                                    },
                                    i_MissionStrategy);
                        }
                    }
                }
                else
                {
                    m_MissionsLinkedList = MissionFactory.CreateMissionList(new GameModel
                    {
                        LinkUrl = null,
                        PictureUrl = null,
                        PostText = null,
                        SelectedFriend = null
                    }, i_MissionStrategy);
                    m_CurrentMissionNode = m_MissionsLinkedList.First;

                }
                return s_ControllerInstance;
            }
        }

        public LinkedListNode<ISocialMission> CurrentMissionNode
        {
            get { return m_CurrentMissionNode; }
        }

        public ISocialMission CurrentMission
        {
            get { return CurrentMissionNode.Value; }
        }

        public GameModel Model { get; set; }

        public int PlayerScore { get; set; }

        public int MaxScore { get; }

        public Func<List<ISocialMission>, LinkedList<ISocialMission>> SelectedMissionListStrategy { get; set; }

        private BeSocialGameController(GameModel i_Model, Func<List<ISocialMission>, LinkedList<ISocialMission>> i_MissionStrategy)
        {
            PlayerScore = 0;
            MaxScore = 10;
            Model = i_Model;
            m_MissionsLinkedList = MissionFactory.CreateMissionList(i_Model, i_MissionStrategy);
            m_CurrentMissionNode = m_MissionsLinkedList.First;
        }

        public bool IsCurrentMissionFullfilled()
        {
            CurrentMission.MissionModel = this.Model;
            return CurrentMission.IsFulfilled();
        }

        public void RewardPoints()
        {
            PlayerScore += CurrentMission.ScoreValue;
        }

        public void SkipToNextMission()
        {
            if (m_CurrentMissionNode.Next != null)
            {
                m_CurrentMissionNode = m_CurrentMissionNode.Next;
            }
            else
            {
                m_CurrentMissionNode = null;
            }
        }

        //public void ResetGame()
        //{
        //    PlayerScore = 0;

        //    m_MissionsLinkedList = MissionFactory.CreateMissionList(Model);
        //    m_CurrentMissionNode = m_MissionsLinkedList.First;
        //}

        public bool IsReachedMaxPoints()
        {
            return PlayerScore >= MaxScore;
        }

        public void ResetMissions()
        {
            PlayerScore = 0;

            m_CurrentMissionNode = m_MissionsLinkedList.First;
        }

        internal void UpdateGameModel(GameModel i_GameModel)
        {
            this.Model = i_GameModel;
            CurrentMission.MissionModel = i_GameModel;
        }

        public void OnEndTurn()
        {
            FinishTurnEventArgs finishTurnEventArgs = new FinishTurnEventArgs();
            finishTurnEventArgs.IsFinishedGame = false;
            finishTurnEventArgs.IsReachedMaxPoints = false;
            if (IsCurrentMissionFullfilled())
            {
                RewardPoints();
            }
            if (IsReachedMaxPoints() || CurrentMissionNode.Next == null)
            {
                finishTurnEventArgs.IsFinishedGame = true;
                if (IsReachedMaxPoints())
                {
                    finishTurnEventArgs.IsReachedMaxPoints = true;
                }
            }
            else
            {
                SkipToNextMission();
            }
            m_EndTurn.Invoke(this, finishTurnEventArgs);
        }
    }

}