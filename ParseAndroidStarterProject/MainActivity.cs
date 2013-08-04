using System;

using Android.App;
using Android.Widget;
using Android.OS;

using Parse;

namespace ParseAndroidStarterProject
{
	[Activity (Label = "ParseAndroidStarterProject", MainLauncher = true)]
	public class Activity1 : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            var button = FindViewById<Button>(Resource.Id.myButton);

		    button.Click += button_Click;
		}

        public async void button_Click(object sender, EventArgs e)
        {
            var testObject = new ParseObject("TestObject");
            testObject["foo"] = "bar";
            await testObject.SaveAsync();
            FindViewById<Button>(Resource.Id.myButton).Text = "foo bar saved to Parse";
        }
	}
}


