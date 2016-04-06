using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMasterHelper.Enums {
    public enum Alignment {
        LawfulGood, NeutralGood, ChaoticGood,
        LawfulNeutral, TrueNeutral, ChaoticNeutral,
        LawfulEvil, NeutralEvil, ChaoticEvil
    }
    public enum SettlementType {
        Thorpe = 21,
        Hamlet = 61,
        Village = 201,
        SmallTown = 2001,
        LargeTown = 5001,
        SmallCity = 10001,
        LargeCity = 25001,
        Metropolis = 160000
    }
}
