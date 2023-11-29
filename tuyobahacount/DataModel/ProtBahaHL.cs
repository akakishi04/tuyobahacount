using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tuyobahacount.DataModel
{
    [Serializable]
    public class ProtBahaHL
    {
        public int TotalCount { get; set; }
        public int BlueBox { get; set; }
        public int None { get; set; }
        public int Coronation_Ring { get; set; }
        public int Lineage_Ring { get; set; }
        public int Intricacy_Ring { get; set; }
        public int Gold_Brick { get; set; }
    }
}
