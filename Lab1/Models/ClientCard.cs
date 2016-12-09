namespace Lab1.Models
{
    public class ClientCard
    {
        public int ClientCardId { get; set; }

        public int PinCode { get; set; }

        public string ClientCardNumber { get; set; }

        public int AccountId { get; set; }

        public Account Account { get; set; }
    }
}