using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CurrencyApi.Models;
using Newtonsoft.Json;
using System;


namespace CurrencyApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CurrencyApiController : ControllerBase
{


    [HttpGet(Name = "test")]
    public CurrencyInfo Get()
    {
        CurrencyInfo newObj = new CurrencyInfo();
        newObj.baseCurrency = new Tuple<string, double>("ZAR", 10);
        newObj.convertedCurrency = new Tuple<string, double>("USD", 1);
        return newObj;
    }

    [HttpPost(Name = "GetExchangeRate")]
    public async Task<ActionResult<CurrencyInfo>> Post([FromBody] CurrencyInfo postData)
    {

        CurrencyInfo newObj = await CurrencyInfo.CurrencyInfoResult(postData);

        return newObj;

    }

}
