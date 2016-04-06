using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonMasterHelper.Enums;
using DungeonMasterHelper.Extensions;

namespace DungeonMasterHelper {
    public class CharacterModel {
        #region Fields
        private string _npcName;
        private bool? _gender;
        private int[] _abilityScores;
        private Alignment _alignment;
        private Race _race;
        private int _age;
        private double _height;
        private double _weight;
        //ObservableCollection is in use until better separation is achieved.
        private readonly ObservableCollection<int> _abilityScores2 = new ObservableCollection<int>();
        #endregion

        #region Properties
        public string Name {
            get { return _npcName; }
            set { _npcName = value; }
        }

        public bool? Gender {
            get { return _gender; }
            set { _gender = value; }
        } 

        public string Race {
            get { return _race.GetName(); }
            set { _race = (Race)Enum.Parse(typeof(Race), value.Replace("-", "")); }
        }
        public string Alignment {
            get { return _alignment.GetName(); }
            set { _alignment = (Alignment)Enum.Parse(typeof(Alignment), value.Replace(" ", "")); }
        }

        public int[] AbilityScores {
            get { return _abilityScores; }
            set { _abilityScores = value; }
        }

        public int Age {
            get { return _age; }
            set { _age = value; }
        }

        public double Height {
            get { return _height; }
            set { _height = value; }
        }

        public double Weight {
            get { return _weight; }
            set { _weight = value; }
        }
        #endregion;
    }
}
