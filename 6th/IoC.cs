interface IService
{
    void DoSomething();
}

class ConcreteService : IService // Реализация сервиса
{
    public void DoSomething()
    {
        Console.WriteLine("Watering a flower");
    }
}

class DependentClass // Класс, зависимый от сервиса
{
    private IService service;
    public DependentClass(IService service)
    {
        this.service = service;
    }
    public void Execute()
    {
        service.DoSomething();
    }
}

class DependencyResolver
{
    public static DependentClass Resolve()
    {
        IService service = new ConcreteService();
        DependentClass dependentClass = new DependentClass(service);
        return dependentClass;
    }
}

class Program
{
    static void Main(string[] args)
    {
        DependentClass dependentClass = DependencyResolver.Resolve();
        dependentClass.Execute();
    }
}
