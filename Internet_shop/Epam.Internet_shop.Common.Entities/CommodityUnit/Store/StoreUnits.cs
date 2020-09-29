using System.Collections.Generic;

namespace Epam.Internet_shop.Common.Entities.CommodityUnit
{
    public class StoreUnits : Store
    {
        public List<CommodityUnit> Units { get; }

        public StoreUnits(int? id, string name, List<CommodityUnit> units) : base(id, name)
        {
            Units = units;
        }
    }
}
