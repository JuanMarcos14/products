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
	public partial class AddProduct : ContentPage
	{
		public AddProduct ()
		{
			InitializeComponent ();
		}

        private async void BtnSave_Clicked(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text;
                decimal price = decimal.Parse(txtPrice.Text);

                using (var client = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(new { id = -1, name, price }), Encoding.UTF8, "application/json");

                    using (var result = await client.PostAsync("https://productosapi.azurewebsites.net/api/products", content))
                    {
                        await App.MasterD.Detail.Navigation.PopAsync(true);
                    }
                }
            }
            catch (Exception)
            {
                Toast.MakeText(Android.App.Application.Context, "No tiene conexión de internet.", ToastLength.Long).Show();
            }

        }
    }
}