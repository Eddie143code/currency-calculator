using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CurrencyApi.Models;
using System;
using Newtonsoft.Json;

namespace CurrencyApi.Models
{
    public class CurrencyInfo
    {

        static readonly HttpClient client = new HttpClient();
        public Tuple<string, double>? baseCurrency { get; set; }
        public Tuple<string, double>? convertedCurrency { get; set; }
        public double convertedAmount { get; set; }
        public List<Tuple<string, double>>? CurrencyList { get; set; }

        public static async Task<HttpResponseMessage> GetExchangeRates(CurrencyInfo postData)
        {
            HttpResponseMessage response = await client.GetAsync($"https://v6.exchangerate-api.com/v6/8e44806e11613498f4eec236/latest/{postData.baseCurrency.Item1}");

            return response;
        }

        public static async Task<CurrencyInfo> CurrencyInfoResult(CurrencyInfo postData)
        {
            if (postData.baseCurrency == null || postData.convertedCurrency == null)
                throw new ArgumentException("baseCurrency and convertedCurrency must be set.");

            HttpResponseMessage response = await CurrencyInfo.GetExchangeRates(postData);

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var exchangeRateResponse = JsonConvert.DeserializeObject<ExchangeRateResponse>(jsonResponse);

            if (exchangeRateResponse.Rates.ContainsKey(postData.convertedCurrency.Item1))
            {
                double exchangeRate = exchangeRateResponse.Rates[postData.convertedCurrency.Item1];
                postData.baseCurrency = postData.baseCurrency;
                postData.convertedCurrency = new Tuple<string, double>(postData.convertedCurrency.Item1, exchangeRate);
                postData.convertedAmount = postData.baseCurrency.Item2 * postData.convertedCurrency.Item2;
                postData.CurrencyList = exchangeRateResponse.Rates
                  .OrderByDescending(r => r.Value)
                  .Take(10)
                  .Select(r => new Tuple<string, double>(r.Key, r.Value))
                  .ToList();
                return postData;
            }
            else
            {
                return new CurrencyInfo();
            }

        }
    }
}