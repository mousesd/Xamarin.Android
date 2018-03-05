using System.Diagnostics.CodeAnalysis;
using Android.App;
using Android.Util;
using Firebase.Iid;

namespace AndroidApp3
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class MyFirebaseInstanceIdService : FirebaseInstanceIdService
    {
        private static readonly string Tag = typeof(MyFirebaseInstanceIdService).Name;

        /// <summary>
        /// Called when the system determines that the tokens to be refreshed.
        /// This will not be called very frequently, it is needed for key rotation and to handle Instance ID changes due to:
        ///   - App deletes Instance ID
        ///   - App is restored on a new device
        ///   - User uninstall/reinstall the app
        ///   - User clear app data
        /// FirebaseCloudMessaging Instance ID will request that the app refresh its token periodically(typically, every 6 months)
        /// </summary>
        public override void OnTokenRefresh()
        {
            string refreshToken = FirebaseInstanceId.Instance.Token;
            Log.Debug(Tag, $"Refreshed token: {refreshToken}");

            this.SendRegistrationToAppServer(refreshToken);
        }

        [SuppressMessage("ReSharper", "UnusedParameter.Local")]
        private void SendRegistrationToAppServer(string refreshToken)
        {
            //# Forwards the registration token to the app server if the app server requires it.
        }
    }
}
