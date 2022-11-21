using System;
using Android.OS;
using AndroidX.AppCompat.App;
using AndroidX.Fragment.App;

namespace Samples
{
    [Android.App.Activity (Label = "@string/title_activity_example")]			
	public class ExampleActivity : AppCompatActivity
	{
		internal static AndroidX.Fragment.App.Fragment selectedExampleFragment = null;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			this.SetContentView(Resource.Layout.activity_example);

			String title = String.Format("{0} - {1}", ControlActivity.selectedControl.ControlName(), ((ExampleFragment) selectedExampleFragment).Title());
			if(SupportActionBar != null) {
				SupportActionBar.Title = title;
			}

			FragmentManager fm = this.SupportFragmentManager;
			FragmentTransaction ft = fm.BeginTransaction();
			ft.Replace(Resource.Id.container, selectedExampleFragment);
			ft.Commit();
		}
	}
}

