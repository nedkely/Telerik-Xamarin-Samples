using Android.OS;
using Android.Views;
using Android.Widget;
using Com.Telerik.Android.Primitives.Widget.Tabstrip;
using Com.Telerik.Android.Primitives.Widget.Tabview;

namespace Samples.Fragments.TabView
{
    public class TabViewGettingStartedFragment : AndroidX.Fragment.App.Fragment, ExampleFragment, ITabViewChangeListener
    {
        private RadTabView tabView;
        public Java.Lang.Object GetContentViewForTab(Tab tab)
        {
            TextView contentView = new TextView(this.Context);
            contentView.Text = "Content view for " + tab.Title;
            contentView.Gravity = GravityFlags.Center;
            return contentView;
        }

        public TabItemView GetViewForTab(Tab p0)
        {
            return null;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View rootView = inflater.Inflate(Resource.Layout.fragment_tabview_getting_started, container, false);           
            tabView = (RadTabView)rootView.FindViewById(Resource.Id.tabview);

            tabView.Tabs.Add(new Tab("Tab 1"));
            tabView.Tabs.Add(new Tab("Tab 2"));
            tabView.Tabs.Add(new Tab("Tab 3"));

            tabView.AddChangeListener(this);

            return rootView;
        }

        public bool OnSelectingTab(Tab p0)
        {
            return false;
        }

        public void OnTabSelected(Tab p0, Tab p1)
        {
           
        }

        public string Title()
        {
            return "Getting Started";
        }
    }
}