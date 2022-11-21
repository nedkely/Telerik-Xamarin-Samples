using System;
using Java.Util;
using Samples.Fragments.TabView;

namespace Samples
{
    public class TabViewExamples : Java.Lang.Object, ExamplesProvider
    {
        private LinkedHashMap tabviewExamples;

        public TabViewExamples()
        {
            this.tabviewExamples = this.GetTabViewExamples();
        }

        public String ControlName()
        {
            return "TabView";
        }

        private LinkedHashMap GetTabViewExamples()
        {
            LinkedHashMap examples = new LinkedHashMap();
            ArrayList result = new ArrayList();

            result.Add(new TabViewGettingStartedFragment());           
            result.Add(new TabViewTabsPositionFragment());
            result.Add(new TabViewMaxVisibleTabsFragment());
            result.Add(new TabViewListeningForChangesFragment());
            examples.Put("Init", result);

            return examples;
        }

        public LinkedHashMap Examples()
        {
            return this.tabviewExamples;
        }
    }
}