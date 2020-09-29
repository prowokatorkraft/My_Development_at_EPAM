using System.Collections.Generic;

namespace Epam.Internet_shop.Common.Entities.CommodityUnit
{
    public class StatusUnits : Status
    {
        public List<CommodityUnit> Units { get; }

        public StatusUnits(int? id, string name, List<CommodityUnit> units) : base(id, name)
        {
            Units = units;
        }
    }
}
