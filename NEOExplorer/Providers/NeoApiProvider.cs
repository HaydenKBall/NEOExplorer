using System.Globalization;
using Newtonsoft.Json;
using NEOExplorer.Data;
using Newtonsoft.Json.Converters;

namespace NEOExplorer.Providers
{
    public static class NeoApiProvider
    {
        public static async Task<NeoModel?> GetNeoApiAsync()
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://api.nasa.gov");

            HttpResponseMessage jsonResponse =
                await client.GetAsync("/neo/rest/v1/neo/browse?api_key=3d7JZbzO1KkLSCypryTAE0I4Rvf3mfgTsTq0FywH");

            jsonResponse.EnsureSuccessStatusCode();

            string stringResponse = await jsonResponse.Content.ReadAsStringAsync();

            NeoModel? neoModel = FromJson(stringResponse);

            return neoModel;
        }

        public static async Task<List<NearEarthObject>?> GetNearEarthObjects()
        {
            var data = await GetNeoApiAsync();

            if (data.NearEarthObjects is { Count: > 0 })
            {
                return data.NearEarthObjects;
            }

            return null;
        }

        public static NeoModel? FromJson(string json) => JsonConvert.DeserializeObject<NeoModel>(json, Converter.Settings);

        //public static string ToJson(this NeoModel self) => JsonConvert.SerializeObject(self, Converter.Settings);

        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
                {
                    OrbitingBodyConverter.Singleton,
                    EquinoxConverter.Singleton,
                    OrbitClassRangeConverter.Singleton,
                    OrbitClassTypeConverter.Singleton,
                    new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
                },
            };
        }
    }
}
