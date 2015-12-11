using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AppTest2.Droid
{
    public class SearchLock
    {
        private static SearchLock _instance;
        private static bool isCountrySearching;
        private static object syncLock = new object();


        public SearchLock()
        {
            isCountrySearching = false;
        }

        public static SearchLock GetSearchLock()
        {
            if (_instance == null)
            {
                lock (syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new SearchLock();
                    }
                }
            }
            return _instance;
        }

        public bool IsCountrySearching
        {
            get
            {
                return isCountrySearching;
            }
            set
            {
                isCountrySearching = value;
            }
        }

    }
}