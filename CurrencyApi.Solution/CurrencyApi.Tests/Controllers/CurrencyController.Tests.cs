using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyApi.Controllers;
using CurrencyApi.Models;

namespace CurrencyApi.Tests.Controllers
{
    [TestClass]
    public class CurrencyApiTests
    {
        static readonly HttpClient client = new HttpClient();

        [TestMethod]
        public async Task Post_CurrencyInfoResult_currencyInfo()
        {
            var controller = new CurrencyApiController();
            var postData = new CurrencyInfo
            {
                baseCurrency = new Tuple<string, double>("USD", 1), // Set the base currency
                convertedCurrency = new Tuple<string, double>("EUR", 10), // Set the converted currency
                convertedAmount = 0,
                CurrencyList = new List<Tuple<string, double>>() // Initialize an empty list
            };


            var result = await controller.Post(postData);
            var newObj = result.Value;

            Assert.IsNotNull(newObj);
            Assert.IsInstanceOfType(newObj, typeof(CurrencyInfo));
        }
    }
}
