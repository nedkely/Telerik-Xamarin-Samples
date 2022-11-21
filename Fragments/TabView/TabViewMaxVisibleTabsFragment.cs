using Android.OS;
using Android.Views;
using Com.Telerik.Android.Primitives.Widget.Tabstrip;
using Com.Telerik.Android.Primitives.Widget.Tabview;

namespace Samples.Fragments.TabView
{
    public class TabViewMaxVisibleTabsFragment : AndroidX.Fragment.App.Fragment, ExampleFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            RadTabView tabView = new RadTabView(Activity);

            for(int i=1; i<=10;i++)
            {
                tabView.Tabs.Add(new Tab("Tab " + i.ToString()));
            }

            tabView.TabStrip.Layout.MaxVisibleTabs = 5;
            return tabView;
        }

        public string Title()
        {
            return "Max Visible Tabs";
        }
    }
}