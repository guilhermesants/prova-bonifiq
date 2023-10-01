namespace ProvaPub.Models.abstracts
{
    public abstract class Payment
    {
        public decimal PaymentValue;
        public int CustomerId;
        
        protected Payment(decimal paymentValue, int customerId) 
        { 
            PaymentValue = paymentValue;
            CustomerId = customerId;
        }
    }
}
