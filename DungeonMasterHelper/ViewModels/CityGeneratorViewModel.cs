using System;
using System.Collections.Generic;
using System.Linq;
using DungeonMasterHelper.Enums;

namespace DungeonMasterHelper.ViewModels {
    public class CityGeneratorViewModel : BaseViewModel {

        private CityModel currentModel = new CityModel();

        public MainViewModel Parent { get; set; }

        #region Properties
        public string CityName {
            get { return currentModel.Name; }
            set { 
                currentModel.Name = value;
                OnPropertyChanged();
            }
        }

        public string CityAlignment {
            get { return currentModel.Alignment; }
            set { 
                currentModel.Alignment = value;
                OnPropertyChanged();
            }
        }

        public string CityType {
            get { return currentModel.SettlementType; }
            set {
                currentModel.SettlementType = value;
                Population = GetRandomPopulation(currentModel.SettlementTypeEnum).ToString();
                OnPropertyChanged();
            }
        }

        public string Population {
            get { return currentModel.Population.ToString(); }
            set {
                uint newValue = 0;
                var success = UInt32.TryParse(value, out newValue);
                if (success) {
                    currentModel.Population = newValue;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        public CityGeneratorViewModel() {
            CityName = "SomeCityName";
        }

        public void Save() {
            Parent.AddCity(currentModel);
        }

        private uint GetRandomPopulation(SettlementType higherValue) {
            Random r = new Random();
            double u = r.NextDouble();

            int lowerValue = Enum.GetValues(typeof(SettlementType)).Cast<int>().Where(st => st < (int)higherValue).LastOrDefault();
            
            if (!lowerValue.Equals(SettlementType.Metropolis)) {
                return (uint)r.Next(lowerValue, (int)higherValue);
            } else {
                return (uint)r.NormalNext(100, lowerValue, (int)higherValue);
            }

        }

        // This should probably be removed eventually, such that 
        // settlement types are a direct translation of the used enums.
        #region UI Element Lists
        public List<string> PossibleAlignments {
            get {
                return new List<string>() {
                    "Lawful Good", "Neutral Good", "Chaotic Good",
                    "Lawful Neutral", "True Neutral", "Chaotic Neutral",
                    "Lawful Evil", "Neutral Evil", "Chaotic Evil"
                };
            }
        }

        public List<string> SettlementTypes {
            get {
                return new List<string>() {
                    "Thorpe", "Hamlet", "Village", "Small Town", 
                    "Large Town", "Small City", "Large City", "Metropolis" 
                };
            }
        }
        #endregion
    }

    public static class RandomExtender {
        public static int NormalNext(this Random rnd, int Steps, int MaxValue) {
            int count = 0;
            int val = 0;

            if (Steps < 1) return 0;

            while (++count * Steps <= MaxValue) val += rnd.Next(Steps);

            return val;
        }

        public static int NormalNext(this Random rnd, int Steps, int MinValue, int MaxValue) {
            int count = 0;
            int val = 0;
            int sampleSpace = MaxValue - MinValue;

            if (Steps < 1) return 0;
            while (++count * Steps <= sampleSpace) val += rnd.Next(Steps);

            return val;
        }
    }
}
