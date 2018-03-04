using System;
using Android;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Support.V7.App;
using Android.Util;
using Android.Content.PM;
using Android.Runtime;

namespace AndroidApp2
{
    [Activity(Label = "AndroidApp2", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private static readonly int RequestCodeToReceiveSms = 1000;
        private static readonly string Tag = typeof(MainActivity).Name;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //# NOTE: AppCompatActivity를 상속받는 경우 아래 Package 설치 필요
            //# - Xamarin.Android.Support.Design
            //# - Xamarin.Android.Support.v4
            //# - Xamarin.Android.Support.v7.AppCompat
            var requestPermissionButton = this.FindViewById(Resource.Id.requestPermissionButton);
            requestPermissionButton.Click += this.OnRequestPermission;
        }

        private void OnRequestPermission(object sender, EventArgs e)
        {
            //# NOTE: AppCompatActivity를 상속받는 경우 아래와 같은 이슈가 있음
            //# 1.설정에서 SMS 권한을 Deny 하더라도 아래 메서드의 반환값을 항상 Granted!
            //# - 설정에서 Deny 처리시 아래와 같은 메시지가 표시 됨
            //# - This app was designed for an older version of Android. Denying permission may cause it to no longer function as intended.
            //# - 동일한 조건으로 Native App을 개발하면 정상적으로 동작하고, 설정 변경시에도 위 메시지 표시되지 않음
            //# 2.Activity를 상속받은 경우도 동일한 증상 발생
            var permission = ContextCompat.CheckSelfPermission(this, Manifest.Permission.ReceiveSms);
            if (permission == Permission.Granted)
            {
                Log.Debug(Tag, "Granted");
            }
            else
            {
                Log.Debug(Tag, "Denied");
                if (ActivityCompat.ShouldShowRequestPermissionRationale(this, Manifest.Permission.ReceiveSms))
                {
                    Log.Debug(Tag, "ActivityCompat.ShouldShowRequestPermissionRationale() == true");
                }

                ActivityCompat.RequestPermissions(this, new[] { Manifest.Permission.ReceiveSms }, RequestCodeToReceiveSms);
            }
        }

        /// <summary>
        /// Callback for the result from requesting permissions. This method is invoked for every call on RequestPermissions(String[], int)
        /// </summary>
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum]Permission[] grantResults)
        {
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            if (requestCode != RequestCodeToReceiveSms)
                return;

            if (grantResults.Length > 0 && grantResults[0] == Permission.Granted)
                Log.Debug(Tag, "OnRequestPermissionsResult(), Granted");
            else
                Log.Debug(Tag, "OnRequestPermissionsResult(), Denied");
        }
    }
}
