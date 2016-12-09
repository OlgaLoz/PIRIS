namespace  Lab1.Models
{
	public class FamilyStatus
    {
        public FamilyStatus() { }

        public FamilyStatus(int id, string name)
        {
            FamilyStatusId = id;
            Name = name;
        }

        public int FamilyStatusId { get; set; }

        public string Name { get; set; }
    }
}