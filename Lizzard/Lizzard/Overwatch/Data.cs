using System.Collections.Generic;

namespace Lizzard.Overwatch
{
    public class Quick
    {
        public string wins { get; set; }
    }

    public class Competitive
    {
        public string wins { get; set; }
        public int lost { get; set; }
        public string played { get; set; }
    }

    public class Games
    {
        public Quick quick { get; set; }
        public Competitive competitive { get; set; }
    }

    public class Playtime
    {
        public string quick { get; set; }
        public string competitive { get; set; }
    }

    public class Competitive2
    {
        public object rank { get; set; }
    }

    public class DataProfile
    {
        public string username { get; set; }
        public int level { get; set; }
        public Games games { get; set; }
        public Playtime playtime { get; set; }
        public string avatar { get; set; }
        public Competitive2 competitive { get; set; }
        public string levelFrame { get; set; }
        public string star { get; set; }
    }

    public class RootObjectProfile
    {
        public DataProfile data { get; set; }
    }

    public class Achievement
    {
        public string name { get; set; }
        public bool finished { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public object category { get; set; }
    }

    public class RootObjectAchievements
    {
        public int totalNumberOfAchievements { get; set; }
        public int numberOfAchievementsCompleted { get; set; }
        public string finishedAchievements { get; set; }
        public List<Achievement> achievements { get; set; }
    }

    public class Hero
    {
        public string name { get; set; }
        public string playtime { get; set; }
        public string image { get; set; }
        public double percentage { get; set; }
        public double eliminations { get; set; }
        public double damage { get; set; }
        public double kdratio { get; set; }
        public string accuracy { get; set; }
        public string objTime { get; set; }

    }
}
