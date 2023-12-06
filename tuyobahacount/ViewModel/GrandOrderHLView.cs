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
    public class GrandOrderHLView : ViewModelBase
    {
        private GrandOrderHL _grandOrderHL;
        private Stack<GrandOrderHL> _history = new Stack<GrandOrderHL>();
        private bool _lastActionWasGBCounter = false;

        public GrandOrderHL GrandOrderHL
        {


            get => _grandOrderHL;

            set
            {
                if (_grandOrderHL != value)
                {
                    _grandOrderHL = value;
                    OnPropertyChanged(nameof(Akasha));

                }

            }
        }



        public string DropRate
        {
            get
            {
                if (GrandOrderHL.TotalCount > 0)
                {
                    double DropRate = (double)GrandOrderHL.BlueBox / GrandOrderHL.TotalCount * 100;
                    return $" {DropRate:F2}%";
                }
                return "nodata";
            }
        }
        public string VADropRate
        {
            get
            {
                if (GrandOrderHL.BlueBox > 0)
                {
                    if (GrandOrderHL.Verdant_Azurite > 0)
                    {
                        double DropRate = (double)GrandOrderHL.Verdant_Azurite / GrandOrderHL.BlueBox * 100;
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
                if (GrandOrderHL.BlueBox > 0)
                {
                    if (GrandOrderHL.Champion_Merit > 0)
                    {
                        double DropRate = (double)GrandOrderHL.Champion_Merit / GrandOrderHL.BlueBox * 100;
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
                if (GrandOrderHL.BlueBox > 0)
                {
                    if (GrandOrderHL.Supreme_Merit > 0)
                    {
                        double DropRate = (double)GrandOrderHL.Supreme_Merit / GrandOrderHL.BlueBox * 100;
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
                if (GrandOrderHL.BlueBox > 0)
                {
                    if (GrandOrderHL.Legendary_Merit > 0)
                    {
                        double DropRate = (double)GrandOrderHL.Legendary_Merit / GrandOrderHL.BlueBox * 100;
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
                if (GrandOrderHL.BlueBox > 0)
                {
                    if (GrandOrderHL.Silver_Centrum > 0)
                    {
                        double DropRate = (double)GrandOrderHL.Silver_Centrum / GrandOrderHL.BlueBox * 100;
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
                if (GrandOrderHL.BlueBox > 0)
                {
                    if (GrandOrderHL.Coronation_Ring > 0)
                    {
                        double DropRate = (double)GrandOrderHL.Coronation_Ring / GrandOrderHL.BlueBox * 100;
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
                if (GrandOrderHL.BlueBox > 0)
                {
                    if (GrandOrderHL.Lineage_Ring > 0)
                    {
                        double DropRate = (double)GrandOrderHL.Lineage_Ring / GrandOrderHL.BlueBox * 100;
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
                if (GrandOrderHL.BlueBox > 0)
                {
                    if (GrandOrderHL.Intricacy_Ring > 0)
                    {
                        double DropRate = (double)GrandOrderHL.Intricacy_Ring / GrandOrderHL.BlueBox * 100;
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
                if (GrandOrderHL.BlueBox > 0)
                {
                    if (GrandOrderHL.Gold_Brick > 0)
                    {
                        double DropRate = (double)GrandOrderHL.Gold_Brick / GrandOrderHL.BlueBox * 100;
                        return $" {DropRate:F2}%";
                    }
                    else
                        return $" {0:F2}%";
                }

                return "nodata";
            }
        }
        public ICommand ICNoDrop { get; }
        public ICommand ICVADrop { get; }
        public ICommand ICCMDrop { get; }
        public ICommand ICSMDrop { get; }
        public ICommand ICLMDrop { get; }
        public ICommand ICSCDrop { get; }
        public ICommand ICCRDrop { get; }
        public ICommand ICLRDrop { get; }
        public ICommand ICIRDrop { get; }
        public ICommand ICGBDrop { get; }
        public ICommand ICResetCount { get; }
        public ICommand ICReturnCount { get; }

        public GrandOrderHLView()
        {
            GrandOrderHL = new GrandOrderHL();

            ICNoDrop = new RelayCommand(NoDropCounter);
            ICVADrop = new RelayCommand(VADropCounter);
            ICCMDrop = new RelayCommand(CMDropCounter);
            ICSMDrop = new RelayCommand(SMDropCounter);
            ICLMDrop = new RelayCommand(LMDropCounter);
            ICSCDrop = new RelayCommand(SCDropCounter);
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
            _history.Push(_grandOrderHL.Clone());
        }

        public void TotalCount()
        {
            GrandOrderHL.TotalCount++;

        }
        public void BlueBoxCount()
        {
            GrandOrderHL.BlueBox++;
            OnPropertyChanged(nameof(VADropRate));
            OnPropertyChanged(nameof(CMDropRate));
            OnPropertyChanged(nameof(SMDropRate));
            OnPropertyChanged(nameof(LMDropRate));
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
            GrandOrderHL.None++;
            OnPropertyChanged(nameof(GrandOrderHL));
            OnPropertyChanged(nameof(DropRate));
        }
        public void VADropCounter()
        {
            SaveCurrentState();
            TotalCount();
            GrandOrderHL.Verdant_Azurite++;
            BlueBoxCount();
            OnPropertyChanged(nameof(GrandOrderHL));

        }
        public void CMDropCounter()
        {
            SaveCurrentState();
            TotalCount();
            GrandOrderHL.Champion_Merit++;
            BlueBoxCount();
            OnPropertyChanged(nameof(GrandOrderHL));

        }
        public void SMDropCounter()
        {
            SaveCurrentState();
            TotalCount();
            GrandOrderHL.Supreme_Merit++;
            BlueBoxCount();
            OnPropertyChanged(nameof(GrandOrderHL));

        }
        public void LMDropCounter()
        {
            SaveCurrentState();
            TotalCount();
            GrandOrderHL.Legendary_Merit++;
            BlueBoxCount();
            OnPropertyChanged(nameof(GrandOrderHL));

        }
        public void SCDropCounter()
        {
            SaveCurrentState();
            TotalCount();
            GrandOrderHL.Silver_Centrum++;
            BlueBoxCount();
            OnPropertyChanged(nameof(GrandOrderHL));

        }
       
        public void CRDropCounter()
        {
            SaveCurrentState();
            TotalCount();
            GrandOrderHL.Coronation_Ring++;
            BlueBoxCount();
            OnPropertyChanged(nameof(GrandOrderHL));

        }
        public void LRDropCounter()
        {
            SaveCurrentState();
            TotalCount();
            GrandOrderHL.Lineage_Ring++;
            BlueBoxCount();
            OnPropertyChanged(nameof(GrandOrderHL));

        }
        public void IRDropCounter()
        {
            SaveCurrentState();
            TotalCount();
            GrandOrderHL.Intricacy_Ring++;
            BlueBoxCount();
            OnPropertyChanged(nameof(GrandOrderHL));

        }
        public void GBDropCounter()
        {
            SaveCurrentState();
            TotalCount();
            GrandOrderHL.Gold_Brick++;
            BlueBoxCount();
            OnPropertyChanged(nameof(GrandOrderHL));

        }

        public void ResetCount()
        {
            SaveCurrentState();
            GrandOrderHL = DataModelInit.GrandOrderinit();
            OnPropertyChanged(nameof(GrandOrderHL));
            OnPropertyChanged(nameof(VADropRate));
            OnPropertyChanged(nameof(CMDropRate));
            OnPropertyChanged(nameof(SMDropRate));
            OnPropertyChanged(nameof(LMDropRate));
            OnPropertyChanged(nameof(CRDropRate));
            OnPropertyChanged(nameof(LRDropRate));
            OnPropertyChanged(nameof(IRDropRate));
            OnPropertyChanged(nameof(GBDropRate));
            OnPropertyChanged(nameof(DropRate));

            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string csvData = $" {timestamp},グランデHL, {GrandOrderHL.TotalCount}, {GrandOrderHL.BlueBox}";
            IO.WriteToCsv("HIHIIROKANE.csv", csvData);
            _lastActionWasGBCounter = true;

        }
        public void ReturnCount()
        {
            if (_history.Count > 0)
            {
                GrandOrderHL = _history.Pop(); // 最後の状態に戻す
                OnPropertyChanged(nameof(GrandOrderHL));
                OnPropertyChanged(nameof(VADropRate));
                OnPropertyChanged(nameof(CMDropRate));
                OnPropertyChanged(nameof(SMDropRate));
                OnPropertyChanged(nameof(LMDropRate));
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
}
