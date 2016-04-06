using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonMasterHelper.ViewModels.Fields;

namespace DungeonMasterHelper.ViewModels {
    public class CharacterViewModel : BaseViewModel {
        public static CharacterViewModel EmptyCharacter {
            get {
                return new CharacterViewModel(
                    new CharacterModel() { Alignment = "Lawful Good", Name = "None", Race = "Human", AbilityScores = new int[] {0,0,0,0,0,0} }
                    );
            }
        }

        private CharacterModel model;

        public string Name { get { return model.Name; } }
        public string Gender { 
            get {
                if (model.Gender.HasValue)
                    return model.Gender.Value ? "Male" : "Female";
                else
                    return string.Empty;
            }
        }
        public string Alignment { get { return model.Alignment; } }
        public string Race { get { return model.Race; } }
        public int Age { get { return model.Age; } }
        public double Height { get { return model.Height; } }
        public double Weight { get { return model.Weight; } }

        private readonly List<string> abilityScoreNames = new List<string>() { "Strength:", "Dexterity:", "Constitution:", "Intelligence", "Wisdom", "Charisma" };
        private readonly List<AbilityScore> abilityScores = new List<AbilityScore>();
        public List<AbilityScore> AbilityScores {
            get { return abilityScores; }
        }

        public CharacterViewModel(CharacterModel model) {
            this.model = model;

            IEnumerator<string> nameEnumerator = abilityScoreNames.GetEnumerator();
            foreach (int i in model.AbilityScores) {
                nameEnumerator.MoveNext();
                AbilityScores.Add(new AbilityScore(nameEnumerator.Current, i));
            }
        }
    }
}
