using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace DemoRefitRESTClient.Models
{

    // https://api.github.com/search/users?q=location:Mexico
    internal class ApiResponse
    {
        //[JsonProperty(PropertyName ="total_count")]
        public int total_count { get; set; }

        //JsonProperty(PropertyName = "incomplete_results")]
        public bool incomplete_results { get; set; }

        //[JsonProperty(PropertyName = "items")]
        public List<User> items { get; set; }

        public override string ToString()
        {
            return total_count.ToString();
        }
    }
}