using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonMasterHelper.ModelUtilities
{
    public class CityModel
    {
        private Alignment _alignment;
        private SettlementType _settlementType;
        private uint _population;
        // private NPC[] _notableNPCs;


    }

    public enum Alignment
    {
        LawfulGood, NeutralGood, ChaoticGood, 
        LawfulNeutral, TrueNeutral, ChaoticNeutral, 
        LawfulEvil, NeutralEvil, ChaoticEvil
    }

    public enum SettlementType
    {
        Thorpe, Hamlet, Village, SmallTown, LargeTown, SmallCity, LargeCity, Metropolis
    }
}
