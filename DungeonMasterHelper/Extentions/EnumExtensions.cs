using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonMasterHelper.Enums;

namespace DungeonMasterHelper.Extensions {
    public static class EnumMethods {
        public static string GetName(this Alignment a) {
            switch (a) {
                case Alignment.LawfulGood: return "Lawful Good";
                case Alignment.LawfulNeutral: return "Lawful Neutral";
                case Alignment.LawfulEvil: return "Lawful Evil";
                case Alignment.NeutralGood: return "Neutral Good";
                case Alignment.TrueNeutral: return "True Neutral";
                case Alignment.NeutralEvil: return "Neutral Evil";
                case Alignment.ChaoticGood: return "Chaotic Good";
                case Alignment.ChaoticNeutral: return "Chaotic Neutral";
                case Alignment.ChaoticEvil: return "Chaotic Evil";
                default: return "Undefined";
            }
        }

        public static string GetName(this SettlementType s) {
            switch (s) {
                case SettlementType.Thorpe: return "Thorpe";
                case SettlementType.Hamlet: return "Hamlet";
                case SettlementType.Village: return "Village";
                case SettlementType.SmallTown: return "Small Town";
                case SettlementType.LargeTown: return "Large Town";
                case SettlementType.SmallCity: return "Small City";
                case SettlementType.LargeCity: return "Large City";
                case SettlementType.Metropolis: return "Metropolis";
                default: return "Undefined";
            }
        }

        public static string GetName(this Race r) {
            switch (r) {
                case Race.Human: return "Human";
                case Race.Dwarf: return "Dwarf";
                case Race.Elf: return "Elf";
                case Race.Gnome: return "Gnome";
                case Race.Halfelf: return "Half-elf";
                case Race.Halforc: return "Half-orc";
                case Race.Halfling: return "Halfling";
                default: return "Undefined";
            }
        }
    }
}
