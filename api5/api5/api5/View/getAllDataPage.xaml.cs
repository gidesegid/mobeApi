using api5.Model;
using api5.Service;
using api5.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace api5.View
{
    public partial class getAllDataPage : ContentPage
    {
        public getAllDataPage()
        {
            InitializeComponent();
            RefreshData();
            //BindingContext = new jaarboek();
            //List<jaarboek> mydata = new List<jaarboek>();
            //MainListView.ItemsSource = mydata;

        }
       async void RefreshData()
        {
            DataService myDataService = new DataService();
             var items = await myDataService.GetDataAsync();
            MainListView.ItemsSource = items.OrderBy(item => item.name).ThenBy(item => item.description).ToList();
        }
    }
}
