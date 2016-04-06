using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonMasterHelper.Enums;
using DungeonMasterHelper.Extensions;

namespace DungeonMasterHelper
{
    public class CityModel {
        #region Fields & Properties
        private string _cityName;
        private Alignment _alignment;
        private SettlementType _settlementType;
        private uint _population;
        // private NPC[] _notableNPCs;

        public string Name {
            get { return _cityName; }
            set { _cityName = value; }
        }

        public string Alignment {
            get { return _alignment.GetName(); }
            set {  _alignment = (Alignment)Enum.Parse(typeof(Alignment), value.Replace(" ", "")); }
        }
        public string SettlementType {
            get { return _settlementType.GetName(); }
            set { _settlementType = (SettlementType)Enum.Parse(typeof(SettlementType), value.Replace(" ", "")); }
        }

        public uint Population {
            get { return _population; }
            set { _population = value; }
        }

        public Alignment AlignmentEnum {
            get { return _alignment; }
        }

        public SettlementType SettlementTypeEnum {
            get { return _settlementType; }
        }
        #endregion
    }
}