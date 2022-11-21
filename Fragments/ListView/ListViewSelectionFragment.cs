
using System;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Com.Telerik.Widget.List;
using System.Collections;
using AndroidX.Fragment.App;

namespace Samples
{
    public class ListViewSelectionFragment : Fragment, ExampleFragment
	{
		private RadListView listView;
		private ArrayList source = new ArrayList();

		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View rootView = inflater.Inflate(Resource.Layout.fragment_list_view_example, container, false);
			this.listView = (RadListView) rootView.FindViewById(Resource.Id.listView).JavaCast<RadListView>();

			SelectionBehavior sb = new SelectionBehavior();
            sb.SetSelectionOnTouch(SelectionBehavior.SelectionOnTouch.Always);

            for (int i = 0; i < 50; i++) {
				source.Add("Item " + i);
			}

			this.listView.AddBehavior(sb);

			this.listView.SetAdapter(new MyListViewAdapter(source));
			return rootView;
		}

		public String Title(){
			return "Selection";
		}

		private ArrayList GetDataPage(int pageSize) {
			ArrayList page = new ArrayList();
			int sourceSize = source.Count;
			for (int i = 0; i < pageSize; i++) {
				page.Add("Item " + (sourceSize + i));
			}
			return page;
		}
	}
}

