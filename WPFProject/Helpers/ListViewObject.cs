using System;
using System.Collections.Generic;
using System.Text;

namespace WPFProject
{
    public struct ListViewObject
    {
        public int MovieId { get; private set; }
        public string PlatformName { get; private set; }
        public string MovieTitle { get; private set; }
        public int MovieRating { get; private set; }
        public string MovieGenre { get; private set; }

        public string CreatedBy { get; private set; }
        public ListViewObject(int id, string pName, string mTitle, int mRating, string mGenre, string userName)
        {
            MovieId = id;
            PlatformName = pName;
            MovieTitle = mTitle;
            MovieRating = mRating;
            MovieGenre = mGenre;
            CreatedBy = userName;
        }
    }
}
