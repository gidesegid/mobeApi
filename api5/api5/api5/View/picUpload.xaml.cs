using System;
using Plugin.Media;
using Xamarin.Forms;
using System.Net.Http;
using api5.Service;
using api5.Model;

namespace api5.View
{
    public partial class picUpload : ContentPage
    {
        Plugin.Media.Abstractions.MediaFile streamfile;
        public picUpload()
        {
            InitializeComponent();

           
           takePhoto.Clicked += async (sender, args) =>
            {

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    Directory = "Sample",
                    Name = "test.jpg"
                });

                if (file == null)
                    return;

                await DisplayAlert("File Location", file.Path, "OK");
                directoryLocation.Text = file.Path;
                image.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
            };

            pickPhoto.Clicked += async (sender, args) =>
            {
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                    return;
                }
                var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                });


                if (file == null)
                    return;

                streamfile = file;
                directoryLocation.Text = file.Path;
                image.Source = ImageSource.FromStream(() =>
                {
                   var stream = file.GetStream();
                   // file.Dispose();
                   return stream;
                });
                //var content = new MultipartFormDataContent();
                //content.Add(new StreamContent(streamfile.GetStream()),
                //     "\"file\"",
                //     $"\"{streamfile.Path}\"");
                //var httpClient = new HttpClient();
                //var uploadServiceBaseAddress = "http//192.168.1.101:3000/upload/images";
                //var httpResponseMessage = await httpClient.PostAsync(uploadServiceBaseAddress, content);
                //RemotePathLabel.Text = await httpResponseMessage.Content.ReadAsStringAsync();
            };

            takeVideo.Clicked += async (sender, args) =>
            {
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakeVideoSupported)
                {
                   await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakeVideoAsync(new Plugin.Media.Abstractions.StoreVideoOptions
                {
                    Name = "video.mp4",
                    Directory = "DefaultVideos",
                });

                if (file == null)
                    return;

                await DisplayAlert("Video Recorded", "Location: " + file.Path, "OK");
                directoryLocation.Text = file.Path;
                file.Dispose();
            };

            pickVideo.Clicked += async (sender, args) =>
            {
                if (!CrossMedia.Current.IsPickVideoSupported)
                {
                    await DisplayAlert("Videos Not Supported", ":( Permission not granted to videos.", "OK");
                    return;
                }
                var file = await CrossMedia.Current.PickVideoAsync();

                if (file == null)
                    return;

                await DisplayAlert("Video Selected", "Location: " + file.Path, "OK");
                directoryLocation.Text = file.Path;
                file.Dispose();
            };
        }
        private async void UploadFile_Clicked(object sender, EventArgs e)
        {
            DataService myDataService = new DataService();
            var content = new MultipartFormDataContent();
             content.Add(new StreamContent(streamfile.GetStream()),
                  "\"file\"",
                  $"\"{directoryLocation.Text}\"");
            
            jaarboek jaarboekData = new jaarboek
            {
             name=name.Text,
             description=description.Text,
             jaarboekId= Convert.ToInt32(jaarboekId.Text),
             imageId=Convert.ToInt32(imageId.Text),
             myfile= Convert.ToString(content)
            };
            await myDataService.postImage(jaarboekData);
              //var httpClient = new HttpClient();
              //var uploadServiceBaseAddress = "http://192.168.1.101:3000/postinfo/";
              //var httpResponseMessage = await httpClient.PostAsync(uploadServiceBaseAddress, content);
              //RemotePathLabel.Text = await httpResponseMessage.Content.ReadAsStringAsync();

        }
    }
}
