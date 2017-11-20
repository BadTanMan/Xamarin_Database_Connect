using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Android.App;
using Android.Content.PM;
using Android.Content;
using System.Net.Http;
using System.Threading.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
namespace TinderBayHistory
{
    [Activity(Label = "TinderBayHistory", MainLauncher = true, Icon = "@drawable/icon", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        bool RefreshCheck = false;

        //create array
        SalesList[] sellDetails;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //set page and title bar
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.Main);

            var jsonString1 = FindViewById<TextView>(Resource.Id.textView12p);
            TextView jsonString2 = FindViewById<TextView>(Resource.Id.textView13p);
            Button button1 = FindViewById<Button>(Resource.Id.button1p);                     

            button1.Click += delegate
            {
                    var newActivity = new Intent(this, typeof(PurchasePage));
                    StartActivity(newActivity);
            };

            ///!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //MARTIN YOU NEED TO MAKE A NEW BUTTON FOR THIS METHOD
            Button button2 = FindViewById<Button>(Resource.Id.button1);
            button2.Click += async (sender, args) =>
            {
                if (RefreshCheck == false)
                {
                    RefreshCheck = true;
                    button2.Text = "Refresh";
                }

                await DataRefreshAsync();
                jsonString1.Text = "Sold:" + (sellDetails[0].Date_sold).ToString();
                jsonString1.SetTextColor(Android.Graphics.Color.DarkGreen);
                jsonString2.Text = "Sold:" + (sellDetails[1].Date_sold).ToString();
                jsonString2.SetTextColor(Android.Graphics.Color.DarkGreen);
            };
            ///!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            ///!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        }
        //establishes a connection to webAPI and retrives purchased items in a json file
        private async Task<List<SalesList>> DataRefreshAsync()
        {
            //Instantiating HTTPClient
            HttpClient client = new HttpClient();
            //String address (URL)
            var address = "http://profferapi20171114093444.azurewebsites.net/api/SalesModels";
            //Awaiting Response
            var response = await client.GetAsync(address);
            string PurchaseJson = response.Content.ReadAsStringAsync().Result;
            List<SalesList> sales = JsonConvert.DeserializeObject<List<SalesList>>(PurchaseJson);

            sellDetails = sales.ToArray();
            return sales;
        }
    }
}

