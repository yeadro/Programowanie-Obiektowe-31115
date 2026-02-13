using System.Text.Json;
using lab3.Models;

string filePath = Path.Combine(Directory.GetCurrentDirectory(), "cars.json");
List<Car> cars = new List<Car>();

if (File.Exists(filePath))
{
    var carJson = File.ReadAllText(filePath);
    if (!string.IsNullOrWhiteSpace(carJson))
    {
        cars = JsonSerializer.Deserialize<List<Car>>(carJson) ?? new List<Car>();
    }
}

bool continueApp = true;

do
{
    Console.WriteLine("\n------KOMIS SAMOCHODOWY------");
    Console.WriteLine("1. Lista pojazdów");
    Console.WriteLine("2. Dodaj pojazd");
    Console.WriteLine("3. Usuń pojazd");
    Console.WriteLine("4. Modyfikuj pojazd");
    Console.WriteLine("0. Wyjście");
    Console.Write("Wybierz opcję: ");
    
    var option = Console.ReadKey().KeyChar;
    Console.Clear();

    switch (option)
    {
        case '0':
            Console.WriteLine("Do zobaczenia...");
            continueApp = false;
            break;
            
        case '1':
            Console.WriteLine("--- Lista Dostępnych Pojazdów ---");
            if (cars.Count == 0) Console.WriteLine("Komis jest pusty.");
            foreach (var car in cars)
            {
                car.ShowMe();
            }
            break;
            
        case '2':
            AddNewVehicle();
            SaveCarsToFile();
            break;
            
        case '3':
            RemoveVehicle();
            SaveCarsToFile();
            break;
            
        case '4':
            UpdateVehicle();
            SaveCarsToFile();
            break;
            
        default:
            Console.WriteLine("Nieznana opcja.");
            break;
    }

} while (continueApp);


void AddNewVehicle()
{
    Console.WriteLine("--- Dodawanie nowego pojazdu ---");
    Console.Write("Podaj Model: ");
    var model = Console.ReadLine();

    Console.Write("Podaj Silnik: ");
    var engine = Console.ReadLine();

    Console.Write("Podaj Rok produkcji: ");
    var success = int.TryParse(Console.ReadLine(), out int year);
    
    if(string.IsNullOrWhiteSpace(model) || string.IsNullOrWhiteSpace(engine) || !success) 
    {
        Console.WriteLine("Błąd: Nieprawidłowe dane wejściowe.");
        return;
    }

    try 
    {
        var car = new Car(engine, model, year);
        cars.Add(car);
        Console.WriteLine("Pojazd dodany pomyślnie.");
    }
    catch (ArgumentOutOfRangeException ex)
    {
        Console.WriteLine($"Błąd: {ex.Message}");
    }
}

void RemoveVehicle()
{
    Console.WriteLine("--- Usuwanie pojazdu ---");
    Console.Write("Podaj nazwę modelu do usunięcia: ");
    var modelToRemove = Console.ReadLine();
    
    if (string.IsNullOrWhiteSpace(modelToRemove))
    {
        Console.WriteLine("Nazwa modelu nie może być pusta.");
        return;
    }

    var carToRemove = cars.FirstOrDefault(c => c.Model.Equals(modelToRemove, StringComparison.OrdinalIgnoreCase));
    
    if (carToRemove != null)
    {
        cars.Remove(carToRemove);
        Console.WriteLine("Pojazd usunięty pomyślnie.");
    }
    else
    {
        Console.WriteLine("Nie znaleziono pojazdu o takim modelu.");
    }
}

void UpdateVehicle()
{
    Console.WriteLine("--- Modyfikacja pojazdu ---");
    Console.Write("Podaj nazwę modelu, który chcesz edytować: ");
    var modelToEdit = Console.ReadLine();

    var carToEdit = cars.FirstOrDefault(c => c.Model.Equals(modelToEdit, StringComparison.OrdinalIgnoreCase));

    if (carToEdit == null)
    {
        Console.WriteLine("Nie znaleziono takiego pojazdu.");
        return;
    }

    Console.WriteLine($"Edytujesz: {carToEdit.Model} ({carToEdit.Year})");
    
    Console.Write("Nowy Model (wciśnij Enter by pominąć): ");
    string newModel = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(newModel)) newModel = carToEdit.Model;

    Console.Write("Nowy Silnik (wciśnij Enter by pominąć): ");
    string newEngine = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(newEngine)) newEngine = carToEdit.Engine;

    Console.Write("Nowy Rok (wpisz 0 by pominąć): ");
    int.TryParse(Console.ReadLine(), out int newYear);
    if (newYear == 0) newYear = carToEdit.Year;

    try
    {
        carToEdit.UpdateData(newModel, newEngine, newYear);
        Console.WriteLine("Dane zaktualizowane.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Nie udało się zaktualizować: {ex.Message}");
    }
}

void SaveCarsToFile()
{
    var options = new JsonSerializerOptions { WriteIndented = true };
    File.WriteAllText(filePath, JsonSerializer.Serialize(cars, options));
}
