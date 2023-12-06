using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using tuyobahacount.DataModel;
using tuyobahacount.UserControl;

namespace tuyobahacount.ViewModel
{
    internal class AkashaView : ViewModelBase
    {


        private Akasha _akasha;
        private Stack<Akasha> _history = new Stack<Akasha>();
        private bool _lastActionWasGBCounter = false;

        public Akasha Akasha
        {
            get => _akasha;

            set
            {
                if (_akasha != value)
                {
                    _akasha = value;
                    OnPropertyChanged(nameof(Akasha));

                }

            }

        }
        public string DropRate
        {
            get
            {
                if (Akasha.TotalCount > 0)
                {
                    double DropRate = (double)Akasha.BlueBox / Akasha.TotalCount * 100;
                    return $" {DropRate:F2}%";
                }
                return "nodata";
            }
        }
        public string HKDropRate
        {
            get
            {
                if (Akasha.BlueBox > 0)
                {
                    if (Akasha.Hollow_Key > 0)
                    {
                        double DropRate = (double)Akasha.Hollow_Key / Akasha.BlueBox * 100;
                        return $" {DropRate:F2}%";
                    }
                    else
                        return $" {0:F2}%";
                }

                return "nodata";
            }
        }
        public string CMDropRate
        {
            get
            {
                if (Akasha.BlueBox > 0)
                {
                    if (Akasha.Champion_Merit > 0)
                    {
                        double DropRate = (double)Akasha.Champion_Merit / Akasha.BlueBox * 100;
                        return $" {DropRate:F2}%";
                    }
                    else
                        return $" {0:F2}%";
                }

                return "nodata";
            }
        }
        public string SMDropRate
        {
            get
            {
                if (Akasha.BlueBox > 0)
                {
                    if (Akasha.Supreme_Merit > 0)
                    {
                        double DropRate = (double)Akasha.Supreme_Merit / Akasha.BlueBox * 100;
                        return $" {DropRate:F2}%";
                    }
                    else
                        return $" {0:F2}%";
                }

                return "nodata";
            }
        }
        public string LMDropRate
        {
            get
            {
                if (Akasha.BlueBox > 0)
                {
                    if (Akasha.Legendary_Merit > 0)
                    {
                        double DropRate = (double)Akasha.Legendary_Merit / Akasha.BlueBox * 100;
                        return $" {DropRate:F2}%";
                    }
                    else
                        return $" {0:F2}%";
                }

                return "nodata";
            }
        }
        public string SCDropRate 
        {
        
            get
            {
                if (Akasha.BlueBox > 0)
                {
                    if (Akasha.Silver_Centrum > 0)
                    {
                        double DropRate = (double)Akasha.Silver_Centrum / Akasha.BlueBox * 100;
                        return $" {DropRate:F2}%";
                    }
                    else
                        return $" {0:F2}%";
                }

                return "nodata";
            }
        }
        public string WPM1DropRate
        {
            get
            {
                if (Akasha.BlueBox > 0)
                {
                    if (Akasha.Weapon_Plus_Mark1 > 0)
                    {
                        double DropRate = (double)Akasha.Weapon_Plus_Mark1 / Akasha.BlueBox * 100;
                        return $" {DropRate:F2}%";
                    }
                    else
                        return $" {0:F2}%";
                }

                return "nodata";
            }
        }
        public string WPM2DropRate
        {
            get
            {
                if (Akasha.BlueBox > 0)
                {
                    if (Akasha.Weapon_Plus_Mark2 > 0)
                    {
                        double DropRate = (double)Akasha.Weapon_Plus_Mark2 / Akasha.BlueBox * 100;
                        return $" {DropRate:F2}%";
                    }
                    else
                        return $" {0:F2}%";
                }

                return "nodata";
            }
        }
        public string WPM3DropRate
        {
            get
            {
                if (Akasha.BlueBox > 0)
                {
                    if (Akasha.Weapon_Plus_Mark3 > 0)
                    {
                        double DropRate = (double)Akasha.Weapon_Plus_Mark3 / Akasha.BlueBox * 100;
                        return $" {DropRate:F2}%";
                    }
                    else
                        return $" {0:F2}%";
                }

                return "nodata";
            }
        }
        public string CRDropRate
        {
            get
            {
                if (Akasha.BlueBox > 0)
                {
                    if (Akasha.Coronation_Ring > 0)
                    {
                        double DropRate = (double)Akasha.Coronation_Ring / Akasha.BlueBox * 100;
                        return $" {DropRate:F2}%";
                    }
                    else
                        return $" {0:F2}%";
                }

                return "nodata";
            }
        }
        public string LRDropRate
        {
            get
            {
                if (Akasha.BlueBox > 0)
                {
                    if (Akasha.Lineage_Ring > 0)
                    {
                        double DropRate = (double)Akasha.Lineage_Ring / Akasha.BlueBox * 100;
                        return $" {DropRate:F2}%";
                    }
                    else
                        return $" {0:F2}%";
                }

                return "nodata";
            }
        }
        public string IRDropRate
        {
            get
            {
                if (Akasha.BlueBox > 0)
                {
                    if (Akasha.Intricacy_Ring > 0)
                    {
                        double DropRate = (double)Akasha.Intricacy_Ring / Akasha.BlueBox * 100;
                        return $" {DropRate:F2}%";
                    }
                    else
                        return $" {0:F2}%";
                }

                return "nodata";
            }
        }
        public string GBDropRate
        {
            get
            {
                if (Akasha.BlueBox > 0)
                {
                    if (Akasha.Gold_Brick > 0)
                    {
                        double DropRate = (double)Akasha.Gold_Brick / Akasha.BlueBox * 100;
                        return $" {DropRate:F2}%";
                    }
                    else
                        return $" {0:F2}%";
                }

                return "nodata";
            }
        }

        public ICommand ICNoDrop { get; }
        public ICommand ICHKDrop { get; }
        public ICommand ICCMDrop { get; }
        public ICommand ICSMDrop { get; }
        public ICommand ICLMDrop { get; }
        public ICommand ICSCDrop { get; }
        public ICommand ICWPM1Drop { get; }
        public ICommand ICWPM2Drop { get; }
        public ICommand ICWPM3Drop { get; }
        public ICommand ICCRDrop { get; }
        public ICommand ICLRDrop { get; }
        public ICommand ICIRDrop { get; }
        public ICommand ICGBDrop { get; }
        public ICommand ICResetCount { get; }
        public ICommand ICReturnCount { get; }

        public AkashaView()
        {
            Akasha = new Akasha();

            ICNoDrop = new RelayCommand(NoDropCounter);
            ICHKDrop = new RelayCommand(HKDropCounter);
            ICCMDrop = new RelayCommand(CMDropCounter);
            ICSMDrop = new RelayCommand(SMDropCounter);
            ICLMDrop = new RelayCommand(LMDropCounter);
            ICSCDrop = new RelayCommand(SCDropCounter);
            ICWPM1Drop = new RelayCommand(WPM1DropCounter);
            ICWPM2Drop = new RelayCommand(WPM2DropCounter);
            ICWPM3Drop = new RelayCommand(WPM3DropCounter);
            ICCRDrop = new RelayCommand(CRDropCounter);
            ICLRDrop = new RelayCommand(LRDropCounter);
            ICIRDrop = new RelayCommand(IRDropCounter);
            ICGBDrop = new RelayCommand(GBDropCounter);
            ICResetCount = new RelayCommand(ResetCount);
            ICReturnCount = new RelayCommand(ReturnCount);

        }
        private void SaveCurrentState()
        {
            // 現在の状態をコピーしてスタックに保存
            _history.Push(_akasha.Clone());
        }

        public void TotalCount()
        {
            Akasha.TotalCount++;

        }
        public void BlueBoxCount()
        {
            Akasha.BlueBox++;
            OnPropertyChanged(nameof(HKDropRate));
            OnPropertyChanged(nameof(CMDropRate));
            OnPropertyChanged(nameof(SMDropRate));
            OnPropertyChanged(nameof(LMDropRate));
            OnPropertyChanged(nameof(WPM1DropRate));
            OnPropertyChanged(nameof(WPM2DropRate));
            OnPropertyChanged(nameof(WPM3DropRate));
            OnPropertyChanged(nameof(CRDropRate));
            OnPropertyChanged(nameof(LRDropRate));
            OnPropertyChanged(nameof(IRDropRate));
            OnPropertyChanged(nameof(GBDropRate));
            OnPropertyChanged(nameof(DropRate));
        }

        public void NoDropCounter()
        {
            SaveCurrentState();
            TotalCount();
            Akasha.None++;
            OnPropertyChanged(nameof(Akasha));
            OnPropertyChanged(nameof(DropRate));
        }
        public void HKDropCounter()
        {
            SaveCurrentState();
            TotalCount();
            Akasha.Hollow_Key++;
            BlueBoxCount();
            OnPropertyChanged(nameof(Akasha));
            
        }
        public void CMDropCounter()
        {
            SaveCurrentState();
            TotalCount();
            Akasha.Champion_Merit++;
            BlueBoxCount();
            OnPropertyChanged(nameof(Akasha));

        }
        public void SMDropCounter()
        {
            SaveCurrentState();
            TotalCount();
            Akasha.Supreme_Merit++;
            BlueBoxCount();
            OnPropertyChanged(nameof(Akasha));

        }
        public void LMDropCounter()
        {
            SaveCurrentState();
            TotalCount();
            Akasha.Legendary_Merit++;
            BlueBoxCount();
            OnPropertyChanged(nameof(Akasha));

        }
        public void SCDropCounter()
        {
            SaveCurrentState();
            TotalCount();
            Akasha.Silver_Centrum++;
            BlueBoxCount();
            OnPropertyChanged(nameof(Akasha));

        }
        public void WPM1DropCounter()
        {
            SaveCurrentState();
            TotalCount();
            Akasha.Weapon_Plus_Mark1++;
            BlueBoxCount();
            OnPropertyChanged(nameof(Akasha));

        }
        public void WPM2DropCounter()
        {
            SaveCurrentState();
            TotalCount();
            Akasha.Weapon_Plus_Mark2++;
            BlueBoxCount();
            OnPropertyChanged(nameof(Akasha));

        }
        public void WPM3DropCounter()
        {
            SaveCurrentState();
            TotalCount();
            Akasha.Weapon_Plus_Mark3++;
            BlueBoxCount();
            OnPropertyChanged(nameof(Akasha));

        }
        public void CRDropCounter()
        {
            SaveCurrentState();
            TotalCount();
            Akasha.Coronation_Ring++;
            BlueBoxCount();
            OnPropertyChanged(nameof(Akasha));

        }
        public void LRDropCounter()
        {
            SaveCurrentState();
            TotalCount();
            Akasha.Lineage_Ring++;
            BlueBoxCount();
            OnPropertyChanged(nameof(Akasha));

        }
        public void IRDropCounter()
        {
            SaveCurrentState();
            TotalCount();
            Akasha.Intricacy_Ring++;
            BlueBoxCount();
            OnPropertyChanged(nameof(Akasha));

        }
        public void GBDropCounter()
        {
            SaveCurrentState();
            TotalCount();
            Akasha.Gold_Brick++;
            BlueBoxCount();
            OnPropertyChanged(nameof(Akasha));
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string csvData = $" {timestamp},アーカーシャ, {Akasha.TotalCount}, {Akasha.BlueBox}";
            IO.WriteToCsv("HIHIIROKANE.csv", csvData);
            _lastActionWasGBCounter = true;

        }

        public void ResetCount()
        {
            SaveCurrentState();
            Akasha = DataModelInit.Akashainit();
            OnPropertyChanged(nameof(Akasha));
            OnPropertyChanged(nameof(HKDropRate));
            OnPropertyChanged(nameof(CMDropRate));
            OnPropertyChanged(nameof(SMDropRate));
            OnPropertyChanged(nameof(LMDropRate));
            OnPropertyChanged(nameof(WPM1DropRate));
            OnPropertyChanged(nameof(WPM2DropRate));
            OnPropertyChanged(nameof(WPM3DropRate));
            OnPropertyChanged(nameof(CRDropRate));
            OnPropertyChanged(nameof(LRDropRate));
            OnPropertyChanged(nameof(IRDropRate));
            OnPropertyChanged(nameof(GBDropRate));
            OnPropertyChanged(nameof(DropRate));


        }
        public void ReturnCount()
        {
            if (_history.Count > 0)
            {
                Akasha = _history.Pop(); // 最後の状態に戻す
                OnPropertyChanged(nameof(Akasha));
                OnPropertyChanged(nameof(HKDropRate));
                OnPropertyChanged(nameof(CMDropRate));
                OnPropertyChanged(nameof(SMDropRate));
                OnPropertyChanged(nameof(LMDropRate));
                OnPropertyChanged(nameof(WPM1DropRate));
                OnPropertyChanged(nameof(WPM2DropRate));
                OnPropertyChanged(nameof(WPM3DropRate));
                OnPropertyChanged(nameof(CRDropRate));
                OnPropertyChanged(nameof(LRDropRate));
                OnPropertyChanged(nameof(IRDropRate));
                OnPropertyChanged(nameof(GBDropRate));
                OnPropertyChanged(nameof(DropRate));
                // その他のプロパティの更新
                if (_lastActionWasGBCounter)
                {
                    // GBCounterが最後に呼ばれていた場合、CSVの最終行を削除
                    IO.RemoveLastLine("GBCounterLog.csv");
                }

                _lastActionWasGBCounter = false; // フラグをリセット
            }
        }

    }

 }

