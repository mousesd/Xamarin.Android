using System;
using System.Diagnostics.CodeAnalysis;
using Android.App;
using Android.Gms.Common;
using Android.Widget;
using Android.OS;
using Android.Util;
using Firebase.Iid;
using Firebase.Messaging;

namespace AndroidApp3
{
    [Activity(Label = "AndroidApp3", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private static readonly string Tag = typeof(MainActivity).Name;
        private TextView messageTextView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            if (this.Intent.Extras != null)
            {
                foreach (string key in this.Intent.Extras.KeySet())
                {
                    string value = this.Intent.Extras.GetString(key);
                    Log.Debug(Tag, $"Key: {key}, Value: {value}");
                }

                //# Output
                //  Key: google.ttl, Value:
                //  Key: from, Value: 579223331998
                //  Key: google.message_id, Value: 0:1520257936569796%312439c0312439c0
                //  Key: collapse_key, Value: net.homenet.AndroidApp3
            }

            messageTextView = this.FindViewById<TextView>(Resource.Id.messageTextView);
            this.IsGooglePlayServiceAvailable();

            var logTokenButton = this.FindViewById<Button>(Resource.Id.logTokenButton);
            logTokenButton.Click += this.OnClickLogToken;

            var subscribeButton = this.FindViewById<Button>(Resource.Id.subscribeButton);
            subscribeButton.Click += this.OnClickSubscribe;
        }

        /// <summary>
        /// Google Play Service 기능의 사용 가능여부를 확인
        /// </summary>
        /// <returns>true: 가능, false:불가능</returns>
        [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Local")]
        private bool IsGooglePlayServiceAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                messageTextView.Text = GoogleApiAvailability.Instance.IsUserResolvableError(resultCode) 
                    ? GoogleApiAvailability.Instance.GetErrorString(resultCode) 
                    : "This device is not supported";
                return false;
            }

            messageTextView.Text = "Google Play Services is available.";
            return true;
        }

        /// <summary>
        /// Instance ID를 출력
        /// </summary>
        private void OnClickLogToken(object sender, EventArgs e)
        {
            Log.Debug(Tag, $"InstanceID token: {FirebaseInstanceId.Instance.Token}");
        }

        /// <summary>
        /// Topic('news') 메시지 수신을 가입 처리
        /// </summary>
        private void OnClickSubscribe(object sender, EventArgs e)
        {
            FirebaseMessaging.Instance.SubscribeToTopic("news");
            Log.Debug(Tag, "Subscribed to remote notification");
        }
    }
}
