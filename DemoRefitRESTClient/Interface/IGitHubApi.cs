using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DemoRefitRESTClient.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoRefitRESTClient.Interface
{
    [Headers("User-Agent: :request:")]
    internal interface IGitHubApi
    {
        [Get("/search/users?q=location:Mexico")]
        Task<ApiResponse> Getuser();
    }
}