using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace cwApi1.Models
{
    public class Companies
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("identifier")]
        public string? Identifier { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        public override string ToString() => JsonSerializer.Serialize(this);

    }
}
