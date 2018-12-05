using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Product
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class detail : ContentPage
	{
		public detail ()
		{
			InitializeComponent ();           
        }

        protected override void OnAppearing()
        {
            try
            {
                List<Models.Product> products = new List<Models.Product>();

                using (var client = new HttpClient())
                {
                    using (var result = client.GetAsync("https://productosapi.azurewebsites.net/api/products").Result)
                    {
                        if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            using (var content = result.Content)
                            {
                                string data = content.ReadAsStringAsync().Result;
                                products = JsonConvert.DeserializeObject<List<Models.Product>>(data);
                            }
                        }
                    }
                }

                lista.ItemsSource = products;
            }
            catch (Exception)
            {
                Toast.MakeText(Android.App.Application.Context, "No tiene conexión de internet.", ToastLength.Long).Show();
            }
        }
    }
}