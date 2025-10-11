 const int requiredAge = 18;
const string accessDeniedMessage = "Musisz mieć 18 lat.";
const string accessAllowedMessage = "Witamy w sklepie.";
const string accessRestrictedMessage = "Masz ograniczony dostęp do produktów.";
int age;
int restrictedAge = 14;
do
{
    Console.WriteLine("Wprowadź wiek:");
    string input = Console.ReadLine();

    age = Convert.ToInt32(input);

    if (age >= requiredAge)
    {
        Console.WriteLine(accessAllowedMessage);
    }
    else if (age >= restrictedAge)
    {
        Console.WriteLine($"{accessAllowedMessage} {accessRestrictedMessage}");
    }
    else
    {
        Console.WriteLine(accessDeniedMessage);
    }
} while (age <= restrictedAge); 

/*
// zad. 1
string password = "admin123";
string input;
Console.WriteLine("Wprowadź hasło:");
input = Console.ReadLine();

while (input != password)
{
    Console.WriteLine("Spróbuj ponownie:");
    input = Console.ReadLine();
}

Console.WriteLine("Witamy w systemie.");
*/

/*
// zad. 2
int liczba;
do
{
    Console.WriteLine("Podaj liczbę większą od 0:");
    string input = Console.ReadLine();
    liczba = Convert.ToInt32(input);
} while (liczba ! > 0);
Console.WriteLine("Dziękuje.");
*/

// zad. 3
/*
string[] miasta = { "Szczecin", "Poznań", "Warszawa", "Gdańsk", "Zakopane" };
foreach (string miasto in miasta)
{
    Console.WriteLine(miasto);
}
*/