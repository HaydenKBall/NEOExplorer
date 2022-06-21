using Newtonsoft.Json;

namespace NEOExplorer.Data
{
    public class Player
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("match_dates")]
        public List<Match> Matches { get; set; }

        public string IdAndName => Id + Name;

        public Match TodaysMatch
        {
            get
            {
                var todayDay = DateTime.Now.Day;
                return Matches.Single(x => x.StarDate.Day == todayDay);
            }
        }

        public string TodaysMatchsLocation => TodaysMatch.Location;

    }

    public class Match
    {
        public DateTime StarDate { get; set; }

        public string Location { get; set; }
    }
}
