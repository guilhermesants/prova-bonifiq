namespace ProvaPub.Models.abstracts
{
    public abstract class Payment
    {
        protected decimal PaymentValue;
        protected int CustomerId;
        
        protected Payment(decimal paymentValue, int customerId) 
        { 
            PaymentValue = paymentValue;
            CustomerId = customerId;
        }
        public virtual Order MakePayment() => new Order { Value = PaymentValue };
    }
}
