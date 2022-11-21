﻿using Android.Views;
using Android.OS;
using Com.Telerik.Widget.Calendar;
using System;

namespace Samples
{
	public class DisplayModeFragment : AndroidX.Fragment.App.Fragment, ExampleFragment
	{
		private RadCalendarView calendarView = null;
		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			this.calendarView = new RadCalendarView (Activity);
			this.calendarView.SelectionMode = CalendarSelectionMode.Single;
			this.calendarView.GestureManager.SetDoubleTapToChangeDisplayMode (false);
			this.HasOptionsMenu = true;
			/* 
			 * Setting the display mode with `false` for animation. This way the change
			 * will not be visible at the initial state of the calendar.
			 */
			calendarView.ChangeDisplayMode(CalendarDisplayMode.Week, false); 

			return calendarView;
		}

		public String Title() {
			return "Display modes";
		}

		public override void OnCreateOptionsMenu (IMenu menu, MenuInflater inflater)
		{
			inflater.Inflate(Resource.Menu.calendar_display_modes, menu);
		}

		public override void OnPrepareOptionsMenu (IMenu menu)
		{
			CalendarDisplayMode currentDisplayMode = calendarView.DisplayMode;

			if (currentDisplayMode == CalendarDisplayMode.Month)
			{
				menu.FindItem(Resource.Id.itemMonth).SetEnabled(false);
				menu.FindItem(Resource.Id.itemWeek).SetEnabled(true);
				menu.FindItem(Resource.Id.itemDay).SetEnabled(true);
				menu.FindItem(Resource.Id.itemYear).SetEnabled(true);
				menu.FindItem(Resource.Id.itemMultiDay).SetEnabled(true);
				menu.FindItem(Resource.Id.itemAgenda).SetEnabled(true);
			}
			else if (currentDisplayMode == CalendarDisplayMode.Week)
			{
				menu.FindItem(Resource.Id.itemMonth).SetEnabled(true);
				menu.FindItem(Resource.Id.itemWeek).SetEnabled(false);
				menu.FindItem(Resource.Id.itemDay).SetEnabled(true);
				menu.FindItem(Resource.Id.itemYear).SetEnabled(true);
				menu.FindItem(Resource.Id.itemMultiDay).SetEnabled(true);
				menu.FindItem(Resource.Id.itemAgenda).SetEnabled(true);
			}
			else if (currentDisplayMode == CalendarDisplayMode.Year)
			{
				menu.FindItem(Resource.Id.itemMonth).SetEnabled(true);
				menu.FindItem(Resource.Id.itemWeek).SetEnabled(true);
				menu.FindItem(Resource.Id.itemDay).SetEnabled(true);
				menu.FindItem(Resource.Id.itemYear).SetEnabled(false);
				menu.FindItem(Resource.Id.itemMultiDay).SetEnabled(true);
				menu.FindItem(Resource.Id.itemAgenda).SetEnabled(true);
			}
			else if (currentDisplayMode == CalendarDisplayMode.Day) {
				menu.FindItem(Resource.Id.itemMonth).SetEnabled(true);
				menu.FindItem(Resource.Id.itemWeek).SetEnabled(true);
				menu.FindItem(Resource.Id.itemDay).SetEnabled(false);
				menu.FindItem(Resource.Id.itemYear).SetEnabled(true);
				menu.FindItem(Resource.Id.itemMultiDay).SetEnabled(true);
				menu.FindItem(Resource.Id.itemAgenda).SetEnabled(true);
			}
			else if (currentDisplayMode == CalendarDisplayMode.MultiDay)
			{
				menu.FindItem(Resource.Id.itemMonth).SetEnabled(true);
				menu.FindItem(Resource.Id.itemWeek).SetEnabled(true);
				menu.FindItem(Resource.Id.itemDay).SetEnabled(true);
				menu.FindItem(Resource.Id.itemYear).SetEnabled(true);
				menu.FindItem(Resource.Id.itemMultiDay).SetEnabled(false);
				menu.FindItem(Resource.Id.itemAgenda).SetEnabled(true);
			}
			else if (currentDisplayMode == CalendarDisplayMode.Agenda)
			{
				menu.FindItem(Resource.Id.itemMonth).SetEnabled(true);
				menu.FindItem(Resource.Id.itemWeek).SetEnabled(true);
				menu.FindItem(Resource.Id.itemDay).SetEnabled(true);
				menu.FindItem(Resource.Id.itemYear).SetEnabled(true);
				menu.FindItem(Resource.Id.itemMultiDay).SetEnabled(true);
				menu.FindItem(Resource.Id.itemAgenda).SetEnabled(false);
			}
		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			int itemId = item.ItemId;

			if (itemId == Resource.Id.itemWeek) {
				calendarView.ChangeDisplayMode (CalendarDisplayMode.Week, false); 
				return true;
			} else if (itemId == Resource.Id.itemMonth) {
				calendarView.ChangeDisplayMode (CalendarDisplayMode.Month, false); 
				return true;
			} else if (itemId == Resource.Id.itemYear) {
				calendarView.ChangeDisplayMode (CalendarDisplayMode.Year, false); 
				return true;
			} else if (itemId == Resource.Id.itemDay) {
				calendarView.ChangeDisplayMode(CalendarDisplayMode.Day, false);
				return true;
			}else if(itemId == Resource.Id.itemMultiDay){
				calendarView.ChangeDisplayMode(CalendarDisplayMode.MultiDay, false);
				return true;
			}else if (itemId == Resource.Id.itemAgenda){
				calendarView.ChangeDisplayMode(CalendarDisplayMode.Agenda, false);
				return true;
			}

			return false;
		}
	}
}