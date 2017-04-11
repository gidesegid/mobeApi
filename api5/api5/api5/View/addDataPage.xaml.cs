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
    public partial class addDataPage : ContentPage
    {
        public addDataPage()
        {
            InitializeComponent();
          
        }
        public  async void AddButton_Clicked(object sender, System.EventArgs e)
         {
             DataService myservice = new DataService();
             jaarboek addinfo = new jaarboek
             {
                 name = name.Text.Trim(),
                 description = description.Text.Trim(),
                 jaarboekId = Convert.ToInt32(jaarboekId.Text.Trim()),
                  imageId = Convert.ToInt32(imageId.Text.Trim())
             };
             await myservice.AddDataAsync(addinfo);
         }
        //picUpload
        public void picUpload(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new picUpload());
        }
    }
}
