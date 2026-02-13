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
                throw new ArgumentOutOfRangeException("Year", "Rok nie może być mniejszy niż 2000");
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
    
    public void UpdateData(string newModel, string newEngine, int newYear)
    {
        if (!string.IsNullOrWhiteSpace(newModel))
            Model = newModel;
            
        if (!string.IsNullOrWhiteSpace(newEngine))
            Engine = newEngine;
            
        Year = newYear;
    }

    public void ShowMe()
    {
        Console.WriteLine($"Model: {this.Model}, Rok: {this.Year}, Silnik: {this.Engine}");
    }
}
