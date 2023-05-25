abstract class Transport
{
    public abstract void Drive();
}

class Car : Transport
{
    public override void Drive()
    {
        Console.WriteLine("*Driving a car*");
    }
}

class Motorcycle : Transport
{
    public override void Drive()
    {
        Console.WriteLine("*Driving a motorcycle*");
    }
}

abstract class TransportFactory
{
    public abstract Transport CreateTransport();
}

class CarFactory : TransportFactory
{
    public override Transport CreateTransport()
    {
        return new Car();
    }
}

class MotorcycleFactory : TransportFactory
{
    public override Transport CreateTransport()
    {
        return new Motorcycle();
    }
}

class Program
{
    static void Main(string[] args)
    {
        TransportFactory carFactory = new CarFactory();
        Transport car = carFactory.CreateTransport();
        car.Drive();
        TransportFactory motorcycleFactory = new MotorcycleFactory();
        Transport motorcycle = motorcycleFactory.CreateTransport();
        motorcycle.Drive();
    }
}
