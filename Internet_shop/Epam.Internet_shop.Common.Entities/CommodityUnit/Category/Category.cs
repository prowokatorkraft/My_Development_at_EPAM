namespace Epam.Internet_shop.Common.Entities.CommodityUnit
{
    public class Category
    {
        public int? Id { get; }

        public string Name { get; set; }

        public Category(int? id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
