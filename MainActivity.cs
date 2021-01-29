using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;

namespace Calculator
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
 
        private TextView input;
        private TextView output; 
        private string[] numbers = new string[2];
        private string @operator; 

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            input = FindViewById<TextView>(Resource.Id.inputDisplay);
            output = FindViewById<TextView>(Resource.Id.outputDisplay);
        }

        [Java.Interop.Export("ButtonClick")]
        public void ButtonClick(View v)
        {
            Button button = (Button)v;
            if ("0123456789.".Contains(button.Text))
            {
                //add the number or decimal to the string element
                AddNumOrDec(button.Text);
            }
            else if ("+-×÷%".Contains(button.Text))
            {
                //perform operation
                AddOperator(button.Text);
            }
            else if ("=" == button.Text)
            {
                //calculate equation
                Calculate();
            }
            else
            {
                Erase();
            }
        }

        // Concatenate characters to create numbers for calculation
        private void AddNumOrDec(string value)
        {
            // keep this in mind when implementing negative numbers
            int ind = @operator == null ? 0 : 1;

            if (value == "." && numbers[ind].Contains(".")) return;

            numbers[ind] += value;

            DisplaySym();
        }

        private void AddOperator(string value)
        {
            if(numbers[1] != null)
            {
                Calculate(value);
                return;
            }
            @operator = value;
            DisplaySym();
        }

        private void Calculate(string newOperator = null)
        {
            double? result = null;
            double? first = numbers[0] == null ? null : (double?)double.Parse(numbers[0]);
            double? second = numbers[1] == null ? null : (double?)double.Parse(numbers[1]);

            switch (@operator)
            {
                case "÷":
                    result = first / second;
                    break;
                case "×":
                    result = first * second;
                    break;
                case "+":
                    result = first + second;
                    break;
                case "-":
                    result = first - second;
                    break;
                case "%":
                    result = first % second;
                    break;
            }

            if (result != null)
            {
                numbers[0] = result.ToString();
                @operator = newOperator;
                numbers[1] = null;
                DisplayResult(result);
            }
        }

        private void Erase()
        {
            numbers[0] = numbers[1] = null;
            @operator = null;
            DisplaySym();
            DisplayResult(null);

        }

        private void DisplaySym() => input.Text = $"{numbers[0]} {@operator} {numbers[1]}";
        private void DisplayResult(double? result) => output.Text = $"{result}";
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}