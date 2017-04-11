using api5.Model;
using api5.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace api5.ViewModel
{
    class CviewModel
    {
        //contructor
        public CviewModel()
        {
            getAllData = new Command(RefreshData);
            RefreshData();
        }
        static jaarboek data = new jaarboek();
       // int id = data.id;
        string name =data.name;
        string description=data.description;
        //int jaarboekId=data.jaarboekId;
        //int imageId=data.imageId;
       // string fileName=data.fileName;
       
        public string Name
        {
            get {return name; }
            set {value=name; }
        }
        public string Description
        {
            get { return description; }
            set { value = description; }
        }
       /* public int JaarboekId
        {
            get { return jaarboekId; }
            set { value = jaarboekId; }
        }*/
       
       
        //inotifcation
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        //cmmands
        public Command getAllData { get; }
       //functions
        async void RefreshData()
        {
           
         // var items = await DataService.GetDataAsync();
           
            //var MainListView = items.OrderBy(item => item.name).ThenBy(item => item.description).ToList();
            /* jaarboek jaarboekdata = new jaarboek();*/

           
           
            
            
        }
    }
}
