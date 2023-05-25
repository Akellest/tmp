abstract class Musician
{
    public string name;
    protected IMusicBandMediator mediator;

    public Musician(string name, IMusicBandMediator mediator)
    {
        this.name = name;
        this.mediator = mediator;
    }

    public abstract void Send(string message);
    public abstract void Receive(string message);
}

class Guitarist : Musician
{
    public Guitarist(string name, IMusicBandMediator mediator) : base(name, mediator)
    {
    }

    public override void Send(string message)
    {
        mediator.BroadcastMessage(name, message);
    }

    public override void Receive(string message)
    {
        Console.WriteLine($"{name} received a message: {message}");
    }
}

class Drummer : Musician
{
    public Drummer(string name, IMusicBandMediator mediator) : base(name, mediator)
    {
    }

    public override void Send(string message)
    {
        mediator.BroadcastMessage(name, message);
    }

    public override void Receive(string message)
    {
        Console.WriteLine($"{name} received a message: {message}");
    }
}

interface IMusicBandMediator
{
    void RegisterMusician(Musician musician);
    void BroadcastMessage(string sender, string message);
}

class MusicBandMediator : IMusicBandMediator
{
    private readonly List<Musician> musicians = new List<Musician>();

    public void RegisterMusician(Musician musician)
    {
        musicians.Add(musician);
    }

    public void BroadcastMessage(string sender, string message)
    {
        foreach (var musician in musicians)
        {
            if (musician.name != sender)
            {
                musician.Receive(message);
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        IMusicBandMediator mediator = new MusicBandMediator();
        Musician guitarist = new Guitarist("Adam", mediator);
        Musician drummer = new Drummer("Eva", mediator);
        mediator.RegisterMusician(guitarist);
        mediator.RegisterMusician(drummer);
        guitarist.Send("I'm starting playing");
        drummer.Send("Let's do it");
    }
}
