using System.Collections.Generic;

namespace Epam.Internet_shop.Common.Entities.CommodityUnit
{
    public class ProductUnits : Product
    {
        public List<CommodityUnit> Units { get; }

        public ProductUnits(int? id, string name, byte[] image, string discription, Category category, List<CommodityUnit> units) 
                     : base(id, name, image, discription, category)
        {
            Units = units;
        }
    }
}
