using System.Runtime.InteropServices.JavaScript;

public class Program
{
    static void Main(string[] args)
    {
        var client = new HttpClient();

        var key = "9cd2281dfb31c4f6fbf98af017c6b933";
        var city = "Birmingham";

        var weatherURL = $"api.openweathermap.org/data/3.0/onecall?lat=30.489772&lon=-99.771335&units=imperial";
        var response = client.GetStringAsync(weatherURL).Result;

        Console.WriteLine(response);

        JSObject formattedResponse = JSObject.Parse(response);
        var temp = formattedResponse["List"][0]["main"]["temp"];
        Console.WriteLine(temp);

        while (true) ;
        {
            Console.WriteLine();
            Console.WriteLine("Please enter the city name:");
            var city_namw = Console.ReadLine();
            Console.WriteLine();
            var weatherURL = $"api.openweathermap.org/data/3.0/onecall?lat=30.489772&lon=-99.771335&units=imperial";
            var response = client.GetStringAsync(weatherURL).Result;
            JSObject formattedResponse = JSObject.Parse(response).GetValue("main").ToString();
            Console.WriteLine($"The current Temperature is {JObject.Parse(formattedResponse).GetValue("temp")} degrees Fahrenheit");
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
