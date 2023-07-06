using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyApi.Models;
using System;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace Currency.Tests
{
    [TestClass]
    public class CurrencyTests
    {
        // property tests

        [TestMethod]
        public void CurrencyConstructor_CreateInstanceOfCurrency_CurrencyInfo()
        {
            CurrencyInfo newCurrency = new CurrencyInfo();
            Assert.AreEqual(typeof(CurrencyInfo), newCurrency.GetType());

            Tuple<string, int> notCurrency = new Tuple<string, int>("south africa", 10);
            Assert.AreNotEqual(newCurrency.GetType(), notCurrency.GetType());

        }


        [TestMethod]
        public void CurrencyBaseCurrency_SetBaseCurrency_CurrencyInfo()
        {
            string country = "ZAR";
            Tuple<string, double> expectedBaseCurrency = new Tuple<string, double>(country, 10.0);
            CurrencyInfo newCurrency = new CurrencyInfo();
            newCurrency.baseCurrency = new Tuple<string, double>("ZAR", 10.0);

            Assert.AreEqual(expectedBaseCurrency, newCurrency.baseCurrency);

            Tuple<string, double> notExpectedBaseCurrency = new Tuple<string, double>("RAZ", 10.0);

            Assert.AreNotEqual(notExpectedBaseCurrency, newCurrency.baseCurrency);
        }

        [TestMethod]
        public void CurrencyCurrencyConverted_SetConvertedCurrency_CurrencyInfo()
        {
            string country = "USD";
            Tuple<string, double> expectedConvertedCurrency = new Tuple<string, double>(country, 20.0);
            CurrencyInfo newCurrency = new CurrencyInfo();
            newCurrency.convertedCurrency = new Tuple<string, double>("USD", 20.0);

            Assert.AreEqual(expectedConvertedCurrency, newCurrency.convertedCurrency);

            Tuple<string, double> notExpectedConvertedCurrency = new Tuple<string, double>("DSU", 20.0);

            Assert.AreNotEqual(notExpectedConvertedCurrency, newCurrency.convertedCurrency);
        }

        // method tests
        [TestMethod]
        public async Task ExchangeRateApiCall_GetRequest_Json()
        {
            CurrencyInfo postData = new CurrencyInfo
            {
                baseCurrency = new Tuple<string, double>("USD", 1),
                convertedCurrency = new Tuple<string, double>("ZAR", 0)
            };
            HttpResponseMessage response = await CurrencyInfo.GetExchangeRates(postData);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, "API request failed with status code: " + response.StatusCode);
            Assert.AreEqual("application/json", response.Content.Headers.ContentType.MediaType, "Unexpected content type.");

        }


        [TestMethod]
        public async Task CurrencyInfoResult_ApiResponseIntoCurrencyInfo_CurrencyInfo()
        {
            CurrencyInfo postData = new CurrencyInfo
            {
                baseCurrency = new Tuple<string, double>("USD", 1),
                convertedCurrency = new Tuple<string, double>("ZAR", 0)
            };

            CurrencyInfo newObj = await CurrencyInfo.CurrencyInfoResult(postData);

            Assert.AreEqual(postData.baseCurrency, newObj.baseCurrency);
            Assert.AreEqual(postData.convertedCurrency, newObj.convertedCurrency);

            CurrencyInfo notPostData = new CurrencyInfo
            {
                baseCurrency = new Tuple<string, double>("DSU", 1),
                convertedCurrency = new Tuple<string, double>("RAZ", 0)
            };

            Assert.AreNotEqual(notPostData.baseCurrency, newObj.baseCurrency);
            Assert.AreNotEqual(notPostData.convertedCurrency, newObj.convertedCurrency);

        }


    }
}
