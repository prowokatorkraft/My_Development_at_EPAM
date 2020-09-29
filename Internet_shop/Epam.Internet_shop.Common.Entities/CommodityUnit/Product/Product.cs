namespace Epam.Internet_shop.Common.Entities.CommodityUnit
{
    public class Product
    {
        public int? Id { get; }

        public string Name { get; set; }

        public byte[] Image { get; set; }

        public string Discription { get; set; }

        public Category Category { get; set; }

        public Product(int? id, string name, byte[] image, string discription, Category category)
        {
            Id = id;
            Name = name;
            Image = image;
            Discription = discription;
            Category = category;
        }
    }
}
