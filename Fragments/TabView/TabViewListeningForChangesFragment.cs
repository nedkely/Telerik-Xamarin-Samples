using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using Com.Telerik.Android.Primitives.Widget.Tabstrip;
using Com.Telerik.Android.Primitives.Widget.Tabview;

namespace Samples.Fragments.TabView
{
    public class TabViewListeningForChangesFragment : AndroidX.Fragment.App.Fragment, ExampleFragment, ITabViewChangeListener
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
            tabView = new RadTabView(Activity);

            tabView.Tabs.Add(new Tab("Tab 1"));
            tabView.Tabs.Add(new Tab("Tab 2"));
            tabView.Tabs.Add(new Tab("Tab 3"));

            tabView.AddChangeListener(this);
            
            return tabView;
        }

        public bool OnSelectingTab(Tab tabToSelect)
        {
            return false;
        }

        public void OnTabSelected(Tab selectedTab, Tab deselectedTab)
        {
            if (deselectedTab != null)
            {
                Log.Debug("TabView deselected: ", deselectedTab.Title);
            }
            Log.Debug("TabView selected: ", selectedTab.Title);
        }

        public string Title()
        {
            return "Listening for changes";
        }
    }
}