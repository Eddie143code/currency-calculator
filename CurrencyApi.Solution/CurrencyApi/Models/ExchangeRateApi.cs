
namespace CurrencyApi.Models
{
    public class ExchangeRateResponse
    {
        public string? Provider { get; set; }
        public string? WarningUpgradeToV6 { get; set; }
        public string? Terms { get; set; }
        public string? Base { get; set; }
        public string? Date { get; set; }
        public int? TimeLastUpdated { get; set; }
        public Dictionary<string, double>? Rates { get; set; }
    }
}
