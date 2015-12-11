
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using System.Net;
using Android.Text;
using System.Collections.Generic;

namespace AppTest2.Droid
{

    [Activity(Label = "Weather Test App", MainLauncher = true)]
    public class MainActivity : Activity
    {
        EditText fieldNumber;

        TextView textViewHumidity;
        TextView textViewSun;
        TextView textViewTemp;
        TextView textViewVisibility;
        TextView textViewWind;
        Button buttonSubmit;
        AutoCompleteTextView autoCompletedTextViewField;
        List<AppTest2.CityRequest.Place> autocompletedCitiesList;
        ArrayAdapter autoCompleteAdapter;
        SearchLock searchlock;

        ImageView ImageWeather;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            searchlock = new SearchLock();

            SetContentView(Resource.Layout.Main);

            buttonSubmit = FindViewById<Button>(Resource.Id.ButtonSubmit);
            textViewHumidity = FindViewById<TextView>(Resource.Id.textViewHumidity);
            textViewSun = FindViewById<TextView>(Resource.Id.textViewSun);
            textViewTemp = FindViewById<TextView>(Resource.Id.textViewTemp);
            textViewVisibility = FindViewById<TextView>(Resource.Id.textViewVisibility);
            textViewWind = FindViewById<TextView>(Resource.Id.textViewWind);
            ImageWeather = FindViewById<ImageView>(Resource.Id.ImageWeather);
            autoCompletedTextViewField = FindViewById<AutoCompleteTextView>(Resource.Id.AutoCompleteText);



            buttonSubmit.Click += delegate
            {
                try
                {
                    string cityname = autoCompletedTextViewField.Text;
                    int firstvirg = cityname.IndexOf(",");
                    cityname = cityname.Substring(0, firstvirg);

                    AppTest2.CityRequest.Place place = Core.GetCity(cityname);
                    if (place != null)
                    {
                        AppTest2.WeatherRequest.Channel weather= Core.GetWeather(place.woeid);

                        if (weather != null)
                        {
                            textViewHumidity.Text = weather.atmosphere.humidity;
                            textViewSun.Text = weather.astronomy.sunset;
                            textViewTemp.Text = weather.units.temperature;
                            textViewVisibility.Text = weather.atmosphere.visibility;
                            textViewWind.Text = weather.wind.speed;

                            var imageBitmap = GetImageBitmapFromUrl(weather.item.description);
                            ImageWeather.SetImageBitmap(imageBitmap);
                            Toast toast = Toast.MakeText(this, "Result for " + fieldNumber.Text, ToastLength.Short);
                            toast.Show();
                        }
                        else
                        {
                            Toast toast = Toast.MakeText(this, "Unknown city", ToastLength.Long);
                            toast.Show();
                        }
                    }
                    
                }
                catch (System.Exception ex)
                {
                    Toast toast = Toast.MakeText(this, "Error :  " + ex.Message, ToastLength.Long);
                    toast.Show();
                }
            };

            autoCompletedTextViewField.AfterTextChanged += delegate
              {
                  try
                  {
                      if (!searchlock.IsCountrySearching)
                      {
                          string[] autoCompleteOptions = new string[4];
                          if (autoCompletedTextViewField.Text.Length > 4)
                          {
                              searchlock.IsCountrySearching = true;
                              autocompletedCitiesList = Core.GetCities(autoCompletedTextViewField.Text);
                              if (autocompletedCitiesList != null)
                              {
                                  for (int i = 0; i < 4; i++)
                                  {
                                      autoCompleteOptions[i] = string.Format("{0},{1} / {2}", autocompletedCitiesList[i].name, autocompletedCitiesList[i].country.content, autocompletedCitiesList[i].admin1.content);
                                  }
                                  autoCompleteAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleDropDownItem1Line, autoCompleteOptions);
                                  autoCompletedTextViewField.Adapter = autoCompleteAdapter;
                                  autoCompletedTextViewField.ShowDropDown();
                              }
                              searchlock.IsCountrySearching = false;
                          }
                      }
                  }
                  catch (System.Exception ex)
                  {
                      searchlock.IsCountrySearching = false;
                      Toast toast = Toast.MakeText(this, "Error :  "+ ex.Message, ToastLength.Long);
                      toast.Show();
                  }


                                   
              };
        }

        private Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }

    }
}


