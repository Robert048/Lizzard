using System.Collections.Generic;

namespace Lizzard.Heroes_of_the_Storm
{
    public class LeaderboardRanking
    {
        public string GameMode { get; set; }
        public int? LeagueID { get; set; }
        public int? LeagueRank { get; set; }
        public int CurrentMMR { get; set; }
    }

    public class RootObject
    {
        public int PlayerID { get; set; }
        public string Name { get; set; }
        public List<LeaderboardRanking> LeaderboardRankings { get; set; }
    }

    public class Map
    {
        public string PrimaryName { get; set; }
        public string ImageURL { get; set; }
    }

    public class Hero
    {
        public string PrimaryName { get; set; }
        public string ImageURL { get; set; }
        public string AttributeName { get; set; }
        public string Group { get; set; }
        public string SubGroup { get; set; }
    }
}
