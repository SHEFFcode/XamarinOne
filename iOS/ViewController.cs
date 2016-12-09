using System;

using UIKit;

namespace CashConverter.iOS
{
    public partial class ViewController : UIViewController
    {

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            convertButton.AccessibilityIdentifier = "myButton";
            convertButton.TouchUpInside += delegate
            {
                if (amountTextField.Text.Length < 1)
                {
                    return;
                }
                else 
                {
                    try
                    {
                        var result = Convert.ToDouble(amountTextField.Text) * 0.69;
                        resultLabel.Text = $"$ {amountTextField.Text} = {result.ToString()} GBP";
                    }
                    catch (Exception ex)
                    {
                        new UIAlertView("error", "please enter a number", null, "ok", null).Show();
                        amountTextField.Text = "";
                        Console.WriteLine("Error in conversion." + ex.Message);
                    }

                }
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }
    }
}
