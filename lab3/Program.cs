
using System.Text.Json;
using lab3.Models;

var carJson = File.ReadAllText((Path.Combine(Directory.GetCurrentDirectory(), "cars.json")));
var cars = JsonSerializer.Deserialize<List<Car>>(carJson);
bool continueApp =  true;

do
{
    Console.WriteLine("------MENU------");
    Console.WriteLine("1. Car list.");
    Console.WriteLine("2. New vehicle");
    Console.WriteLine("3. Remove vehicle");
    Console.WriteLine("4. Update vehicle");
    Console.WriteLine("0. Exit");
    var option = Console.ReadKey().KeyChar;
    Console.Clear();
    switch (option)
    {
        case '0':
            Console.WriteLine("See ya...");
            continueApp = false;
            break;
        case '1':
            foreach (var car in cars)
            {
                Console.WriteLine(car.Model);
            }
            break;
        case '2':
            AddNewVehicle();
            File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "cars.json"),
                JsonSerializer.Serialize(cars));
            break;
        case '3':
            Console.WriteLine("Model to remove: ");
            var modelToRemove = Console.ReadLine();
           
            var carToRemove = cars.FirstOrDefault(c => c.Model.Equals(modelToRemove, StringComparison.OrdinalIgnoreCase));
            if (string.IsNullOrEmpty(modelToRemove))
            {
                Console.WriteLine("Model to remove is empty");
                continue;
            }
            
            cars.Remove(carToRemove);
            File.WriteAllText(
                Path.Combine(Directory.GetCurrentDirectory(), "cars.json"),
                JsonSerializer.Serialize(cars)
            );
            
            Console.WriteLine("Vehicle removed successfully.");
            break;
        case '4':
            break;
        default:
                Console.WriteLine("unknown option");
            break;
    }

} while (continueApp);

void AddNewVehicle()
{
    Console.WriteLine("New Model: ");
    var model = Console.ReadLine();

    Console.WriteLine("New Engine: ");
    var engine = Console.ReadLine();

    Console.WriteLine("New Year: ");
    var succsess = int.TryParse(Console.ReadLine(), out int year);
    
    if(string.IsNullOrWhiteSpace(model) || string.IsNullOrWhiteSpace(engine) || !succsess) 
    {
        Console.WriteLine("Invalid input");
        return;
    }
    var car = new Car(engine, model, year);
    cars.Add(car);
    
}
