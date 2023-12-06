using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace tuyobahacount.DataModel
{
    public class DataModelContainer


    {

        public ProtBahaHL ProtBahaHL { get; set; }
        public Akasha Akasha { get; set; }
        public GrandOrderHL GrandOrderHL { get; set; }

        public DataModelContainer()
        {
            ProtBahaHL = new ProtBahaHL();
            Akasha = new Akasha();
            GrandOrderHL = new GrandOrderHL();
        }
    }
}
