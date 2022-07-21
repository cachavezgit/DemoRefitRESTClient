using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using DemoRefitRESTClient.Interface;
using DemoRefitRESTClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Refit;
using System.Collections.Generic;

namespace DemoRefitRESTClient
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        IGitHubApi gitHubApi;
        List<User> usuarios = new List<User>();
        ListView listView;
        IListAdapter listAdapter;
        Button btnListUsers;
        List<string> nombres = new List<string>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = { new StringEnumConverter() }
            };

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            gitHubApi = RestService.For<IGitHubApi>("https://api.github.com");
            listView = FindViewById<ListView>(Resource.Id.listUsuarios);
            btnListUsers = FindViewById<Button>(Resource.Id.btnConsultaUsuarios);
            btnListUsers.Click += BtnListUsers_Click;
        }

        private void BtnListUsers_Click(object sender, System.EventArgs e)
        {
            GetUsuarios();
        }

        private async void GetUsuarios()
        {
            try
            {
                ApiResponse respuesta = await gitHubApi.Getuser();
                usuarios = respuesta.items;
                Toast.MakeText(this, usuarios.Count.ToString(), ToastLength.Long).Show();

                foreach(User u in usuarios)
                {
                    nombres.Add(u.login);
                }

                listAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, nombres);
                listView.Adapter = listAdapter;
            }
            catch(System.Exception ex)
            {
                Toast.MakeText(this, ex.StackTrace, ToastLength.Long).Show();
                System.Console.WriteLine(ex.StackTrace);
            }
        }

        

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}