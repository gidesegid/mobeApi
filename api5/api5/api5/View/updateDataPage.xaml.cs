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
    public partial class updateDataPage : ContentPage
    {
        public updateDataPage()
        {
            InitializeComponent();
        }
        public async void update(object sender, EventArgs e)
        {
            DataService myservice = new DataService();
            jaarboek datatoupdate = new jaarboek
            {
                id = Convert.ToInt32(id.Text),
                name = name.Text,
                description = description.Text,
                jaarboekId = Convert.ToInt32(jaarboekId.Text)
            };
            await myservice.UpdateDataAsync(datatoupdate);
            
        }
    }
}
