﻿using System;
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

        public Akasha Clone()
        {

            return new Akasha
            {
                TotalCount = this.TotalCount,
                BlueBox = this.BlueBox,
                None = this.None,
                Hollow_Key = this.Hollow_Key,
                Champion_Merit = this.Champion_Merit,
                Supreme_Merit = this.Supreme_Merit,
                Legendary_Merit = this.Legendary_Merit,
                Silver_Centrum = this.Silver_Centrum,
                Weapon_Plus_Mark1 = this.Weapon_Plus_Mark1,
                Weapon_Plus_Mark2 = this.Weapon_Plus_Mark2,
                Weapon_Plus_Mark3 = this.Weapon_Plus_Mark3,
                Coronation_Ring = this.Coronation_Ring,
                Lineage_Ring = this.Lineage_Ring,
                Intricacy_Ring = this.Intricacy_Ring,
                Gold_Brick = this.Gold_Brick
            };
        }
    }
}
