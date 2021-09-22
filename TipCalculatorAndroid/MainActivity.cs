using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using System;

namespace TipCalculatorAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private RadioGroup tipRadioGroup;
        private TextView tipAmount;
        private EditText amount;
        private RadioButton checkedRadioButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);


            amount = FindViewById<EditText>(Resource.Id.amountInput);
            tipAmount = FindViewById<TextView>(Resource.Id.tipAmount);
            tipRadioGroup = FindViewById<RadioGroup>(Resource.Id.tipRateGroup);
            checkedRadioButton = FindViewById<RadioButton>(tipRadioGroup.CheckedRadioButtonId);

            amount.Text = $"0.00";
            tipAmount.Text = $"{0.00:C}";
            amount.TextChanged += Amount_TextChanged;
            tipRadioGroup.CheckedChange += TipRateGroup_CheckedChange;
        }

        private void Amount_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            CalculateTip();
        }

        private void TipRateGroup_CheckedChange(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            int checkedItemId = tipRadioGroup.CheckedRadioButtonId;
            checkedRadioButton = FindViewById<RadioButton>(checkedItemId);
            CalculateTip();
            //Toast.MakeText(this, Convert.ToString(checkedRadioButton.Text), ToastLength.Short).Show();
            //throw new System.NotImplementedException();
        }

        private void CalculateTip()
        {
            if (!(amount.Text == "" || amount.Text == null))
            {
                double tipRate = 0;
                switch (checkedRadioButton.Text)
                {
                    case "15%":
                        tipRate = .15;
                        break;
                    case "20%":
                        tipRate = .2;
                        break;
                    case "25%":
                        tipRate = .25;
                        break;
                    default:
                        tipRate = 0;
                        break;
                }
                tipAmount.Text = String.Format($"{((double.Parse(amount.Text) * tipRate)):C}");
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}