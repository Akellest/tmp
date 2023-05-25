abstract class DeliveryItem
{
    public abstract void Accept(IVisitor visitor);
}

class Package : DeliveryItem
{
    public string TrackingNumber { get; set; }

    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

class Box : DeliveryItem
{
    public int NumberOfPackages { get; set; }

    public override void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

interface IVisitor
{
    void Visit(Package package);
    void Visit(Box pallet);
}

class DeliveryVisitor : IVisitor
{
    public void Visit(Package package)
    {
        Console.WriteLine("Processing package with tracking number: " + package.TrackingNumber);
    }

    public void Visit(Box pallet)
    {
        Console.WriteLine("Processing pallet with " + pallet.NumberOfPackages + " packages");
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<DeliveryItem> deliveryItems = new List<DeliveryItem>
        {
            new Package { TrackingNumber = "ABC123" },
            new Package { TrackingNumber = "XYZ789" },
            new Box { NumberOfPackages = 5 }
        };

        IVisitor visitor = new DeliveryVisitor();

        foreach (DeliveryItem item in deliveryItems)
        {
            item.Accept(visitor);
        }
    }
}
