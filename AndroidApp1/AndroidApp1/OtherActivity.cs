using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace AndroidApp1
{
    [Activity(Label = "OtherActivity")]
    public class OtherActivity : Activity
    {
        private static readonly String Tag = typeof(OtherActivity).Name;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            this.SetContentView(Resource.Layout.Other);

            var backButton = this.FindViewById(Resource.Id.backButton);
            backButton.Click += (sender, e) => this.Finish();

            Log.Debug(Tag, "OnCreate()");
        }

        protected override void OnStart()
        {
            base.OnStart();
            Log.Debug(Tag, "OnStart()");
        }

        protected override void OnResume()
        {
            base.OnResume();
            Log.Debug(Tag, "OnResume()");
        }

        protected override void OnPause()
        {
            base.OnPause();
            Log.Debug(Tag, "OnPause()");
        }

        protected override void OnStop()
        {
            base.OnStop();
            Log.Debug(Tag, "OnStop()");
        }

        protected override void OnRestart()
        {
            base.OnRestart();
            Log.Debug(Tag, "OnRestart()");
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Log.Debug(Tag, "OnDestroy()");
        }
    }
}
