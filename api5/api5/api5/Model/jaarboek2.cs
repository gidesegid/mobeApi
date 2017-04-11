using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api5.Model
{
 public   class jaarboek2
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int jaarboekId { get; set; }
        public int imageId { get; set; }
        // public string success { get { return "sucess"; } set { value = success; } }
        public string fileName { get; set; }
        public string Base64Image { get { return fileName; } set {value= Base64Image; } }
        //public string ImageUri { get { return ImageUri; } set { value = ImageUri; } }
        //public string myfile { get; set; }
    }
}
