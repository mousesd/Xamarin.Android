using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Util;

namespace AndroidApp1
{
    [Activity(Label = "AndroidApp1", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private static readonly string Tag = typeof(MainActivity).Name;

        private string name;
        private EditText nameEditText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            nameEditText = this.FindViewById<EditText>(Resource.Id.name);
            var button = this.FindViewById(Resource.Id.button);
            button.Click += this.OnStartOtherActivity;

            Log.Debug(Tag, "OnCreate()");
        }

        private void OnStartOtherActivity(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(OtherActivity));
            this.StartActivity(intent);
        }

        protected override void OnStart()
        {
            base.OnStart();
            Log.Debug(Tag, "OnStart()");
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            //# Home, Back 버튼을 클릭하는 경우는 Callback 되지 않음
            //# Screen rotation인 경우만 Callback
            //# View 클래스를 상속받은 객체는 자동으로 값이 유지 되지만, 클래스 멤버변수는 유지 되지 않음
            base.OnSaveInstanceState(outState);
            Log.Debug(Tag, $"OnSaveInstanceState(), name={name}, nameEditText={nameEditText.Text}");
        }

        protected override void OnRestoreInstanceState(Bundle savedInstanceState)
        {
            //# Home, Back 버튼을 클릭하는 경우는 Callback 되지 않음
            //# Screen rotation인 경우만 Callback
            //# View 클래스를 상속받은 객체는 자동으로 값이 유지 되지만, 클래스 멤버변수는 유지 되지 않음
            base.OnRestoreInstanceState(savedInstanceState);
            Log.Debug(Tag, $"OnRestoreInstanceState(), name={name}, nameEditText={nameEditText.Text}");
        }

        protected override void OnResume()
        {
            base.OnResume();
            Log.Debug(Tag, $"1.OnResume(), name={this.name}, nameEditText={nameEditText.Text}");

            var pref = this.GetSharedPreferences("pref", FileCreationMode.Private);
            if (pref != null && pref.Contains("name"))
            {
                this.name = nameEditText.Text = pref.GetString("name", string.Empty);

                //# SharedPreferences 객체 초기화
                var editor = pref.Edit();
                editor.Clear();
                editor.Apply();
            }
            Log.Debug(Tag, $"2.OnResume(), name={this.name}, nameEditText={nameEditText.Text}");
        }

        protected override void OnPause()
        {
            base.OnPause();

            Log.Debug(Tag, "OnPause()");

            this.name = nameEditText.Text;
            var pref = this.GetSharedPreferences("pref", FileCreationMode.Private);
            var editor = pref.Edit();
            editor.PutString("name", this.name);
            editor.Apply();
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
