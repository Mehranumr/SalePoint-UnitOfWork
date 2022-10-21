using System.Text.Json;

namespace salepoint.APICommand
{
    public class APIRequest
    {
        public string methodId { get; set; }
        public JsonElement data { get; set; }
        public string signature { get; set; }
    }
}