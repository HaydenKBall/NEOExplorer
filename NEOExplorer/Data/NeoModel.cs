namespace NEOExplorer.Data
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public partial class NeoModel
    {
        [JsonProperty("links")]
        public NeoLinks? Links { get; set; }

        [JsonProperty("page")]
        public Page? Page { get; set; }

        [JsonProperty("near_earth_objects")]
        public List<NearEarthObject>? NearEarthObjects { get; set; }
    }

    public partial class NeoLinks
    {
        [JsonProperty("next")]
        public Uri? Next { get; set; }

        [JsonProperty("self")]
        public Uri? Self { get; set; }
    }

    public partial class NearEarthObject
    {
        [JsonProperty("links")] public NearEarthObjectLinks? Links { get; set; }

        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("neo_reference_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long NeoReferenceId { get; set; }

        [JsonProperty("name")] public string? Name { get; set; }

        [JsonProperty("name_limited")] public string? NameLimited { get; set; }

        [JsonProperty("designation")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Designation { get; set; }

        [JsonProperty("nasa_jpl_url")] public Uri? NasaJplUrl { get; set; }

        [JsonProperty("absolute_magnitude_h")] public double AbsoluteMagnitudeH { get; set; }

        [JsonProperty("estimated_diameter")] public EstimatedDiameter? EstimatedDiameter { get; set; }

        [JsonProperty("is_potentially_hazardous_asteroid")]
        public bool IsPotentiallyHazardousAsteroid { get; set; }

        [JsonProperty("close_approach_data")] public List<CloseApproachDatum> CloseApproachData { get; set; }

        [JsonProperty("orbital_data")] public OrbitalData? OrbitalData { get; set; }

        [JsonProperty("is_sentry_object")] public bool IsSentryObject { get; set; }

        [JsonIgnore]
        public CloseApproachDatum ClosestApproachToToday
        {
            get
            {
                var today = DateTime.Now;

                var closestToToday = CloseApproachData.OrderBy(x => Math.Abs((x.CloseApproachDate - today).Ticks)).First();

                return closestToToday;
            }
        }

        [JsonIgnore]
        public double RelativeVelocityFromClosestApproachToToday => double.Parse(ClosestApproachToToday.RelativeVelocity?.MilesPerHour);
    }

    public partial class CloseApproachDatum
    {
        [JsonProperty("close_approach_date")]
        public DateTimeOffset CloseApproachDate { get; set; }

        [JsonProperty("close_approach_date_full")]
        public string? CloseApproachDateFull { get; set; }

        [JsonProperty("epoch_date_close_approach")]
        public long EpochDateCloseApproach { get; set; }

        [JsonProperty("relative_velocity")]
        public RelativeVelocity? RelativeVelocity { get; set; }

        [JsonProperty("miss_distance")]
        public MissDistance? MissDistance { get; set; }

        [JsonProperty("orbiting_body")]
        public OrbitingBody OrbitingBody { get; set; }
    }

    public partial class MissDistance
    {
        [JsonProperty("astronomical")]
        public string? Astronomical { get; set; }

        [JsonProperty("lunar")]
        public string? Lunar { get; set; }

        [JsonProperty("kilometers")]
        public string? Kilometers { get; set; }

        [JsonProperty("miles")]
        public string? Miles { get; set; }
    }

    public partial class RelativeVelocity
    {
        [JsonProperty("kilometers_per_second")]
        public string? KilometersPerSecond { get; set; }

        [JsonProperty("kilometers_per_hour")]
        public string? KilometersPerHour { get; set; }

        [JsonProperty("miles_per_hour")]
        public string? MilesPerHour { get; set; }
    }

    public partial class EstimatedDiameter
    {
        [JsonProperty("kilometers")]
        public Feet? Kilometers { get; set; }

        [JsonProperty("meters")]
        public Feet? Meters { get; set; }

        [JsonProperty("miles")]
        public Feet? Miles { get; set; }

        [JsonProperty("feet")]
        public Feet? Feet { get; set; }
    }

    public partial class Feet
    {
        [JsonProperty("estimated_diameter_min")]
        public double EstimatedDiameterMin { get; set; }

        [JsonProperty("estimated_diameter_max")]
        public double EstimatedDiameterMax { get; set; }
    }

    public partial class NearEarthObjectLinks
    {
        [JsonProperty("self")]
        public Uri? Self { get; set; }
    }

    public partial class OrbitalData
    {
        [JsonProperty("orbit_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long OrbitId { get; set; }

        [JsonProperty("orbit_determination_date")]
        public DateTimeOffset OrbitDeterminationDate { get; set; }

        [JsonProperty("first_observation_date")]
        public DateTimeOffset FirstObservationDate { get; set; }

        [JsonProperty("last_observation_date")]
        public DateTimeOffset LastObservationDate { get; set; }

        [JsonProperty("data_arc_in_days")]
        public long DataArcInDays { get; set; }

        [JsonProperty("observations_used")]
        public long ObservationsUsed { get; set; }

        [JsonProperty("orbit_uncertainty")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long OrbitUncertainty { get; set; }

        [JsonProperty("minimum_orbit_intersection")]
        public string? MinimumOrbitIntersection { get; set; }

        [JsonProperty("jupiter_tisserand_invariant")]
        public string? JupiterTisserandInvariant { get; set; }

        [JsonProperty("epoch_osculation")]
        public string? EpochOsculation { get; set; }

        [JsonProperty("eccentricity")]
        public string? Eccentricity { get; set; }

        [JsonProperty("semi_major_axis")]
        public string? SemiMajorAxis { get; set; }

        [JsonProperty("inclination")]
        public string? Inclination { get; set; }

        [JsonProperty("ascending_node_longitude")]
        public string? AscendingNodeLongitude { get; set; }

        [JsonProperty("orbital_period")]
        public string? OrbitalPeriod { get; set; }

        [JsonProperty("perihelion_distance")]
        public string? PerihelionDistance { get; set; }

        [JsonProperty("perihelion_argument")]
        public string? PerihelionArgument { get; set; }

        [JsonProperty("aphelion_distance")]
        public string? AphelionDistance { get; set; }

        [JsonProperty("perihelion_time")]
        public string? PerihelionTime { get; set; }

        [JsonProperty("mean_anomaly")]
        public string? MeanAnomaly { get; set; }

        [JsonProperty("mean_motion")]
        public string? MeanMotion { get; set; }

        [JsonProperty("equinox")]
        public Equinox Equinox { get; set; }

        [JsonProperty("orbit_class")]
        public OrbitClass? OrbitClass { get; set; }
    }

    public partial class OrbitClass
    {
        [JsonProperty("orbit_class_type")]
        public OrbitClassType OrbitClassType { get; set; }

        [JsonProperty("orbit_class_description")]
        public string? OrbitClassDescription { get; set; }

        [JsonProperty("orbit_class_range")]
        public OrbitClassRange OrbitClassRange { get; set; }
    }

    public partial class Page
    {
        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("total_elements")]
        public long TotalElements { get; set; }

        [JsonProperty("total_pages")]
        public long TotalPages { get; set; }

        [JsonProperty("number")]
        public long Number { get; set; }
    }

    public enum OrbitingBody { Earth, Juptr, Mars, Merc, Venus };

    public enum Equinox { J2000 };

    public enum OrbitClassRange { ASemiMajorAxis10AuQPerihelion1017Au, The1017AuQPerihelion13Au };

    public enum OrbitClassType { Amo, Apo };

    internal class OrbitingBodyConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(OrbitingBody) || t == typeof(OrbitingBody?);

        public override object? ReadJson(JsonReader reader, Type t, object? existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Earth":
                    return OrbitingBody.Earth;
                case "Juptr":
                    return OrbitingBody.Juptr;
                case "Mars":
                    return OrbitingBody.Mars;
                case "Merc":
                    return OrbitingBody.Merc;
                case "Venus":
                    return OrbitingBody.Venus;
            }
            throw new Exception("Cannot unmarshal type OrbitingBody");
        }

        public override void WriteJson(JsonWriter writer, object? untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (OrbitingBody)untypedValue;
            switch (value)
            {
                case OrbitingBody.Earth:
                    serializer.Serialize(writer, "Earth");
                    return;
                case OrbitingBody.Juptr:
                    serializer.Serialize(writer, "Juptr");
                    return;
                case OrbitingBody.Mars:
                    serializer.Serialize(writer, "Mars");
                    return;
                case OrbitingBody.Merc:
                    serializer.Serialize(writer, "Merc");
                    return;
                case OrbitingBody.Venus:
                    serializer.Serialize(writer, "Venus");
                    return;
            }
            throw new Exception("Cannot marshal type OrbitingBody");
        }

        public static readonly OrbitingBodyConverter Singleton = new OrbitingBodyConverter();
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object? ReadJson(JsonReader reader, Type t, object? existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object? untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class EquinoxConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Equinox) || t == typeof(Equinox?);

        public override object? ReadJson(JsonReader reader, Type t, object? existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "J2000")
            {
                return Equinox.J2000;
            }
            throw new Exception("Cannot unmarshal type Equinox");
        }

        public override void WriteJson(JsonWriter writer, object? untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Equinox)untypedValue;
            if (value == Equinox.J2000)
            {
                serializer.Serialize(writer, "J2000");
                return;
            }
            throw new Exception("Cannot marshal type Equinox");
        }

        public static readonly EquinoxConverter Singleton = new EquinoxConverter();
    }

    internal class OrbitClassRangeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(OrbitClassRange) || t == typeof(OrbitClassRange?);

        public override object? ReadJson(JsonReader reader, Type t, object? existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "1.017 AU < q (perihelion) < 1.3 AU":
                    return OrbitClassRange.The1017AuQPerihelion13Au;
                case "a (semi-major axis) > 1.0 AU; q (perihelion) < 1.017 AU":
                    return OrbitClassRange.ASemiMajorAxis10AuQPerihelion1017Au;
            }
            throw new Exception("Cannot unmarshal type OrbitClassRange");
        }

        public override void WriteJson(JsonWriter writer, object? untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (OrbitClassRange)untypedValue;
            switch (value)
            {
                case OrbitClassRange.The1017AuQPerihelion13Au:
                    serializer.Serialize(writer, "1.017 AU < q (perihelion) < 1.3 AU");
                    return;
                case OrbitClassRange.ASemiMajorAxis10AuQPerihelion1017Au:
                    serializer.Serialize(writer, "a (semi-major axis) > 1.0 AU; q (perihelion) < 1.017 AU");
                    return;
            }
            throw new Exception("Cannot marshal type OrbitClassRange");
        }

        public static readonly OrbitClassRangeConverter Singleton = new OrbitClassRangeConverter();
    }

    internal class OrbitClassTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(OrbitClassType) || t == typeof(OrbitClassType?);

        public override object? ReadJson(JsonReader reader, Type t, object? existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "AMO":
                    return OrbitClassType.Amo;
                case "APO":
                    return OrbitClassType.Apo;
            }
            throw new Exception("Cannot unmarshal type OrbitClassType");
        }

        public override void WriteJson(JsonWriter writer, object? untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (OrbitClassType)untypedValue;
            switch (value)
            {
                case OrbitClassType.Amo:
                    serializer.Serialize(writer, "AMO");
                    return;
                case OrbitClassType.Apo:
                    serializer.Serialize(writer, "APO");
                    return;
            }
            throw new Exception("Cannot marshal type OrbitClassType");
        }

        public static readonly OrbitClassTypeConverter Singleton = new OrbitClassTypeConverter();
    }
}
