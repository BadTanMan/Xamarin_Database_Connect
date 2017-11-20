using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TinderBayHistory
{
    class SalesList
    {
        public int Sales_id { get; set; }
        public decimal Sales_price { get; set; }
        public DateTime Date_sold { get; set; }
        public string User_id { get; set; }
        public string Product_id { get; set; }
    }
}