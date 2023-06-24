using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.ComponentModel.Design;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using BuscaIP_API;

DadosIP dados = new DadosIP();
Console.Write("Digite o IP:");
dados.recebeIP = Console.ReadLine();

using (HttpClient client = new HttpClient())
{
    try
    {
        DadosIP dados1 = new DadosIP();

        string url = $"https://ipapi.co/{dados1.recebeIP}/json/";

        HttpResponseMessage response = await client.GetAsync(url);

        response.EnsureSuccessStatusCode();

        string responseBody = await response.Content.ReadAsStringAsync();

        // Fazendo o parsing da resposta JSON

        DadosIP DadosIP = Newtonsoft.Json.JsonConvert.DeserializeObject<DadosIP>(responseBody);

        // Exibindo os dados do dados do IP
        Console.WriteLine($"IP: {dados.ip}");
        Console.WriteLine($"REDE: {dados.network}");
        Console.WriteLine($"VERSÃO: {dados.version}");
        Console.WriteLine($"CIDADE: {dados.city}");
        Console.WriteLine($"REGIÃO: {dados.region}");
        Console.WriteLine($"CODIGO REGIÃO: {dados.region_code}");
        Console.WriteLine($"PAIS: {dados.country}");
        Console.WriteLine($"NOME PAIS: {dados.country_name}");
        Console.WriteLine($"NOME CODIGO: {dados.country_code}");
    }
    catch (HttpRequestException ex)
    {
        Console.WriteLine($"Ocorreu um erro ao fazer a requisição HTTP: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ocorreu um erro: {ex.Message}");
    }
    Console.ReadLine();
}



namespace BuscaIP_API
{
    public class DadosIP
    {
        public bool error { get; set; }
        public string reason { get; set; }
        public bool reserved { get; set; }
        public string ip { get; set; }
        public string network { get; set; }
        public string version { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string region_code { get; set; }
        public string country { get; set; }
        public string country_name { get; set; }
        public string country_code { get; set; }
        public string country_code_iso3 { get; set; }
        public string country_capital { get; set; }
        public string country_tld { get; set; }
        public string continent_code { get; set; }
        public bool in_eu { get; set; }
        public string postal { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string timezone { get; set; }
        public string utc_offset { get; set; }
        public string country_calling_code { get; set; }
        public string currency { get; set; }
        public string currency_name { get; set; }
        public string languages { get; set; }
        public double country_area { get; set; }
        public int country_population { get; set; }
        public string asn { get; set; }
        public string org { get; set; }
        public string recebeIP { get; set; }

    }
}