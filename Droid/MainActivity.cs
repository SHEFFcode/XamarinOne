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
                    return;
                } else {
                    if (resultTextView.Text.Length > 0)
                    {
                        resultTextView.Text = "";
                    }
                    try
                    {
                        var result = Convert.ToDouble(amountEditText.Text) * 0.69;
                        resultTextView.Text = $"USD {amountEditText.Text} is {result} GBP";
                    }
                    catch (System.Exception ex)
                    {
                        Toast.MakeText(this, "Please enter a number", ToastLength.Long).Show();
                        amountEditText.Text = "";
                        Console.WriteLine("Error in conversion " + ex.Message);
                    }
                }
            };
        }
    }
}

