using api5.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace api5.Service
{
  public  class dataservice2
    {
        Public async Task loadDeveloperList()
        {
            try
            {
                List<jaarboek2> employeeDetail = new List<jaarboek2>();

                HttpClient client = new HttpClient();
                StringBuilder sb = new StringBuilder();
                client.MaxResponseContentBufferSize = 256000;
                var RestUrl = "http://192.168.1.101:3000/getAllData";
                var uri = new Uri(RestUrl);
               // actIndicator.IsVisible = true;
               // actIndicator.IsRunning = true;
                var response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    List<jaarboek2> onjEmployee = JsonConvert.DeserializeObject<List<jaarboek2>>(content);

                    foreach (var item in onjEmployee)
                    {
                        jaarboek2 emptemp = new jaarboek2()
                        {
                            name = item.name,
                            description = item.description,
                            jaarboekId = item.jaarboekId,
                            imageId = item.imageId,
                            Base64Image = item.Base64Image
                        };
                        string cFotoBase64 = emptemp.Base64Image;
                        byte[] ImageFotoBase64 = System.Convert.FromBase64String(cFotoBase64);

                        employeeDetail.Add(emptemp);
                    }
                    listView.ItemsSource = employeeDetail;
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}
