using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Product
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {            
            InitializeComponent();
            Master = new MasterPage();
            Detail = (new detail());

            App.MasterD = this;
        }
    }
}
