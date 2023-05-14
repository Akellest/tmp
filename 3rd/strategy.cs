using System;

interface IPaymentStrategy // Интерфейс стратегии разными способами оплаты
{
    void Pay(double amount);
}


class CreditCardPaymentStrategy : IPaymentStrategy // Стратегия оплаты карточкой
{
    private string cardNumber;
    private string expirationDate;
    private string cvv;

    public CreditCardPaymentStrategy(string cardNumber, string expirationDate, string cvv)
    {
        this.cardNumber = cardNumber;
        this.expirationDate = expirationDate;
        this.cvv = cvv;
    }

    public void Pay(double amount)
    {
        Console.WriteLine("Paid " + amount + " rub with card: " + cardNumber);
    }
}


class PayPalPaymentStrategy : IPaymentStrategy // Стратегия оплаты через PayPal
{
    private string email;
    private string password;

    public PayPalPaymentStrategy(string email, string password)
    {
        this.email = email;
        this.password = password;
    }

    public void Pay(double amount)
    {
        Console.WriteLine("Paid " + amount + " rub with PayPal: " + email);
    }
}

class QrCodePaymentStrategy : IPaymentStrategy // Стратегия оплаты через QR-код
{
    private string qrCodeData;

    public QrCodePaymentStrategy(string qrCodeData)
    {
        this.qrCodeData = qrCodeData;
    }

    public void Pay(double amount)
    {
        Console.WriteLine("Paid " + amount + " rub using QR-code: " + qrCodeData);
    }
}


class PaymentContext // Контекст оплаты
{
    private IPaymentStrategy paymentStrategy;

    public PaymentContext(IPaymentStrategy paymentStrategy)
    {
        this.paymentStrategy = paymentStrategy;
    }

    public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
    {
        this.paymentStrategy = paymentStrategy;
    }

    public void ProcessPayment(double amount)
    {
        paymentStrategy.Pay(amount); // Метод Pay() для определенной стратегии оплаты
    }
}

class Program
{
    static void Main(string[] args)
    {
        PaymentContext paymentContext = new PaymentContext(new CreditCardPaymentStrategy("1111222233334444", "12/31", "111"));
        paymentContext.ProcessPayment(100);

        paymentContext.SetPaymentStrategy(new PayPalPaymentStrategy("mail@gmail.com", "123456"));
        paymentContext.ProcessPayment(200);

        paymentContext.SetPaymentStrategy(new QrCodePaymentStrategy("s@h003#2kdso32op%hgtrp089Kodo*&dhcnlLDJ56"));
        paymentContext.ProcessPayment(300.5);
    }
}
