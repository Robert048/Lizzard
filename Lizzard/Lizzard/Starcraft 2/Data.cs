using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lizzard.Starcraft_2
{
    class Data
    {
    }


    public class Portrait
    {
        public int x { get; set; }
        public int y { get; set; }
        public int w { get; set; }
        public int h { get; set; }
        public int offset { get; set; }
        public string url { get; set; }
    }

    public class Career
    {
        public string primaryRace { get; set; }
        public int terranWins { get; set; }
        public int protossWins { get; set; }
        public int zergWins { get; set; }
        public string highest1v1Rank { get; set; }
        public string highestTeamRank { get; set; }
        public int seasonTotalGames { get; set; }
        public int careerTotalGames { get; set; }
    }

    public class Terran
    {
        public int level { get; set; }
        public int totalLevelXP { get; set; }
        public int currentLevelXP { get; set; }
    }

    public class Zerg
    {
        public int level { get; set; }
        public int totalLevelXP { get; set; }
        public int currentLevelXP { get; set; }
    }

    public class Protoss
    {
        public int level { get; set; }
        public int totalLevelXP { get; set; }
        public int currentLevelXP { get; set; }
    }

    public class SwarmLevels
    {
        public int level { get; set; }
        public Terran terran { get; set; }
        public Zerg zerg { get; set; }
        public Protoss protoss { get; set; }
    }

    public class Campaign
    {
    }

    public class Season
    {
        public int seasonId { get; set; }
        public int seasonNumber { get; set; }
        public int seasonYear { get; set; }
        public int totalGamesThisSeason { get; set; }
    }

    public class Rewards
    {
        public List<object> selected { get; set; }
        public List<object> earned { get; set; }
    }

    public class CategoryPoints
    {
        public int __invalid_name__4330138 { get; set; }
        public int __invalid_name__4386911 { get; set; }
        public int __invalid_name__4364473 { get; set; }
        public int __invalid_name__4325379 { get; set; }
        public int __invalid_name__4325410 { get; set; }
        public int __invalid_name__4325377 { get; set; }
    }

    public class Points
    {
        public int totalPoints { get; set; }
        public CategoryPoints categoryPoints { get; set; }
    }

    public class Achievement
    {
        public object achievementId { get; set; }
        public int completionDate { get; set; }
    }

    public class Achievements
    {
        public Points points { get; set; }
        public List<Achievement> achievements { get; set; }
    }

    public class RootObjectProfile
    {
        public int id { get; set; }
        public int realm { get; set; }
        public string displayName { get; set; }
        public string clanName { get; set; }
        public string clanTag { get; set; }
        public string profilePath { get; set; }
        public Portrait portrait { get; set; }
        public Career career { get; set; }
        public SwarmLevels swarmLevels { get; set; }
        public Campaign campaign { get; set; }
        public Season season { get; set; }
        public Rewards rewards { get; set; }
        public Achievements achievements { get; set; }
    }

}
