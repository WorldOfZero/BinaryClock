using Android.App;
using Android.Widget;
using Android.OS;

namespace BinaryClock.Android
{
    [Activity(Label = "BinaryClock.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            var button = FindViewById<Button>(Resource.Id.button1);
            button.Click += (o,e) => sayHello();
        }

        public void sayHello()
        {
            var playerName = FindViewById<EditText>(Resource.Id.playerName);
            var playerGreeting = FindViewById<TextView>(Resource.Id.playerGreeting);
            playerGreeting.Text = "Hello, " + playerName.Text;
        }
    }
}

