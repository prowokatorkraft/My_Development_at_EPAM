using System.Collections.Generic;

namespace Epam.Internet_shop.Common.Entities.CommodityUnit
{
    public class VendorUnits : Vendor
    {
        public List<CommodityUnit> Units { get; }

        public VendorUnits(int? id, string name, List<CommodityUnit> units) : base(id, name)
        {
            Units = units;
        }
    }
}
