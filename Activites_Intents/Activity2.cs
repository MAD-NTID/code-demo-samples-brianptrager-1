using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Activites_Intents
{
    [Activity(Label = "Activity2")]
    public class Activity2 : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_2);
            TextView textView = FindViewById<TextView>(Resource.Id.myTextView);

            var message = base.Intent.GetStringExtra("secretLoveMessage");
            textView.Text = message;
        }
    }
}