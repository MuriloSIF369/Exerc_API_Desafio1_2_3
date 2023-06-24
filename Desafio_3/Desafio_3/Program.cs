using Functions;
using DataSet;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Serialization;
using System.Net.Http.Headers;

start:
StringBuilder functions = new StringBuilder();
Root UrlString = new Root();

Console.WriteLine("BEM VINDO AO CONVERSOR DE MOEDA");
Console.WriteLine("_______________________________");
Console.WriteLine("Moeda a converter:");
Console.WriteLine("1. Real (BRL)\n" +
        "2. Dolar (USD)\n" +
        "3. Euro (EUR)");
string broad = Console.ReadLine();
string FirstTerm = functions.ValidateChoice(broad);
Console.WriteLine("Moeda a ser convertida:\n" +
    "");
string Target = functions.SwitchCurrencyMenu(FirstTerm);
string SecondTerm = functions.ValidateChoice(Target);

UrlString.BaseUrl = functions.BroadConverter(FirstTerm);
UrlString.TargetUrl = functions.BroadConverter(SecondTerm);

using (HttpClient client = new HttpClient())
{
    try
    {
        string url = $"https://economia.awesomeapi.com.br/last/{UrlString.BaseUrl}-{UrlString.TargetUrl}/";
        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        Root root = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(responseBody);
        
        if (UrlString.BaseUrl == "USD" && UrlString.TargetUrl == "BRL")
        {
            Console.WriteLine($"Conversão DE/PARA: {root.USDBRL.name}");
            Console.WriteLine($"Alta Do Dia: {root.USDBRL.high}");
            Console.WriteLine($"Baixa Do Dia: {root.USDBRL.low}");
            Console.WriteLine($"Porcentagem de Alteração: {root.USDBRL.pctChange}");

        }
        if (UrlString.BaseUrl == "BRL" && UrlString.TargetUrl == "USD")
        {
            Console.WriteLine($"Conversão DE/PARA: {root.BRLUSD.name}");
            Console.WriteLine($"Alta Do Dia: {root.BRLUSD.high}");
            Console.WriteLine($"Baixa Do Dia: {root.BRLUSD.low}");
            Console.WriteLine($"Porcentagem de Alteração: {root.BRLUSD.pctChange}");
        }

        if (UrlString.BaseUrl == "USD" && UrlString.TargetUrl == "EUR")
        {
            Console.WriteLine($"Conversão DE/PARA: {root.USDEUR.name}");
            Console.WriteLine($"Alta Do Dia: {root.USDEUR.high}");
            Console.WriteLine($"Baixa Do Dia: {root.USDEUR.low}");
            Console.WriteLine($"Porcentagem de Alteração: {root.USDEUR.pctChange}");

        }
        if (UrlString.BaseUrl == "EUR" && UrlString.TargetUrl == "USD")
        {
            Console.WriteLine($"Conversão DE/PARA: {root.EURUSD.name}");
            Console.WriteLine($"Alta Do Dia: {root.EURUSD.high}");
            Console.WriteLine($"Baixa Do Dia: {root.EURUSD.low}");
            Console.WriteLine($"Porcentagem de Alteração: {root.EURUSD.pctChange}");
        }
        if (UrlString.BaseUrl == "BRL" && UrlString.TargetUrl == "EUR")
        {
            Console.WriteLine($"Conversão DE/PARA: {root.BRLEUR.name}");
            Console.WriteLine($"Alta Do Dia: {root.BRLEUR.high}");
            Console.WriteLine($"Baixa Do Dia: {root.BRLEUR.low}");
            Console.WriteLine($"Porcentagem de Alteração: {root.BRLEUR.pctChange}");

        }
        if (UrlString.BaseUrl == "EUR" && UrlString.TargetUrl == "BRL")
        {
            Console.WriteLine($"Conversão DE/PARA: {root.EURBRL.name}");
            Console.WriteLine($"Alta Do Dia: {root.EURBRL.high}");
            Console.WriteLine($"Baixa Do Dia: {root.EURBRL.low}");
            Console.WriteLine($"Porcentagem de Alteração: {root.EURBRL.pctChange}");
        }


    }
    catch (Exception)
    {

        throw;
    }
}

Console.Write("Deseja fazer uma nova consulta? 1. Sim | 2. Não: ");
int Answer = Convert.ToInt32(Console.ReadLine());
if (Answer == 1)
{
    Console.WriteLine("");
    goto start;
}
else
{
}
namespace DataSet
{
    public class Root
    {
        public USDBRL USDBRL { get; set; }
        public BRLUSD BRLUSD { get; set; }
        public BRLEUR BRLEUR { get; set; }
        public EURBRL EURBRL { get; set; }
        public USDEUR USDEUR { get; set; }
        public EURUSD EURUSD { get; set; }
        public string BaseUrl { get; set; }
        public string TargetUrl { get; set; }
        public string code { get; set; }
        public string codein { get; set; }
        public string name { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string varBid { get; set; }
        public string pctChange { get; set; }
        public string bid { get; set; }
        public string ask { get; set; }
        public string timestamp { get; set; }
        public string create_date { get; set; }
    }
    public class USDBRL
    {
        public string code { get; set; }
        public string codein { get; set; }
        public string name { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string varBid { get; set; }
        public string pctChange { get; set; }
        public string bid { get; set; }
        public string ask { get; set; }
        public string timestamp { get; set; }
        public string create_date { get; set; }

    }
    public class BRLUSD
    {
        public string code { get; set; }
        public string codein { get; set; }
        public string name { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string varBid { get; set; }
        public string pctChange { get; set; }
        public string bid { get; set; }
        public string ask { get; set; }
        public string timestamp { get; set; }
        public string create_date { get; set; }
    }
    public class BRLEUR
    {
        public string code { get; set; }
        public string codein { get; set; }
        public string name { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string varBid { get; set; }
        public string pctChange { get; set; }
        public string bid { get; set; }
        public string ask { get; set; }
        public string timestamp { get; set; }
        public string create_date { get; set; }
    }
    public class EURBRL
    {
        public string code { get; set; }
        public string codein { get; set; }
        public string name { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string varBid { get; set; }
        public string pctChange { get; set; }
        public string bid { get; set; }
        public string ask { get; set; }
        public string timestamp { get; set; }
        public string create_date { get; set; }
    }
    public class USDEUR
    {
        public string code { get; set; }
        public string codein { get; set; }
        public string name { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string varBid { get; set; }
        public string pctChange { get; set; }
        public string bid { get; set; }
        public string ask { get; set; }
        public string timestamp { get; set; }
        public string create_date { get; set; }
    }
    public class EURUSD
    {
        public string code { get; set; }
        public string codein { get; set; }
        public string name { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string varBid { get; set; }
        public string pctChange { get; set; }
        public string bid { get; set; }
        public string ask { get; set; }
        public string timestamp { get; set; }
        public string create_date { get; set; }
    }
}

namespace Functions
{
    public class StringBuilder
    {
        public string SwitchCurrencyMenu(string choice)
        {
            if (choice == "1")
            {
                retry:
                Console.WriteLine("2. Dolar(USD)\n" +
                                  "3. Euro (EUR)");
                string SecondChoice = Console.ReadLine();
                if (SecondChoice == choice)
                {
                    Console.WriteLine("Moeda já selecionada! tente outra opção.");
                    goto retry;
                }
                return SecondChoice;
            }

            else if (choice == "2")
            {
                retry:
                Console.WriteLine("1. Real(BRL)\n" +
                                  "3. Euro (EUR)");

                string SecondChoice = Console.ReadLine();
                if (SecondChoice == choice)
                {
                    Console.WriteLine("Moeda já selecionada! tente outra opção.");
                    goto retry;
                }
                return SecondChoice;
            }
            else
            {
                retry:
                Console.WriteLine("1. Real(BRL)\n" +
                                  "2. Dolar(USD)");

                string SecondChoice = Console.ReadLine();
                if (SecondChoice == choice)
                {
                    Console.WriteLine("Moeda já selecionada! tente outra opção.");
                    goto retry;
                }
                return SecondChoice;
            }
        }
        public string ValidateChoice(string Name)
        {
            while (Name != "1" && Name != "2" && Name != "3")
            {
                Console.Write("Opção inválida, tente novamente:");
                Name = Console.ReadLine();
            }
            return Name;
        }
        public string BroadConverter(string Broad)
        {
            if (Broad == "1")
            {
                Broad = "BRL";
                return Broad;
            }
            else if (Broad == "2")
            {
                Broad = "USD";
                return Broad;
            }
            else
            {
                Broad = "EUR";
                return Broad;
            }
        }
        public string TargetConverter(string Target)
        {
            if (Target == "1")
            {
                Target = "BRL";
                return Target;
            }
            else if (Target == "2")
            {
                Target = "USD";
                return Target;
            }
            else
            {
                Target = "EUR";
                return Target;
            }
        }
    }
}