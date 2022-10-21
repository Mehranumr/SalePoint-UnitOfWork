
using System.Text.Json.Serialization;

namespace salepoint.RequestDTO
{
    public class AddBrandRequestDTO
    {
        [JsonPropertyName("brandName")]
        public string BrandName { get; set; }
    }
}