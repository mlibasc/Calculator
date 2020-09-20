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
        /*TextView output;
        Button button_clear, button_add_sub, button_percent, button_divide, button_seven, button_eight, button_nine, button_multiply,
            button_four, button_five, button_six, button_subtract, button_one, button_two, button_three, button_add, button_zero,
            button_period, button_equals;*/
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            input = FindViewById<TextView>(Resource.Id.inputDisplay);
            //button_clear = (Button)findViewById(Resource.id.button_clear);

        }

        [Java.Interop.Export("ButtonClick")]
        public void ButtonClick(View v)
        {
            Button button = (Button)v;
            if ("0123456789.".Contains(button.Text))
            {
                //add the number or decimal 
                AddNumOrDec(button.Text);
            }else if ("+-/x%".Contains(button.Text))
            {
                //perform operation
                AddOperator(button.Text);
            }
            else if ("=".Contains(button.Text))
            {
                //calculate equation
                Calculate();
            }
            else
            {
                Erase();
            }
        }

        private void AddNumOrDec(string text)
        {

        }

        private void AddOperator(string text)
        {

        }

        private void Calculate()
        {

        }

        private void Erase()
        {

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}