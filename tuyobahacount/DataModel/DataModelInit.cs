using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace tuyobahacount.DataModel
{
    public class DataModelInit
    {
        public static ProtBahaHL ProtBahainit()
        {
            ProtBahaHL protBahaHL = new ProtBahaHL();

            protBahaHL.TotalCount = 0;
            protBahaHL.None = 0;
            protBahaHL.BlueBox = 0;
            protBahaHL.Intricacy_Ring = 0;
            protBahaHL.Coronation_Ring = 0;
            protBahaHL.Lineage_Ring = 0;
            protBahaHL.Gold_Brick = 0;

            return protBahaHL;
        }

        public static Akasha Akashainit()
        {
            Akasha akasha = new Akasha();

            akasha.TotalCount = 0;
            akasha.BlueBox = 0;
            akasha.None = 0;
            akasha.Hollow_Key = 0;
            akasha.Champion_Merit = 0;
            akasha.Supreme_Merit = 0;
            akasha.Legendary_Merit = 0;
            akasha.Silver_Centrum = 0;
            akasha.Weapon_Plus_Mark1 = 0;
            akasha.Weapon_Plus_Mark2 = 0;
            akasha.Weapon_Plus_Mark3 = 0;
            akasha.Coronation_Ring = 0;
            akasha.Lineage_Ring = 0;
            akasha.Intricacy_Ring = 0;
            akasha.Gold_Brick = 0;

            return akasha;

        }
        public static GrandOrderHL GrandOrderinit()
        {
            GrandOrderHL grandorder = new GrandOrderHL();

            grandorder.TotalCount = 0;
            grandorder.BlueBox = 0;
            grandorder.None = 0;
            grandorder.Verdant_Azurite = 0;
            grandorder.Champion_Merit = 0;
            grandorder.Supreme_Merit = 0;
            grandorder.Legendary_Merit = 0;
            grandorder.Silver_Centrum = 0;
            grandorder.Coronation_Ring = 0;
            grandorder.Lineage_Ring = 0;
            grandorder.Intricacy_Ring = 0;
            grandorder.Gold_Brick = 0;

            return grandorder;

        }

    }
}
