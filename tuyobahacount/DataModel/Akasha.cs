using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tuyobahacount.DataModel
{

    [Serializable]
    public class Akasha
    {
        public int TotalCount { get; set; }
        public int BlueBox { get; set; }
        public int None { get; set; }
        public int Hollow_Key { get; set; }
        public int Champion_Merit { get; set; }
        public int Supreme_Merit { get; set; }
        public int Legendary_Merit { get; set; }
        public int Silver_Centrum { get; set; }
        public int Weapon_Plus_Mark1 { get; set; }
        public int Weapon_Plus_Mark2 { get; set; }
        public int Weapon_Plus_Mark3 { get; set; }
        public int Coronation_Ring { get; set; }
        public int Lineage_Ring { get; set; }
        public int Intricacy_Ring { get; set; }
        public int Gold_Brick { get; set; }
    }
}
