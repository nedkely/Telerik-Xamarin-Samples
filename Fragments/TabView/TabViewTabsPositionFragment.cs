using Android.OS;
using Android.Views;
using Com.Telerik.Android.Primitives.Widget.Tabstrip;
using Com.Telerik.Android.Primitives.Widget.Tabview;

namespace Samples.Fragments.TabView
{
    public class TabViewTabsPositionFragment : AndroidX.Fragment.App.Fragment, ExampleFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            RadTabView tabView = new RadTabView(Activity);

            tabView.Tabs.Add(new Tab("Tab 1"));
            tabView.Tabs.Add(new Tab("Tab 2"));
            tabView.Tabs.Add(new Tab("Tab 3"));

            tabView.TabsPosition = TabsPosition.Top;
            tabView.TabStrip.TabsAlignment = TabsAlignment.Center;

            return tabView;
        }

        public string Title()
        {
            return "Tabs Position";
        }
    }
}