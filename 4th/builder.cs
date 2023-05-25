class Building
{
    public string Foundation { get; set; }
    public string Walls { get; set; }
    public string Roof { get; set; }

    public void PrintDetails()
    {
        Console.WriteLine("Building details:");
        Console.WriteLine("Foundation: " + Foundation);
        Console.WriteLine("Walls: " + Walls);
        Console.WriteLine("Roof: " + Roof);
    }
}

interface IBuildingBuilder
{
    void BuildFoundation();
    void BuildWalls();
    void BuildRoof();
    Building GetBuilding();
}

class HouseBuilder : IBuildingBuilder
{
    private Building house;

    public HouseBuilder()
    {
        house = new Building();
    }

    public void BuildFoundation()
    {
        house.Foundation = "House Foundation builder";
    }

    public void BuildWalls()
    {
        house.Walls = "House Walls builder";
    }

    public void BuildRoof()
    {
        house.Roof = "House Roof builder";
    }

    public Building GetBuilding()
    {
        return house;
    }
}

class TowerBuilder : IBuildingBuilder
{
    private Building tower;

    public TowerBuilder()
    {
        tower = new Building();
    }

    public void BuildFoundation()
    {
        tower.Foundation = "Tower Foundation builder";
    }

    public void BuildWalls()
    {
        tower.Walls = "Tower Walls builder";
    }

    public void BuildRoof()
    {
        tower.Roof = "Tower Roof builder";
    }

    public Building GetBuilding()
    {
        return tower;
    }
}

class ConstructionDirector
{
    public void ConstructBuilding(IBuildingBuilder builder)
    {
        builder.BuildFoundation();
        builder.BuildWalls();
        builder.BuildRoof();
    }
}

class Program
{
    static void Main(string[] args)
    {
        ConstructionDirector director = new ConstructionDirector();
        IBuildingBuilder houseBuilder = new HouseBuilder();
        director.ConstructBuilding(houseBuilder);
        Building house = houseBuilder.GetBuilding();
        house.PrintDetails();
        Console.WriteLine();
        IBuildingBuilder skyscraperBuilder = new TowerBuilder();
        director.ConstructBuilding(skyscraperBuilder);
        Building skyscraper = skyscraperBuilder.GetBuilding();
        skyscraper.PrintDetails();
    }
}
