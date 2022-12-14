using System;
using System.Collections.Generic;
using Android.Views;
using Android.OS;
using Com.Telerik.Widget.Calendar;
using Android.Content;
using Android.Widget;


namespace Samples
{
	public class ScrollingProgramatticallyFragment : AndroidX.Fragment.App.Fragment, ExampleFragment
	{
		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			RadCalendarView calendarView = new RadCalendarView (Activity);
			calendarView.ScrollMode = ScrollMode.None;
			calendarView.HorizontalScroll = true;
			calendarView.SetOnTouchListener(new TouchListener());

			return calendarView;
		}

		public String Title() {
			return "Scroll programmatically";
		}

		private class TouchListener : Java.Lang.Object, View.IOnTouchListener
		{
			public bool OnTouch (View v, MotionEvent e)
			{
				RadCalendarView calendarView = v as RadCalendarView;
				if (e.Action == MotionEventActions.Up) {
					if (e.GetX () < calendarView.Width / 2) {
						calendarView.AnimateToPrevious ();
					} else {
						calendarView.AnimateToNext ();
					}
				}

				return true;
			}
		}
	}
}