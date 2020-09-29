using System.Collections.Generic;

namespace Epam.Internet_shop.Common.Entities.CommodityUnit
{
    public class CategoryUnits : Category
    {
        public List<CommodityUnit> Units { get; }

        public CategoryUnits(int? id, string name, List<CommodityUnit> units) : base(id, name)
        {
            Units = units;
        }
    }
}
