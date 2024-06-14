using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices.JavaScript;

public class Program
{
    static void Main(string[] args)
    {
        var client = new HttpClient();

        var key = "9cd2281dfb31c4f6fbf98af017c6b933";
        var city = "Birmingham";

       
        

        while (true) 
        {
            Console.WriteLine();
            Console.WriteLine("Please enter the city name:");
            var city_name = Console.ReadLine();
            Console.WriteLine();
            var weatherURL = $"http://api.openweathermap.org/data/2.5/weather?q={city}&units=imperial&appid={key}";
            var response = client.GetStringAsync(weatherURL).Result;
            JObject formattedResponse = (JObject)JObject.Parse(response).GetValue("main");
            var temperature = formattedResponse.Value<double>("temp");
            Console.WriteLine($"The current Temperature is {temperature} degrees Fahrenheit");
            AddSpaces(2);
            Console.WriteLine("Would you like to exit");
            var userInput = Console.ReadLine();
            AddSpaces(2);

            if (userInput.ToLower().Trim() == "yes") 
            {
                break;
            }

        }
    }

    static void AddSpaces(int numberOfSpaces)
    {
        while (numberOfSpaces != 0)
        {
            Console.WriteLine();
            numberOfSpaces--;
        }
    }
}
