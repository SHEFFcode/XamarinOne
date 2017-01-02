using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace CashConverter.Droid
{
    [Activity(Label = "Cash Converter", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);
            EditText amountEditText = FindViewById<EditText>(Resource.Id.editTextAmount);
            TextView resultTextView = FindViewById<TextView>(Resource.Id.textViewResult);

            button.Click += delegate { 
                if (amountEditText.Text.Length < 1)
                {
                    Toast.MakeText(this, "Please enter something to convert", ToastLength.Long).Show();
                    return;
                } else {
                    if (resultTextView.Text.Length > 0)
                    {
                        resultTextView.Text = "";
                    }
                    var convert = new Currency_Converer(amountEditText.Text);
                    var result = convert.ConvertCurrency();
                    if (result is string)
                    {
                        Toast.MakeText(this, result, ToastLength.Long).Show();
                    }
                    else 
                    {
                        resultTextView.Text = result;
                    }

                }
            };
        }
    }
}

