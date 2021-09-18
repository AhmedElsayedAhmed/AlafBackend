namespace Framework.Helpers
{
    public class RequiredItems
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public RequiredItems(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public RequiredItems()
        {

        }
    }
}
