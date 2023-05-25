interface IComponent
{
    void Display(int depth);
}

class Employee : IComponent
{
    private string name;

    public Employee(string name)
    {
        this.name = name;
    }

    public void Display(int depth)
    {
        Console.WriteLine(new string('-', depth) + name);
    }
}

class Department : IComponent
{
    private string name;
    private List<IComponent> children = new List<IComponent>();

    public Department(string name)
    {
        this.name = name;
    }

    public void Add(IComponent component)
    {
        children.Add(component);
    }

    public void Remove(IComponent component)
    {
        children.Remove(component);
    }

    public void Display(int depth)
    {
        Console.WriteLine(new string('-', depth) + name);

        foreach (var component in children)
        {
            component.Display(depth + 2);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        IComponent employee1 = new Employee("John Doe");
        IComponent employee2 = new Employee("Jane Smith");
        IComponent employee3 = new Employee("Bob Johnson");
        IComponent department = new Department("IT Department");
        ((Department)department).Add(employee1);
        ((Department)department).Add(employee2);
        ((Department)department).Add(employee3);
        IComponent division = new Department("Development Division");
        IComponent employee4 = new Employee("Mark Davis");
        ((Department)division).Add(employee4);
        ((Department)department).Add(division);
        department.Display(0);
    }
}
