using System;

interface IPayment
{
    void Pay(double amount);
}

class CashPayment : IPayment
{
    public void Pay(double amount)
    {
        Console.WriteLine($"Оплатил наличкой {amount} руб.");
    }
}

class CardPayment : IPayment
{
    public void Pay(double amount)
    {
        Console.WriteLine($"Оплатил картой {amount} руб.");
    }
}

class OldPaymentSystem
{
    public void MakeTransaction(double money)
    {
        Console.WriteLine("Старая система обработала платёж: " + money);
    }
}

class OldPaymentAdapter : IPayment
{
    private OldPaymentSystem oldPaymentSystem;

    public OldPaymentAdapter(OldPaymentSystem oldPaymentSystem)
    {
        this.oldPaymentSystem = oldPaymentSystem;
    }

    public void Pay(double amount)
    {
        oldPaymentSystem.MakeTransaction(amount);
    }
}

class Program
{
    static void Main()
    {

        CardPayment card = new CardPayment();
        card.Pay(123);

        CashPayment cash = new CashPayment();
        cash.Pay(123);

        OldPaymentSystem oldSys = new OldPaymentSystem();
        IPayment adaptedoldSys = new OldPaymentAdapter(oldSys);
        adaptedoldSys.Pay(123);

    }
}