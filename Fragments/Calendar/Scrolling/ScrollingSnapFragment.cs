﻿using System;
using System.Collections.Generic;
using Android.Views;
using Android.OS;
using Com.Telerik.Widget.Calendar;
using Android.Content;
using Android.Widget;


namespace Samples
{
	public class ScrollingSnapFragment : AndroidX.Fragment.App.Fragment, ExampleFragment
	{
		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			RadCalendarView calendarView = new RadCalendarView (Activity);

			calendarView.AnimationsManager.SetSnapSpeed (.01f);

			return calendarView;
		}

		public String Title() {
			return "Snap speed";
		}
	}
}