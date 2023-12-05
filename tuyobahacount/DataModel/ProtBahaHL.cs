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

        public ProtBahaHL Clone()
        {
            return new ProtBahaHL
            {
                TotalCount = this.TotalCount,
                BlueBox = this.BlueBox,
                None=this.None,
                Coronation_Ring = this.Coronation_Ring,
                Lineage_Ring = this.Lineage_Ring,
                Intricacy_Ring = this.Intricacy_Ring,
                Gold_Brick = this.Gold_Brick
            };
        }
    }

    
}
