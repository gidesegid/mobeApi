using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace api5.View
{
    public partial class allPages : ContentPage
    {
        public allPages()
        {
            InitializeComponent();
        }
        public void showLists(object sender, EventArgs e)
        {
            Navigation.PushAsync(new getAllDataPage());
        }
        public  void addData(object sender, EventArgs e)
        {
            Navigation.PushAsync(new addDataPage());
        }
        public  void updateData(object sender, EventArgs e)
        {
            Navigation.PushAsync(new updateDataPage());
        }
        public void deleteData(object sender, EventArgs e)
        {
            Navigation.PushAsync(new deleteDataPage());
        }
        public void showData(object sender, EventArgs e)
        {
            Navigation.PushAsync(new lookupPage());
        }
    }
}
