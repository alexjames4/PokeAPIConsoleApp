using System.Net.Http;
using System.Text.Json;

class Program
{
    public static void pokemonSearch()
    {
        Console.WriteLine("Search for a pokemon by name: ");

        string enteredName = Console.ReadLine();

        try
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://pokeapi.co/api/v2/pokemon/");


            var response = client.GetAsync(enteredName).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                var getResponse = JsonSerializer.Deserialize<GetResponse>(responseContent);

                if (enteredName.Length == 0)
                {
                    Console.WriteLine("No pokemon name or id entered. Take a look at some below:");
                    Console.WriteLine(getResponse.count);

                    foreach (var pokemon in getResponse.results)
                    {
                        Console.WriteLine("Name: " + pokemon.name);
                        Console.WriteLine("URL: " + pokemon.url);

                        Console.WriteLine("---------------------");
                    }
                }
                else if (getResponse.weight == 0)
                {
                    Console.WriteLine("Not currently a Pokemon. Maybe in a few generations time it will be though...");
                }
                else
                {
                    Console.WriteLine($"Name: {getResponse.name}");
                    Console.WriteLine($"Height: {getResponse.height}");
                    Console.WriteLine($"Weight: {getResponse.weight}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    static void Main(string[] args)
    {
        pokemonSearch();
    }
}
