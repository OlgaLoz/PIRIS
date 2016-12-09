namespace Lab1.Models
{
	public class Nationality
    {
        public Nationality() { }

        public Nationality(int id, string name)
        {
            NationalityId = id;
            Name = name;
        }

        public int NationalityId { get; set; }
    
		public string Name { get; set; }
    }
}