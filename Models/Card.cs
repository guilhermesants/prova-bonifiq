namespace ProvaPub.Models
{
    public class Card
    {
        public string Number { get; set; }

        public bool isValid()
        {
            return Number.Length == 16 && !String.IsNullOrEmpty(Number);
        }
    }
}
