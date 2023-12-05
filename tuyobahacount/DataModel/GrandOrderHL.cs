using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tuyobahacount.DataModel
{
    public class GrandOrderHL
    {
        public int TotalCount { get; set; }
        public int BlueBox { get; set; }
        public int None { get; set; }
        public int Verdant_Azurite { get; set; }
        public int Champion_Merit { get; set; }
        public int Supreme_Merit { get; set; }
        public int Legendary_Merit { get; set; }
        public int Silver_Centrum { get; set; }
        public int Coronation_Ring { get; set; }
        public int Lineage_Ring { get; set; }
        public int Intricacy_Ring { get; set; }
        public int Gold_Brick { get; set; }

        public GrandOrderHL Clone()
        {

            return new GrandOrderHL
            {
                TotalCount = this.TotalCount,
                BlueBox = this.BlueBox,
                None = this.None,
                Verdant_Azurite = this.Verdant_Azurite,
                Champion_Merit = this.Champion_Merit,
                Supreme_Merit = this.Supreme_Merit,
                Legendary_Merit = this.Legendary_Merit,
                Silver_Centrum = this.Silver_Centrum,
                Coronation_Ring = this.Coronation_Ring,
                Lineage_Ring = this.Lineage_Ring,
                Intricacy_Ring = this.Intricacy_Ring,
                Gold_Brick = this.Gold_Brick,

            };

        }

    }
}
