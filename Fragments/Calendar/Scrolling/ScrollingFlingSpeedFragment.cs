using System;
using System.Collections.Generic;
using Android.Views;
using Android.OS;
using Com.Telerik.Widget.Calendar;
using Android.Content;
using Android.Widget;


namespace Samples
{
	public class ScrollingFlingSpeedFragment : AndroidX.Fragment.App.Fragment, ExampleFragment
	{
		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			RadCalendarView calendarView = new RadCalendarView (Activity);

			calendarView.ScrollMode = ScrollMode.Combo;
			calendarView.AnimationsManager.FlingSpeed = 0.05F;

			return calendarView;
		}

		public String Title() {
			return "Scrolling fling speed";
		}
	}
}