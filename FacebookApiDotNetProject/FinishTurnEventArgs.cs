using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookApiDotNetProject_BeSocial_Logic
{
    public class FinishTurnEventArgs : EventArgs
    {
        public bool IsFinishedGame { get; set; }
        public bool IsReachedMaxPoints { get; set; }
    }
}
