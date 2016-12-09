namespace Lab1.Models
{
	public class Disability
    {
        public Disability() { }

	    public Disability(int id, string name)
	    {
	        DisabilityId = id;
	        Name = name;
	    }

        public int DisabilityId { get; set; }

        public string Name { get; set; }
    }
}