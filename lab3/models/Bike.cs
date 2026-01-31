namespace lab3.Models;

public class Bike : Vehicle
{
    private string bikeType;

    public Bike(string engine, string bikeType) : base(engine)
    {
        this.bikeType = bikeType;
    }

    public override void Start()
    {
        Console.WriteLine("Unlocked!");
        base.Start();
    }
}

