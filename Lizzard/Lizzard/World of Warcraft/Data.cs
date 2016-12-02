using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lizzard.World_of_Warcraft
{
    class Data
    {
    }

    public class CharacterInformation
    {
        public long lastModified { get; set; }
        public string name { get; set; }
        public string realm { get; set; }
        public string battlegroup { get; set; }
        public int @class { get; set; }
        public int race { get; set; }
        public int gender { get; set; }
        public int level { get; set; }
        public int achievementPoints { get; set; }
        public string thumbnail { get; set; }
        public string calcClass { get; set; }
        public int faction { get; set; }
        public int totalHonorableKills { get; set; }
    }

    public class Criterion
    {
        public int id { get; set; }
        public string description { get; set; }
        public int orderIndex { get; set; }
        public int max { get; set; }
    }

    public class Achievement
    {
        public int id { get; set; }
        public string title { get; set; }
        public int points { get; set; }
        public string description { get; set; }
        public List<object> rewardItems { get; set; }
        public string icon { get; set; }
        public List<Criterion> criteria { get; set; }
        public bool accountWide { get; set; }
        public int factionId { get; set; }
        public string reward { get; set; }
    }

    public class Criteria
    {
        public int id { get; set; }
        public string description { get; set; }
        public int orderIndex { get; set; }
        public int max { get; set; }
    }

    public class Feed
    {
        public string type { get; set; }
        public object timestamp { get; set; }
        public int itemId { get; set; }
        public string context { get; set; }
        public List<object> bonusLists { get; set; }
        public Achievement achievement { get; set; }
        public bool? featOfStrength { get; set; }
        public Criteria criteria { get; set; }
        public int? quantity { get; set; }
        public string name { get; set; }
    }

    public class RootObjectFeed
    {
        public long lastModified { get; set; }
        public string name { get; set; }
        public string realm { get; set; }
        public string battlegroup { get; set; }
        public int @class { get; set; }
        public int race { get; set; }
        public int gender { get; set; }
        public int level { get; set; }
        public int achievementPoints { get; set; }
        public string thumbnail { get; set; }
        public string calcClass { get; set; }
        public int faction { get; set; }
        public List<Feed> feed { get; set; }
        public int totalHonorableKills { get; set; }
    }


    public class Stats
    {
        public int health { get; set; }
        public string powerType { get; set; }
        public int power { get; set; }
        public int str { get; set; }
        public int agi { get; set; }
        public int @int { get; set; }
        public int sta { get; set; }
        public double speedRating { get; set; }
        public double speedRatingBonus { get; set; }
        public double crit { get; set; }
        public int critRating { get; set; }
        public double haste { get; set; }
        public int hasteRating { get; set; }
        public double hasteRatingPercent { get; set; }
        public double mastery { get; set; }
        public int masteryRating { get; set; }
        public double leech { get; set; }
        public double leechRating { get; set; }
        public double leechRatingBonus { get; set; }
        public int versatility { get; set; }
        public double versatilityDamageDoneBonus { get; set; }
        public double versatilityHealingDoneBonus { get; set; }
        public double versatilityDamageTakenBonus { get; set; }
        public double avoidanceRating { get; set; }
        public double avoidanceRatingBonus { get; set; }
        public int spellPen { get; set; }
        public double spellCrit { get; set; }
        public int spellCritRating { get; set; }
        public double mana5 { get; set; }
        public double mana5Combat { get; set; }
        public int armor { get; set; }
        public double dodge { get; set; }
        public int dodgeRating { get; set; }
        public double parry { get; set; }
        public int parryRating { get; set; }
        public double block { get; set; }
        public int blockRating { get; set; }
        public double mainHandDmgMin { get; set; }
        public double mainHandDmgMax { get; set; }
        public double mainHandSpeed { get; set; }
        public double mainHandDps { get; set; }
        public double offHandDmgMin { get; set; }
        public double offHandDmgMax { get; set; }
        public double offHandSpeed { get; set; }
        public double offHandDps { get; set; }
        public double rangedDmgMin { get; set; }
        public double rangedDmgMax { get; set; }
        public double rangedSpeed { get; set; }
        public double rangedDps { get; set; }
    }

    public class RootObjectStats
    {
        public long lastModified { get; set; }
        public string name { get; set; }
        public string realm { get; set; }
        public string battlegroup { get; set; }
        public int @class { get; set; }
        public int race { get; set; }
        public int gender { get; set; }
        public int level { get; set; }
        public int achievementPoints { get; set; }
        public string thumbnail { get; set; }
        public string calcClass { get; set; }
        public int faction { get; set; }
        public Stats stats { get; set; }
        public int totalHonorableKills { get; set; }
    }

}
