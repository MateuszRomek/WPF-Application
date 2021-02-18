using System;
using System.Collections.Generic;
using System.Text;

namespace WPFProject
{
    public struct WishlistUser
    {
        public string UserName { get; private set; }
        public string MovieTitle { get; private set; }

        public WishlistUser( string mTitle, string userName )
        {
            MovieTitle = mTitle;
            UserName = userName;
        }
    }
}
