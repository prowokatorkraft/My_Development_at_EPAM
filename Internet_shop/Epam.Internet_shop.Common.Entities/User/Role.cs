namespace Epam.Internet_shop.Common.Entities.User
{
    public class Role
    {
        public int? Id { get; }

        public string Name { get; set; }

        public Role(int? id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
