using api5.Model;
using api5.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using System.Globalization;
using System.IO;

namespace api5.View
{
    public partial class lookupPage : ContentPage
    {
        public lookupPage()
        {
            InitializeComponent();
            
        }
      public async void showdata(object sender, EventArgs e)
        {
            DataService myservice = new DataService();
            string resultOfMyName = myname.Text;
           var x = await myservice.getDataByName(resultOfMyName);
            name.Text = x[0].name;
            description.Text = x[0].description;
           jaarboekId.Text = Convert.ToString(x[0].jaarboekId);
            imageId.Text = Convert.ToString(x[0].imageId);
            fileName.Text = x[0].fileName;
            string filename= x[0].fileName;
            Byte[] imageName = System.Convert.FromBase64String(filename);
           // imageName.ImageSource = imageName;
           // imageName.SetBinding(Image.ImageSource, new Binding("fileName", BindingMode.Default, new ConverterBase64ImageSource(), null, null));
        }
    }
    public class ConverterBase64ImageSource : IValueConverter
    {
       
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string cFotoBase64 = (string)value;

            if (cFotoBase64 == null)
                return null;

            // Convert cFotoBase64 from string to byte-array
            Byte[] ImageFotoBase64 = System.Convert.FromBase64String(cFotoBase64);

            // Return a new ImageSource
            return ImageSource.FromStream(() => { return new MemoryStream(ImageFotoBase64); });
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

       
    }
}
