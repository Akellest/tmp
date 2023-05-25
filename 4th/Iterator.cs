using System.Collections;

class Employee // Класс сотрудника
{
    public string Name { get; set; }
    public string Position { get; set; }

    public Employee(string name, string position)
    {
        Name = name;
        Position = position;
    }
}

class EmployeeCollection : IEnumerable<Employee>
{
    private List<Employee> employees = new List<Employee>();

    public void AddEmployee(Employee employee)
    {
        employees.Add(employee);
    }

    public IEnumerator<Employee> GetEnumerator()
    {
        return employees.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main(string[] args)
    {
        EmployeeCollection employeeCollection = new EmployeeCollection();

        employeeCollection.AddEmployee(new Employee("Willy", "Manager"));
        employeeCollection.AddEmployee(new Employee("Arthur", "Writer"));
        employeeCollection.AddEmployee(new Employee("Clark", "Driver"));

        foreach (Employee employee in employeeCollection)
        {
            Console.WriteLine("Name: " + employee.Name + ", Position: " + employee.Position);
        }
    }
}
