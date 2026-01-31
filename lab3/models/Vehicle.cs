using System.Text.Json;

namespace lab3.Models;

public abstract class Vehicle
{
    public string Engine { get; protected set; }
    public bool IsOn {get; private set;}

    public Vehicle(string engine)
    {
        Engine = engine;    
    }

    public virtual void Start()
    {
        Console.WriteLine("Vehicle Started");
        IsOn = true;
    }

    public void Stop()
    {
        IsOn = false;
    }
}
