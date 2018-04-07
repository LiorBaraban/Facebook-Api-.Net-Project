using System;
using System.Collections.Generic;
using FacebookWrapper.ObjectModel;
using static FacebookWrapper.ObjectModel.Post;

namespace FacebookApiDotNetProject
{
    internal class ActivitiesDecorator : FacebookObject
    {
        private PostedItem m_Activity;

        public PostedItem Activity
        {
            get { return m_Activity; }
        }

        public int Likes { get; set; }

        public List<PostedItem> ActivityCollection { get; set; }

        public void FindMostViralActivity()
        {
            if (ActivityCollection.Count == 0)
            {
                throw new Exception("No activities found");
            }
            PostedItem mostLikedPostedItem = ActivityCollection[0];
            foreach (PostedItem postedItem in ActivityCollection)
            {
                if (postedItem.LikedBy.Count > mostLikedPostedItem.LikedBy.Count)
                {
                    mostLikedPostedItem = postedItem;
                }
            }
            m_Activity = mostLikedPostedItem;
            Likes = mostLikedPostedItem.LikedBy.Count;
        }
    }
}