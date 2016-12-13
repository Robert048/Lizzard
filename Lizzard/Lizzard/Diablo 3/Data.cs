using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lizzard.Diablo_3
{
    class Data
    {

    }

    
public class Kills
{
    public int elites { get; set; }
}

public class Hero
{
    public int id { get; set; }
    public string name { get; set; }
    public string @class { get; set; }
    public int gender { get; set; }
    public int level { get; set; }
    public Kills kills { get; set; }
    public int paragonLevel { get; set; }
    public bool hardcore { get; set; }
    public bool seasonal { get; set; }
    public bool dead { get; set; }
    public int lastupdated { get; set; }
    public string icon { get; set; }
}

public class Kills2
{
    public int monsters { get; set; }
    public int elites { get; set; }
    public int hardcoreMonsters { get; set; }
}

public class TimePlayed
{
    public double barbarian { get; set; }
    public double crusader { get; set; }
    [JsonProperty("demon-hunter")]
    public double demonhunter { get; set; }
    public double monk { get; set; }
    [JsonProperty("witch-doctor")]
    public double witchdoctor { get; set; }
    public double wizard { get; set; }
}

public class Progression
{
    public bool act1 { get; set; }
    public bool act2 { get; set; }
    public bool act3 { get; set; }
    public bool act4 { get; set; }
    public bool act5 { get; set; }
}

public class Blacksmith
{
    public string slug { get; set; }
    public int level { get; set; }
    public int stepCurrent { get; set; }
    public int stepMax { get; set; }
}

public class Jeweler
{
    public string slug { get; set; }
    public int level { get; set; }
    public int stepCurrent { get; set; }
    public int stepMax { get; set; }
}

public class Mystic
{
    public string slug { get; set; }
    public int level { get; set; }
    public int stepCurrent { get; set; }
    public int stepMax { get; set; }
}

public class BlacksmithHardcore
{
    public string slug { get; set; }
    public int level { get; set; }
    public int stepCurrent { get; set; }
    public int stepMax { get; set; }
}

public class JewelerHardcore
{
    public string slug { get; set; }
    public int level { get; set; }
    public int stepCurrent { get; set; }
    public int stepMax { get; set; }
}

public class MysticHardcore
{
    public string slug { get; set; }
    public int level { get; set; }
    public int stepCurrent { get; set; }
    public int stepMax { get; set; }
}

public class BlacksmithSeasonHardcore
{
    public string slug { get; set; }
    public int level { get; set; }
    public int stepCurrent { get; set; }
    public int stepMax { get; set; }
}

public class JewelerSeasonHardcore
{
    public string slug { get; set; }
    public int level { get; set; }
    public int stepCurrent { get; set; }
    public int stepMax { get; set; }
}

public class MysticSeasonHardcore
{
    public string slug { get; set; }
    public int level { get; set; }
    public int stepCurrent { get; set; }
    public int stepMax { get; set; }
}

public class Kills3
{
    public int monsters { get; set; }
    public int elites { get; set; }
    public int hardcoreMonsters { get; set; }
}

public class TimePlayed2
{
    public double barbarian { get; set; }
    public double crusader { get; set; }
    [JsonProperty("demon-hunter")]
    public double demonhunter { get; set; }
    public double monk { get; set; }
    [JsonProperty("witch-doctor")]
    public double witchdoctor { get; set; }
    public double wizard { get; set; }
}

public class Progression2
{
    public bool act1 { get; set; }
    public bool act2 { get; set; }
    public bool act3 { get; set; }
    public bool act4 { get; set; }
    public bool act5 { get; set; }
}

public class Season4
{
    public int seasonId { get; set; }
    public int paragonLevel { get; set; }
    public int paragonLevelHardcore { get; set; }
    public Kills3 kills { get; set; }
    public TimePlayed2 timePlayed { get; set; }
    public int highestHardcoreLevel { get; set; }
    public Progression2 progression { get; set; }
}

public class Kills4
{
    public int monsters { get; set; }
    public int elites { get; set; }
    public int hardcoreMonsters { get; set; }
}

public class TimePlayed3
{
    public double barbarian { get; set; }
    public double crusader { get; set; }
    [JsonProperty("demon-hunter")]
    public double demonhunter { get; set; }
    public double monk { get; set; }
    [JsonProperty("witch-doctor")]
    public double witchdoctor { get; set; }
    public double wizard { get; set; }
}

public class Progression3
{
    public bool act1 { get; set; }
    public bool act2 { get; set; }
    public bool act3 { get; set; }
    public bool act4 { get; set; }
    public bool act5 { get; set; }
}

public class Season3
{
    public int seasonId { get; set; }
    public int paragonLevel { get; set; }
    public int paragonLevelHardcore { get; set; }
    public Kills4 kills { get; set; }
    public TimePlayed3 timePlayed { get; set; }
    public int highestHardcoreLevel { get; set; }
    public Progression3 progression { get; set; }
}

public class Kills5
{
    public int monsters { get; set; }
    public int elites { get; set; }
    public int hardcoreMonsters { get; set; }
}

public class TimePlayed4
{
    public double barbarian { get; set; }
    public double crusader { get; set; }
    [JsonProperty("demon-hunter")]
    public double demonhunter { get; set; }
    public double monk { get; set; }
    [JsonProperty("witch-doctor")]
    public double witchdoctor { get; set; }
    public double wizard { get; set; }
}

public class Progression4
{
    public bool act1 { get; set; }
    public bool act2 { get; set; }
    public bool act3 { get; set; }
    public bool act4 { get; set; }
    public bool act5 { get; set; }
}

public class Season5
{
    public int seasonId { get; set; }
    public int paragonLevel { get; set; }
    public int paragonLevelHardcore { get; set; }
    public Kills5 kills { get; set; }
    public TimePlayed4 timePlayed { get; set; }
    public int highestHardcoreLevel { get; set; }
    public Progression4 progression { get; set; }
}

public class Kills6
{
    public int monsters { get; set; }
    public int elites { get; set; }
    public int hardcoreMonsters { get; set; }
}

public class TimePlayed5
{
    public double barbarian { get; set; }
    public double crusader { get; set; }
    [JsonProperty("demon-hunter")]
    public double demonhunter { get; set; }
    public double monk { get; set; }
    [JsonProperty("witch-doctor")]
    public double witchdoctor { get; set; }
    public double wizard { get; set; }
}

public class Progression5
{
    public bool act1 { get; set; }
    public bool act2 { get; set; }
    public bool act3 { get; set; }
    public bool act4 { get; set; }
    public bool act5 { get; set; }
}

public class Season0
{
    public int seasonId { get; set; }
    public int paragonLevel { get; set; }
    public int paragonLevelHardcore { get; set; }
    public Kills6 kills { get; set; }
    public TimePlayed5 timePlayed { get; set; }
    public int highestHardcoreLevel { get; set; }
    public Progression5 progression { get; set; }
}

public class Kills7
{
    public int monsters { get; set; }
    public int elites { get; set; }
    public int hardcoreMonsters { get; set; }
}

public class TimePlayed6
{
    public double barbarian { get; set; }
    public double crusader { get; set; }
    [JsonProperty("demon-hunter")]
    public double demonhunter { get; set; }
    public double monk { get; set; }
    [JsonProperty("witch-doctor")]
    public double witchdoctor { get; set; }
    public double wizard { get; set; }
}

public class Progression6
{
    public bool act1 { get; set; }
    public bool act2 { get; set; }
    public bool act3 { get; set; }
    public bool act4 { get; set; }
    public bool act5 { get; set; }
}

public class Season1
{
    public int seasonId { get; set; }
    public int paragonLevel { get; set; }
    public int paragonLevelHardcore { get; set; }
    public Kills7 kills { get; set; }
    public TimePlayed6 timePlayed { get; set; }
    public int highestHardcoreLevel { get; set; }
    public Progression6 progression { get; set; }
}

public class Kills8
{
    public int monsters { get; set; }
    public int elites { get; set; }
    public int hardcoreMonsters { get; set; }
}

public class TimePlayed7
{
    public double barbarian { get; set; }
    public double crusader { get; set; }
    [JsonProperty("demon-hunter")]
    public double demonhunter { get; set; }
    public double monk { get; set; }
    [JsonProperty("witch-doctor")]
    public double witchdoctor { get; set; }
    public double wizard { get; set; }
}

public class Progression7
{
    public bool act1 { get; set; }
    public bool act2 { get; set; }
    public bool act3 { get; set; }
    public bool act4 { get; set; }
    public bool act5 { get; set; }
}

public class Season2
{
    public int seasonId { get; set; }
    public int paragonLevel { get; set; }
    public int paragonLevelHardcore { get; set; }
    public Kills8 kills { get; set; }
    public TimePlayed7 timePlayed { get; set; }
    public int highestHardcoreLevel { get; set; }
    public Progression7 progression { get; set; }
}

public class SeasonalProfiles
{
    public Season4 season4 { get; set; }
    public Season3 season3 { get; set; }
    public Season5 season5 { get; set; }
    public Season0 season0 { get; set; }
    public Season1 season1 { get; set; }
    public Season2 season2 { get; set; }
}

public class RootObjectProfile
{
    public string battleTag { get; set; }
    public int paragonLevel { get; set; }
    public int paragonLevelHardcore { get; set; }
    public int paragonLevelSeason { get; set; }
    public int paragonLevelSeasonHardcore { get; set; }
    public string guildName { get; set; }
    public List<Hero> heroes { get; set; }
    public int lastHeroPlayed { get; set; }
    public int lastUpdated { get; set; }
    public Kills2 kills { get; set; }
    public int highestHardcoreLevel { get; set; }
    public TimePlayed timePlayed { get; set; }
    public Progression progression { get; set; }
    public List<object> fallenHeroes { get; set; }
    public Blacksmith blacksmith { get; set; }
    public Jeweler jeweler { get; set; }
    public Mystic mystic { get; set; }
    public BlacksmithHardcore blacksmithHardcore { get; set; }
    public JewelerHardcore jewelerHardcore { get; set; }
    public MysticHardcore mysticHardcore { get; set; }
    public BlacksmithSeasonHardcore blacksmithSeasonHardcore { get; set; }
    public JewelerSeasonHardcore jewelerSeasonHardcore { get; set; }
    public MysticSeasonHardcore mysticSeasonHardcore { get; set; }
    public SeasonalProfiles seasonalProfiles { get; set; }
}



}
