using Android.App;
using Android.Widget;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Java.IO;
using Java.Lang;
using Java.Net;
using Java.Util;
using Org.Json;

namespace AppliTest.Droid
{
	[Activity (Label = "Meteo by zipCode", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        private static string LOG_TAG = "Google Places Autocomplete";
	    private static string PLACES_API_BASE = "https://maps.googleapis.com/maps/api/place";
	    private static string TYPE_AUTOCOMPLETE = "/autocomplete";
	    private static string OUT_JSON = "/json";

	    private static string API_KEY = "AIzaSyDjx-u1XNb0_iyIlKFkpD0nZFTndF0J-w4";

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            EditText zipCodeField = FindViewById<EditText>(Resource.Id.editText1);
            Button update = FindViewById<Button>(Resource.Id.button1);

		    TextView tempText = FindViewById<TextView>(Resource.Id.textViewTemp);
            TextView humidText = FindViewById<TextView>(Resource.Id.textViewHumid);
            TextView sunriseText = FindViewById<TextView>(Resource.Id.textViewSunrise);
            TextView windText = FindViewById<TextView>(Resource.Id.textViewWind);
            TextView sunsetText = FindViewById<TextView>(Resource.Id.textViewSunset);
            TextView visibilityText = FindViewById<TextView>(Resource.Id.textViewVisibility);

            update.Click += delegate
			{
			    string zipCode = zipCodeField.Text;
                if(zipCode.Length == 5)
                {
                    var weather = Core.GetWeather(zipCode).Result;
                    tempText.SetText(weather.Temperature, TextView.BufferType.Normal);
                    humidText.SetText(weather.Humidity, TextView.BufferType.Normal);
                    sunriseText.SetText(weather.Sunrise, TextView.BufferType.Normal);
                    windText.SetText(weather.Wind, TextView.BufferType.Normal);
                    sunsetText.SetText(weather.Sunset, TextView.BufferType.Normal);
                    visibilityText.SetText(weather.Visibility, TextView.BufferType.Normal);
                }
            };

		    if (!zipCodeField.Text.Equals("")) return;
		    tempText.SetText("", TextView.BufferType.Normal);
		    humidText.SetText("", TextView.BufferType.Normal);
		    sunsetText.SetText("", TextView.BufferType.Normal);
		    sunriseText.SetText("", TextView.BufferType.Normal);
		    windText.SetText("", TextView.BufferType.Normal);
		    visibilityText.SetText("", TextView.BufferType.Normal);

            AutoCompleteTextView autoCompView = (AutoCompleteTextView)FindViewById(Resource.Id.autoCompleteTextView);

            //autoCompView.setAdapter(new GooglePlacesAutocompleteAdapter(this, Resource.Layout.list_item));
            //autoCompView.ItemClickListener(this);
        }
	}
}


