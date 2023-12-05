using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using tuyobahacount.DataModel;

namespace tuyobahacount.ViewModel
{
    public class ProBahaHLView: ViewModelBase
    {

        private ProtBahaHL _protBahaHL;
        private Stack<ProtBahaHL> _history = new Stack<ProtBahaHL>();

        public ProtBahaHL ProtBaha
        {
            get => _protBahaHL;
            set
            {
                if (_protBahaHL != value)
                {
                    _protBahaHL = value;
                    OnPropertyChanged(nameof(ProtBaha));

                }

            }

        }

        public string DropRate
        {
            get
            {
                if (ProtBaha.TotalCount > 0)
                {
                    double DropRate = (double)ProtBaha.BlueBox / ProtBaha.TotalCount * 100;
                    return $" {DropRate:F2}%";
                }
                return "nodata";
            }
        }
        public string CRDropRate
        {
            get
            {
                if (ProtBaha.BlueBox > 0)
                {
                    if (ProtBaha.Coronation_Ring > 0)
                    {
                        double DropRate = (double)ProtBaha.Coronation_Ring / ProtBaha.BlueBox * 100;
                        return $" {DropRate:F2}%";
                    }else 
                        return $" {0:F2}%";
                }

                return "nodata";
            }
        }
        public string LRDropRate
        {
            get
            {
                if (ProtBaha.BlueBox > 0)
                {
                    if (ProtBaha.Lineage_Ring > 0)
                    {
                        double DropRate = (double)ProtBaha.Lineage_Ring / ProtBaha.BlueBox * 100;
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
                if (ProtBaha.BlueBox > 0)
                {
                    if (ProtBaha.Intricacy_Ring > 0)
                    {
                        double DropRate = (double)ProtBaha.Intricacy_Ring / ProtBaha.BlueBox * 100;
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
                if (ProtBaha.BlueBox > 0)
                {
                    if (ProtBaha.Gold_Brick > 0)
                    {
                        double DropRate = (double)ProtBaha.Gold_Brick / ProtBaha.BlueBox * 100;
                        return $" {DropRate:F2}%";
                    }
                    else
                        return $" {0:F2}%";
                }

                return "nodata";
            }
        }


        public ProBahaHLView()
        {

            ProtBaha = new ProtBahaHL();
            ICNoDrop = new RelayCommand(NoDropCounter);
            ICCRCounter = new RelayCommand(CRCounter);
            ICLRCounter = new RelayCommand(LRCounter);
            ICIRCounter = new RelayCommand(IRCounter);
            ICGBCounter = new RelayCommand(GBCounter);
            ICResetCount = new RelayCommand(ResetCount);
            ICReturnCount = new RelayCommand(ReturnCount);

        }

        public ICommand ICNoDrop { get; }
        public ICommand ICCRCounter { get; }
        public ICommand ICLRCounter { get; }
        public ICommand ICIRCounter { get; }
        public ICommand ICGBCounter { get; }
        public ICommand ICResetCount { get; }
        public ICommand ICReturnCount { get; }

        private void SaveCurrentState()
        {
            // 現在の状態をコピーしてスタックに保存
            _history.Push(_protBahaHL.Clone());
        }

        public void TotalCount()
        {
            ProtBaha.TotalCount++;

        }
        public void BlueBoxCount()
        {
            ProtBaha.BlueBox++;

        }

        public void NoDropCounter()
        {
            SaveCurrentState();
            TotalCount();
            ProtBaha.None++;
            OnPropertyChanged(nameof(ProtBaha));
            OnPropertyChanged(nameof(DropRate));
           
        }
        public void CRCounter()
        {
            SaveCurrentState();
            ProtBaha.Coronation_Ring++;
            TotalCount();
            BlueBoxCount();
            OnPropertyChanged(nameof(ProtBaha));
            OnPropertyChanged(nameof(DropRate));
            OnPropertyChanged(nameof(CRDropRate));
            OnPropertyChanged(nameof(LRDropRate));
            OnPropertyChanged(nameof(IRDropRate));
            OnPropertyChanged(nameof(GBDropRate));
           
        }
        public void LRCounter()
        {
            SaveCurrentState();
            ProtBaha.Lineage_Ring++;
            TotalCount();
            BlueBoxCount();
            OnPropertyChanged(nameof(ProtBaha));
            OnPropertyChanged(nameof(DropRate));
            OnPropertyChanged(nameof(CRDropRate));
            OnPropertyChanged(nameof(LRDropRate));
            OnPropertyChanged(nameof(IRDropRate));
            OnPropertyChanged(nameof(GBDropRate));
            

        }
        public void IRCounter()
        {

            SaveCurrentState();
            ProtBaha.Intricacy_Ring++;
            TotalCount();
            BlueBoxCount();
            OnPropertyChanged(nameof(ProtBaha));
            OnPropertyChanged(nameof(DropRate));
            OnPropertyChanged(nameof(CRDropRate));
            OnPropertyChanged(nameof(LRDropRate));
            OnPropertyChanged(nameof(IRDropRate));
            OnPropertyChanged(nameof(GBDropRate));


        }
        public void GBCounter()
        {
            SaveCurrentState();
            ProtBaha.Gold_Brick++;
            TotalCount();
            BlueBoxCount();
            OnPropertyChanged(nameof(ProtBaha));
            OnPropertyChanged(nameof(DropRate));
            OnPropertyChanged(nameof(CRDropRate));
            OnPropertyChanged(nameof(LRDropRate));
            OnPropertyChanged(nameof(IRDropRate));
            OnPropertyChanged(nameof(GBDropRate));
           

        }

        public void ResetCount()
        {
            SaveCurrentState();
            ProtBaha = DataModelInit.ProtBahainit();
            OnPropertyChanged(nameof(ProtBaha));
            OnPropertyChanged(nameof(DropRate));
            OnPropertyChanged(nameof(CRDropRate));
            OnPropertyChanged(nameof(LRDropRate));
            OnPropertyChanged(nameof(IRDropRate));
            OnPropertyChanged(nameof(GBDropRate));
            

        }
        public void ReturnCount()
        {
            if (_history.Count > 0)
            {
                ProtBaha = _history.Pop(); // 最後の状態に戻す
                OnPropertyChanged(nameof(ProtBaha));
                OnPropertyChanged(nameof(DropRate));
                OnPropertyChanged(nameof(CRDropRate));
                OnPropertyChanged(nameof(LRDropRate));
                OnPropertyChanged(nameof(IRDropRate));
                OnPropertyChanged(nameof(GBDropRate));
                // その他のプロパティの更新
            }
        }

    }
}
