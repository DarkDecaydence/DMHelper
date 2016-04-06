using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMasterHelper.ViewModels.Fields {
    public struct AbilityScore {

        private string name;
        public string Name { get { return name; } }
        private int score;
        public int Score { get { return score; } }
        public int Modifier {
            get {
                if (Score >= 10) return (Score - 10) / 2;
                else return (int)Math.Floor((Score - 10) / 2.0);
            }
        }

        public AbilityScore(string name, int score) {
            this.name = name;
            this.score = score;
        }
    }
}
