namespace Lab1.Models
{
    public class Town
    {
        public Town() { }

        public Town(int id, string name)
        {
            TownId = id;
            Name = name;
        }

        public int TownId { get; set; }

        public string Name { get; set; }
    }
}