using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using System;
using Android.Content;

namespace Activites_Intents
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        int count = 0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Button button = FindViewById<Button>(Resource.Id.myButton);

            //button.Click += (o, e) => {
            //  Toast.MakeText(this, "Beep Boop", ToastLength.Short).Show();
            //};
            button.Click += myButton_Click;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void myButton_Click(object sender, EventArgs e)
        {
            //count++;
            //Toast.MakeText(this, "Beep Boop " + count.ToString(), ToastLength.Short).Show();
            var bundle = new Bundle();
            bundle.PutString("secretLoveMessage", "You're so hot!!");

            var intent = new Intent(this, typeof(Activity2));
            intent.PutExtras(bundle);
            base.StartActivity(intent);
        }

    }
}