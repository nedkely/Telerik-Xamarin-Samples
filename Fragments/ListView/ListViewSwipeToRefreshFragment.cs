﻿
using System;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Com.Telerik.Widget.List;
using System.Collections;
using AndroidX.Fragment.App;

namespace Samples
{
    public class ListViewSwipeToRefreshFragment : Fragment, ExampleFragment, SwipeRefreshBehavior.ISwipeRefreshListener
	{

		private SwipeRefreshBehavior srb;
		private RadListView listView;
		private ArrayList source = new ArrayList();

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{ 
			View rootView = inflater.Inflate(Resource.Layout.fragment_list_view_example, container, false);
	
			this.listView = (RadListView) rootView.FindViewById(Resource.Id.listView).JavaCast<RadListView>();

			for (int i = 0; i < 10; i++) {
				source.Add("Item " + i);
			}

			this.listView.SetAdapter(new MyListViewAdapter(source));

			srb = new SwipeRefreshBehavior();
			srb.AddListener(this);
			this.listView.AddBehavior(srb);

			return rootView;

		}

		public String Title(){
			return "Swipe to refresh";
		}

		public void OnRefreshRequested ()
		{
			MyListViewAdapter currentAdapter = (MyListViewAdapter)listView.GetAdapter();
			Java.Util.ArrayList dataPage = getDataPage(10);

			for (int i = 0; i < dataPage.Size(); i++) {
				currentAdapter.Add(i, dataPage.Get(i));
			}

			srb.EndRefresh(true);
		}

		private Java.Util.ArrayList getDataPage(int pageSize) {
			Java.Util.ArrayList page = new Java.Util.ArrayList();
			int sourceSize = listView.GetAdapter ().ItemCount;
			for (int i = 0; i < pageSize; i++) {
				page.Add("Item " + (sourceSize + i));
			}
			return page;
		}
	}
}

