using System;
using System.Collections.Generic;

namespace DungeonMasterHelper.ViewModels {
    public class CharacterGeneratorViewModel : BaseViewModel {

        private Random generator = new Random();
        private CharacterModel currentModel = new CharacterModel();
        private string[] abilityScoreStrings = new string[6];

        public MainViewModel Parent { get; set; }

        public CharacterGeneratorViewModel() {
            Name = "SomeNPCName";
            for (int i = 0; i < AbilityScores.Length; i++) {
                int sumScore = generator.Next(1,6) + generator.Next(1,6) + generator.Next(1,6);
                AbilityScores[i] = sumScore.ToString();
            }
            // Hack to update age, height, and weight fields.
            OnPropertyChanged("Gender");
        }

        #region Properties
        public string Name {
            get { return currentModel.Name; }
            set {
                currentModel.Name = value;
                OnPropertyChanged();
            }
        }

        public bool? Gender {
            get { return currentModel.Gender; }
            set {
                currentModel.Gender = value;
                OnPropertyChanged();
            }
        }

        public string Race {
            get { return currentModel.Race; }
            set {
                currentModel.Race = value;
                GenerateRandomAge();
                GenerateRandomHeightWeight();
                OnPropertyChanged();
            }
        }

        public string[] AbilityScores {
            get { return abilityScoreStrings; }
            set { 
                abilityScoreStrings = value;
                OnPropertyChanged();
            }
        }

        public string Alignment {
            get { return currentModel.Alignment; }
            set { 
                currentModel.Alignment = value;
                OnPropertyChanged();
            }
        }

        public string Age {
            get { return currentModel.Age.ToString(); }
            set {
                int newAge = 0;
                if (int.TryParse(value, out newAge)) {
                    currentModel.Age = newAge;
                    OnPropertyChanged("Age");
                }
            }
        }

        public string Height {
            get { return currentModel.Height.ToString(); }
            set {
                double newHeight = 0.0;
                if (double.TryParse(value, out newHeight)) {
                    currentModel.Height = newHeight;
                    OnPropertyChanged("Height");
                }
            }
        }

        public string Weight {
            get { return currentModel.Weight.ToString(); }
            set {
                double newWeight = 0.0;
                if (double.TryParse(value, out newWeight)) {
                    currentModel.Weight = newWeight;
                    OnPropertyChanged("Weight");
                }
            }
        }

        // Should probably be replaced with better solution.
        #region Combobox options
        public List<string> PossibleGenders {
            get { return new List<string>() { "Male", "Female", "None" }; }
        }

        public List<string> PossibleAlignments {
            get {
                return new List<string>() {
                    "Lawful Good", "Neutral Good", "Chaotic Good",
                    "Lawful Neutral", "True Neutral", "Chaotic Neutral",
                    "Lawful Evil", "Neutral Evil", "Chaotic Evil"
                };
            }
        }

        public List<string> PossibleRaces {
            get {
                return new List<string>() {
                    "Human", "Half-elf", "Dwarf", "Elf", "Halfling", "Gnome", "Half-orc"
                };
            }
        }
        #endregion
        #endregion

        public void Save() {
            SaveAbilityScores();
            Parent.AddNPC(currentModel);
        }

        private void SaveAbilityScores() {
            int[] tempScores = new int[6];

            for (int i = 0; i < abilityScoreStrings.Length; i++) {
                int newScore = 0;
                if (int.TryParse(abilityScoreStrings[i], out newScore))
                    tempScores[i] = newScore;
            }

            currentModel.AbilityScores = tempScores;
        }

        private void GenerateRandomAge() {
            string[] lifeSeasons = new string[0];
            if (!RaceAgeTable.TryGetValue(Race, out lifeSeasons)) lifeSeasons = new string[] { "15", "35", "53", "70", "70+2d20" };

            int adulthood = int.Parse(lifeSeasons[0]);
            int middleAge = int.Parse(lifeSeasons[1]);
            int randomFactor = generator.Next(0, middleAge - adulthood);
            Age = (adulthood + randomFactor).ToString(); ;
        }

        private void GenerateRandomHeightWeight() {
            string[] physique = new string[0];
            if (!RacePhysiqueTable.TryGetValue(Race, out physique)) physique = new string[] { "58", "120", "53", "85", "2d10", "5" };

            int baseHeight = int.Parse(physique[0]); // Measured in inches.
            int baseWeight = int.Parse(physique[1]); // Measured in lbs.
            int multiplier = int.Parse(physique[5]);
            int randomFactor = generator.Next(0, 20);

            Height = (baseHeight + randomFactor).ToString();
            Weight = (baseWeight + randomFactor * multiplier).ToString();
        }

        // Adulthood, Middle-age, Old, Venerable, Death
        private Dictionary<string, string[]> RaceAgeTable = new Dictionary<string, string[]>() {
            {"Human",       new string[] { "15", "35", "53", "70", "70+2d20" }},
            {"Half-elf",    new string[] { "20", "62", "93", "125", "125+3d20" }},
            {"Dwarf",       new string[] { "40", "125", "188", "250", "250+2d100" }},
            {"Elf",         new string[] { "110", "175", "263", "350", "350+4d100" }},
            {"Halfling",    new string[] { "20", "50", "75", "100", "100+5d20" }},
            {"Gnome",       new string[] { "40", "100", "150", "200", "200+3d100" }},
            {"Half-orc",    new string[] { "14", "30", "45", "60", "60+2d10" }}
        };

        // Height(Male), Weight(Male), Height(Female), Weight(Female), Modifer, Multiplier
        private Dictionary<string, string[]> RacePhysiqueTable = new Dictionary<string, string[]>() {
            {"Human",       new string[] { "58", "120", "53", "85", "2d10", "5" }},
            {"Half-elf",    new string[] { "62", "110", "60", "90", "2d8", "5" }},
            {"Dwarf",       new string[] { "45", "150", "43", "120", "2d4", "7" }},
            {"Elf",         new string[] { "64", "100", "64", "90", "2d6", "3" }},
            {"Halfling",    new string[] { "32", "30", "30", "25", "2d4", "1" }},
            {"Gnome",       new string[] { "36", "35", "34", "30", "2d4", "1" }},
            {"Half-orc",    new string[] { "58", "150", "53", "110", "2d12", "7" }}
        };
    }
}
