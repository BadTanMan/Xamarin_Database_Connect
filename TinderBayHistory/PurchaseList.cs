using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TinderBayHistory
{
    class PurchaseList
    {
         public string Product_id { get; set; }
         public string Name { get; set; }
         public decimal Price { get; set; }
         public string Description { get; set; }
         public string Tag { get; set; }
         public DateTime Upload_date { get; set; }
         public int Image_int { get; set; }
         public string User_id { get; set; }
    }
}