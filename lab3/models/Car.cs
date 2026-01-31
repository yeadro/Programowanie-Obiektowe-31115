namespace lab3.Models;

public class Car : Vehicle
{
    private int year;
    public string Model { get; protected set; }

    public int Year
    {
        get { return year; }
        set
        {
            if (value <= 2000)
            {
                throw new ArgumentOutOfRangeException("Year", "Year cannot be less than 2000");
            }
            year = value;
        }
    }

    public Car(string engine, string model, int year) 
        : base(engine)
    {
        Model = model;
        Year = year;
    }

    public void ShowMe()
    {
        Console.WriteLine($"Model: {this.Model}, Year: {this.Year}, Engine: {this.Engine}");
    }
    
    
}
