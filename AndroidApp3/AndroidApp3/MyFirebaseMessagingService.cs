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
using Firebase.Messaging;

namespace AndroidApp3
{
    /// <summary>
    /// Foreground 메시지를 수신하기 위해서는 FirebaseMessagingService 클래스를 구현
    /// </summary>
    [Service]
    [IntentFilter(new [] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MyFirebaseMessagingService :FirebaseMessagingService
    {
        private static readonly string Tag = typeof(MyFirebaseMessagingService).Name;

        public override void OnMessageReceived(RemoteMessage message)
        {
            Log.Debug(Tag, $"From: {message.From}");
            Log.Debug(Tag, $"Notification message body: {message.GetNotification().Body}");

            //# Output
            //  From: 579223331998
            //  Notification message body: Foreground message

            this.SendLocalNotication(message.GetNotification().Body, message.Data);
        }

        /// <summary>
        /// Send local notification
        /// </summary>
        private void SendLocalNotication(string messageBody, IDictionary<string, string> data)
        {
            var intent = new Intent(this, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.ClearTop);
            foreach (string key in data.Keys)
                intent.PutExtra(key, data[key]);
            var pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.OneShot);

            var builder = new Notification.Builder(this)
                .SetSmallIcon(Resource.Drawable.ic_stat_ic_notification)
                .SetContentTitle("Firebase message")
                .SetContentText(messageBody)
                .SetAutoCancel(true)
                .SetContentIntent(pendingIntent);

            var manager = NotificationManager.FromContext(this);
            manager.Notify(0, builder.Build());
        }
    }
}