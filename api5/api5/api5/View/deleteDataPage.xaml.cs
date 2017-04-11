using api5.Model;
using api5.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace api5.View
{
    public partial class deleteDataPage : ContentPage
    {
        public deleteDataPage()
        {
            InitializeComponent();
        }
        public async void deleteData(object sender, EventArgs e)
        {
            DataService myservice = new DataService();

            //await myservice.DeleteDataAsync(Convert.ToInt32(id.Text));   
            jaarboek myId = new jaarboek
            {
                id = Convert.ToInt32(id.Text)
            };
           await myservice.DeleteDataAsync(myId);
    }
    }
}
