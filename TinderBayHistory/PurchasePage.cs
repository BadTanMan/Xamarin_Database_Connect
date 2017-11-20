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
    [Activity(Label = "PurchasePage", ScreenOrientation = ScreenOrientation.Portrait)]
    public class PurchasePage : Activity
    {
        //create array
        public bool RefreshCheck = false;
        PurchaseList[] buyDetails;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.purchaseLayout);           

            //display item [1](Name only) in textView1
            var jsonString1 = FindViewById<TextView>(Resource.Id.textView12p);
            TextView jsonString2 = FindViewById<TextView>(Resource.Id.textView13p);
            Button button2 = FindViewById<Button>(Resource.Id.button1);

            button2.Click += async (sender, args) =>
            {
                if (RefreshCheck == false)
                {
                    RefreshCheck = true;
                    button2.Text = "Refresh";
                }

                await DataRefreshAsync();
                jsonString1.Text = buyDetails[1].Name;
                jsonString1.SetTextColor(Android.Graphics.Color.DarkGreen);
                jsonString2.Text = buyDetails[2].Name;
                jsonString2.SetTextColor(Android.Graphics.Color.DarkGreen);
            };
        }

        //establishes a connection to webAPI and retrives purchased items in a json file
        private async Task<List<PurchaseList>> DataRefreshAsync()
        {
            //Instantiating HTTPClient
            HttpClient client = new HttpClient();
            //String address (URL)
            var address = "http://profferapi20171114093444.azurewebsites.net/api/ProductsModels";
            //Awaiting Response
            var response = await client.GetAsync(address);
            string PurchaseJson = response.Content.ReadAsStringAsync().Result;
            List<PurchaseList> purchases = JsonConvert.DeserializeObject<List<PurchaseList>>(PurchaseJson);

            buyDetails = purchases.ToArray();
            return purchases;
        }
    }
}