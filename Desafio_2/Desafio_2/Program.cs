using System;
using System.Reflection.Metadata.Ecma335;
using static System.Net.WebRequestMethods;

MainMenu:

Console.WriteLine("- - - - - MODO DE PESQUISA - - - - -");
Console.WriteLine("1. Pesquisar por moeda.");
Console.WriteLine("2. Pesquisar por região.");

int UserChoice = int.Parse(Console.ReadLine());

switch (UserChoice)
{
    case 1:
        CountryDataSet _root = new CountryDataSet();  

        Console.Write("Moeda desejada (BRL); (dollar); (euro):  ");
        _root.currency = Console.ReadLine();
        string FormatedCurrencie = _root.currency.ToUpper();


        using (HttpClient client = new HttpClient())
        {
            try
            {
                string url = $"https://restcountries.com/v3.1/currency/{_root.currency}?fields=name,capital,currencies";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                List<CountryDataSet> CountryChoice = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CountryDataSet>>(responseBody);

                foreach (var item in CountryChoice)
                {
                    if (FormatedCurrencie == "BRL")
                    {
                        Console.WriteLine(item.name.official);
                    }
                    else if (FormatedCurrencie == "EURO")
                    {
                        Console.WriteLine(item.name.official);

                    }
                    else if (FormatedCurrencie == "DOLLAR")
                    {
                        Console.WriteLine(item.name.official);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            break;
        }
    case 2:
        CountryDataSet _root2 = new CountryDataSet();
        Console.Write("Continente desejado: ");
        _root2.region = Console.ReadLine();
        string FormatedRegion = _root2.region.ToLower();

        using (HttpClient client = new HttpClient())
        {
            try
            {
                string url = $"https://restcountries.com/v3.1/currency/{_root2.region}?fields=name,capital,currencies,countries";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                List<CountryDataSet> CountryChoice = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CountryDataSet>>(responseBody);

                foreach (var item in CountryChoice)
                {
                    if (FormatedRegion == "afr")
                    {
                        Console.WriteLine(item.name.official);
                    }
                    if (FormatedRegion == "brl")
                    {
                        Console.WriteLine(item.name.official);
                    }
                    if (FormatedRegion == "usd")
                    {
                        Console.WriteLine(item.name.official);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        break;
}

// ContryDataSet myDeserializedClass = JsonConvert.DeserializeObject<List<ContryDataSet>>(myJsonResponse);
public class BRL
{
    public string name { get; set; }
    public string symbol { get; set; }
}

public class Currencies
{
    public BRL BRL { get; set; }
}

public class Name
{
    public string common { get; set; }
    public string official { get; set; }
    public NativeName nativeName { get; set; }
}

public class NativeName
{
    public Por por { get; set; }
}

public class Por
{
    public string official { get; set; }
    public string common { get; set; }
}

public class CountryDataSet
{
    public Name name { get; set; }
    public Currencies currencies { get; set; }
    public List<string> capital { get; set; }
    public string currency { get; set; }
    public string region { get; set; }
}
public class Afr
{
    public string official { get; set; }
    public string common { get; set; }
}
public class Cha
{
    public string official { get; set; }
    public string common { get; set; }
}

public class Fra
{
    public string official { get; set; }
    public string common { get; set; }
}
