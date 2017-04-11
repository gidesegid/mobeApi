using api5.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace api5.Service
{
    class DataService
    {
        string url = "http://192.168.1.101:3000";
        HttpClient Client = new HttpClient();
        //get
        public  async Task<List<jaarboek>> GetDataAsync()
        {
           // HttpClient Client = new HttpClient();
            var getAllDataUrl = $"{url}/getAllData";
            var response = await Client.GetStringAsync(getAllDataUrl);
            var data = JsonConvert.DeserializeObject<List<jaarboek>>(response);
            return data;
        }
        public async Task<List<jaarboek>> getDataByName(string myname)
        {
            var geturl = $"{url}/getUsers/{myname}";
            var response = await Client.GetStringAsync(geturl);
            var data = JsonConvert.DeserializeObject<List<jaarboek>>(response);
            return data;
        }
      
        //post..insert
        public  async Task<jaarboek> AddDataAsync(jaarboek field)
        {
            var name = field.name;
            var description = field.description;
            var jaarboekId = field.jaarboekId;
            var imageId = field.imageId;
            var posturl = $"{url}/insert2/{name}/{description}/{jaarboekId}/{imageId}";
            var data = JsonConvert.SerializeObject(field);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync(posturl, content);
            var x = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<jaarboek>(x);
            return result;
        }
       
        //put..update
        public async Task<jaarboek> UpdateDataAsync(jaarboek dataToUpdate)
        {
            var id = dataToUpdate.id;
            var name = dataToUpdate.name;
            var description = dataToUpdate.description;
            var jaarboekId = dataToUpdate.jaarboekId;
            var updateurl = $"{url}/update/{id}/{name}/{description}/{jaarboekId}";
            var data = JsonConvert.SerializeObject(dataToUpdate);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await Client.PutAsync(string.Concat(updateurl, data), content);
            return JsonConvert.DeserializeObject<jaarboek>(response.Content.ReadAsStringAsync().Result);
        }
        //delete..delete
        public async Task DeleteDataAsync(jaarboek myId)
        {
            var id = myId.id;
            var deleteUrl = $"{url}/delete/{id}";
            await Client.DeleteAsync(string.Concat(deleteUrl, myId+"4"));
        }
        public async Task<jaarboek> postImage(jaarboek jaarboekData)
        {
            var name = jaarboekData.name;
            var description = jaarboekData.description;
            var jaarboekId = jaarboekData.jaarboekId;
            var imageId = jaarboekData.imageId;
            var myfile = jaarboekData.myfile;
            var postImageDataUrl = $"{url}/postinfo/";
            var data = JsonConvert.SerializeObject(jaarboekData);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync(postImageDataUrl, content);
            var x = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<jaarboek>(x);
            return result;
        }
    }
}
