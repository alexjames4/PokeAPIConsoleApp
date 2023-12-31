﻿using System.Net.Http;
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

                if (string.IsNullOrEmpty(enteredName))
                {
                    Console.WriteLine("No pokemon name or id entered. Take a look at some below:");

                    foreach (var pokemon in getResponse.results)
                    {
                        Console.WriteLine("Name: " + pokemon.name);
                        Console.WriteLine("URL: " + pokemon.url);

                        Console.WriteLine("---------------------");
                    }
                }
                else
                {
                    Console.WriteLine($"Name: {getResponse.name}");
                    Console.WriteLine($"Height: {getResponse.height}");
                    Console.WriteLine($"Weight: {getResponse.weight}");
                    Console.WriteLine($"Base XP: {getResponse.base_experience}");
                    Console.WriteLine($"Location: {getResponse.location_area_encounters}");
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
