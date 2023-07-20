using System.Text.Json;
using System.Text.Json.Serialization;

namespace KoboldSharp
{
    public class GenParams
    {
        [JsonPropertyName("prompt")]
        public string Prompt { get; set; }
        [JsonPropertyName("n")]
        public int N { get; set; }
        [JsonPropertyName("max_context_length")]
        public int MaxContextLength { get; set; }
        [JsonPropertyName("max_length")]
        public int MaxLength { get; set; }
        [JsonPropertyName("rep_pen")]
        public float RepPen { get; set; }
        [JsonPropertyName("temperature")]
        public float Temperature { get; set; }
        [JsonPropertyName("top_p")]
        public float TopP { get; set; }
        [JsonPropertyName("top_k")]
        public float TopK { get; set; }
        [JsonPropertyName("top_a")]
        public float TopA { get; set; }
        [JsonPropertyName("typical")]
        public float Typical { get; set; }
        [JsonPropertyName("tfs")]
        public float Tfs { get; set; }
        [JsonPropertyName("rep_pen_range")]
        public int RepPenRange { get; set; }
        [JsonPropertyName("rep_pen_slope")]
        public float RepPenSlope { get; set; }
        [JsonPropertyName("sample_order")]
        public List<int> SamplerOrder { get; set; }
        [JsonPropertyName("quiet")]
        public bool Quiet { get; set; }

        public GenParams(string prompt = "", int n = 1, int maxContextLength = 2048, int maxLength = 80, float repPen = 1.1f, float temperature = 0.59f, float topP = 1f, float topK = 0f, float topA = 0f, float typical = 1f, float tfs = 0.87f, int repPenRange = 2048, float repPenSlope = 0.3f, List<int> samplerOrder = null, bool quiet = true)
        {
            Prompt = prompt;
            N = n;
            MaxContextLength = maxContextLength;
            MaxLength = maxLength;
            RepPen = repPen;
            Temperature = temperature;
            TopP = topP;
            TopK = topK;
            TopA = topA;
            Typical = typical;
            Tfs = tfs;
            RepPenRange = repPenRange;
            RepPenSlope = repPenSlope;
            SamplerOrder = samplerOrder ?? new List<int> { 5, 0, 2, 3, 1, 4, 6 };
            Quiet = quiet;
        }

        public string GetJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
