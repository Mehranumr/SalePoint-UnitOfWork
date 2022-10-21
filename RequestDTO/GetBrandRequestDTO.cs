
using System.Text.Json.Serialization;

namespace salepoint.RequestDTO
{
    public class GetBrandRequestDTO
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }
    }
}