using System;
using Android.OS;
using Android.Util;
using Android.Views;
using Com.Telerik.Widget.Dataform.Visualization;
using System.IO;
using Org.Json;
using AndroidX.Fragment.App;

namespace Samples
{
    public class DataFormJsonEditFragment : Fragment, ExampleFragment
	{
		public string Title() {
			return "Json Object Editing";
		}

		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			ViewGroup layoutRoot = (ViewGroup)inflater.Inflate(Resource.Layout.fragment_data_form_json_edit, container, false);
			RadDataForm dataForm = (RadDataForm)layoutRoot.FindViewById(Resource.Id.data_form_json_edit);

			String json = LoadJSONFromAsset ("Person.json");
			try {
				JSONObject jsonObject = new JSONObject (json);
				dataForm.SetEntity(jsonObject);
			} catch(JSONException e) {
				Log.Error ("json", "error parsing json", e);
			}

			return layoutRoot;
		}

		private String LoadJSONFromAsset(String fileName)
		{
			String json = null;
			try
			{
				using (StreamReader sr = new StreamReader (Activity.Assets.Open (fileName)))
				{
					json = sr.ReadToEnd ();
				}
			}
			catch (IOException ex)
			{
				Log.Error("error", ex.StackTrace);
			}
			return json;
		}
	}
}

