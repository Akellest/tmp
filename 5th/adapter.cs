interface IPaymentSystem
{
    void ProcessPayment(string paymentMethod, float amount);
}

class BankTransferPaymentSystem : IPaymentSystem
{
    public void ProcessPayment(string paymentMethod, float amount)
    {
        Console.WriteLine($"Processing payment {amount} $ via bank transfer");
    }
}

class CreditCardPaymentSystem
{
    public void MakeCreditCardPayment(float amount)
    {
        Console.WriteLine($"Making credit card payment {amount} $");
    }
}

class CreditCardPaymentAdapter : IPaymentSystem
{
    private CreditCardPaymentSystem creditCardPaymentSystem;

    public CreditCardPaymentAdapter(CreditCardPaymentSystem paymentSystem)
    {
        creditCardPaymentSystem = paymentSystem;
    }

    public void ProcessPayment(string paymentMethod, float amount)
    {
        if (paymentMethod == "CreditCard")
        {
            creditCardPaymentSystem.MakeCreditCardPayment(amount);
        }
        else
        {
            Console.WriteLine("Invalid payment method");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        IPaymentSystem bankTransferPaymentSystem = new BankTransferPaymentSystem();
        bankTransferPaymentSystem.ProcessPayment("BankTransfer", 100.0f);
        Console.WriteLine();
        CreditCardPaymentSystem creditCardPaymentSystem = new CreditCardPaymentSystem();
        IPaymentSystem creditCardPaymentAdapter = new CreditCardPaymentAdapter(creditCardPaymentSystem);
        creditCardPaymentAdapter.ProcessPayment("CreditCard", 200.0f);
    }
}
