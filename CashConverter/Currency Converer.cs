using System;
namespace CashConverter
{
    public class Currency_Converer
    {
        string amountToConvert;

        public Currency_Converer(string _input)
        {
            amountToConvert = _input;
        }

        public string ConvertCurrency()
        {
            var output = "";
            if (amountToConvert.Length < 1)
            {
                output = "Please enter something, silly goose!";
            }
            else 
            {
                try
                {
                    var result = Convert.ToDouble(amountToConvert) * 0.69;
                    output = $"USD {amountToConvert} is {result} GBP";
                }
                catch (System.Exception ex)
                {
                    output = "Please enter a number you stilly goose.";
                    Console.WriteLine("Error in conversion " + ex.Message);
                }
            }
            return output;
        }
    }
}
