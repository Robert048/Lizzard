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


    public class TooltipParams
    {
        public int gem0 { get; set; }
        public int transmogItem { get; set; }
        public int timewalkerLevel { get; set; }
    }

    public class Stat
    {
        public int stat { get; set; }
        public int amount { get; set; }
    }

    public class Appearance
    {
        public int itemId { get; set; }
        public int itemAppearanceModId { get; set; }
    }

    public class Head
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int quality { get; set; }
        public int itemLevel { get; set; }
        public TooltipParams tooltipParams { get; set; }
        public List<Stat> stats { get; set; }
        public int armor { get; set; }
        public string context { get; set; }
        public List<int> bonusLists { get; set; }
        public int artifactId { get; set; }
        public int displayInfoId { get; set; }
        public int artifactAppearanceId { get; set; }
        public List<object> artifactTraits { get; set; }
        public List<object> relics { get; set; }
        public Appearance appearance { get; set; }
    }

    public class TooltipParams2
    {
        public int gem0 { get; set; }
        public int enchant { get; set; }
        public int timewalkerLevel { get; set; }
    }

    public class Stat2
    {
        public int stat { get; set; }
        public int amount { get; set; }
    }

    public class Appearance2
    {
        public int enchantDisplayInfoId { get; set; }
    }

    public class Neck
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int quality { get; set; }
        public int itemLevel { get; set; }
        public TooltipParams2 tooltipParams { get; set; }
        public List<Stat2> stats { get; set; }
        public int armor { get; set; }
        public string context { get; set; }
        public List<int> bonusLists { get; set; }
        public int artifactId { get; set; }
        public int displayInfoId { get; set; }
        public int artifactAppearanceId { get; set; }
        public List<object> artifactTraits { get; set; }
        public List<object> relics { get; set; }
        public Appearance2 appearance { get; set; }
    }

    public class TooltipParams3
    {
        public int enchant { get; set; }
        public int transmogItem { get; set; }
        public int timewalkerLevel { get; set; }
    }

    public class Stat3
    {
        public int stat { get; set; }
        public int amount { get; set; }
    }

    public class Appearance3
    {
        public int itemId { get; set; }
        public int enchantDisplayInfoId { get; set; }
        public int itemAppearanceModId { get; set; }
    }

    public class Shoulder
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int quality { get; set; }
        public int itemLevel { get; set; }
        public TooltipParams3 tooltipParams { get; set; }
        public List<Stat3> stats { get; set; }
        public int armor { get; set; }
        public string context { get; set; }
        public List<int> bonusLists { get; set; }
        public int artifactId { get; set; }
        public int displayInfoId { get; set; }
        public int artifactAppearanceId { get; set; }
        public List<object> artifactTraits { get; set; }
        public List<object> relics { get; set; }
        public Appearance3 appearance { get; set; }
    }

    public class TooltipParams4
    {
        public int gem0 { get; set; }
        public int enchant { get; set; }
        public int transmogItem { get; set; }
        public int timewalkerLevel { get; set; }
    }

    public class Stat4
    {
        public int stat { get; set; }
        public int amount { get; set; }
    }

    public class Appearance4
    {
        public int itemId { get; set; }
        public int enchantDisplayInfoId { get; set; }
        public int itemAppearanceModId { get; set; }
    }

    public class Back
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int quality { get; set; }
        public int itemLevel { get; set; }
        public TooltipParams4 tooltipParams { get; set; }
        public List<Stat4> stats { get; set; }
        public int armor { get; set; }
        public string context { get; set; }
        public List<int> bonusLists { get; set; }
        public int artifactId { get; set; }
        public int displayInfoId { get; set; }
        public int artifactAppearanceId { get; set; }
        public List<object> artifactTraits { get; set; }
        public List<object> relics { get; set; }
        public Appearance4 appearance { get; set; }
    }

    public class TooltipParams5
    {
        public int transmogItem { get; set; }
        public int timewalkerLevel { get; set; }
    }

    public class Stat5
    {
        public int stat { get; set; }
        public int amount { get; set; }
    }

    public class Appearance5
    {
        public int itemId { get; set; }
        public int itemAppearanceModId { get; set; }
    }

    public class Chest
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int quality { get; set; }
        public int itemLevel { get; set; }
        public TooltipParams5 tooltipParams { get; set; }
        public List<Stat5> stats { get; set; }
        public int armor { get; set; }
        public string context { get; set; }
        public List<int> bonusLists { get; set; }
        public int artifactId { get; set; }
        public int displayInfoId { get; set; }
        public int artifactAppearanceId { get; set; }
        public List<object> artifactTraits { get; set; }
        public List<object> relics { get; set; }
        public Appearance5 appearance { get; set; }
    }

    public class TooltipParams6
    {
        public int gem0 { get; set; }
        public int timewalkerLevel { get; set; }
    }

    public class Stat6
    {
        public int stat { get; set; }
        public int amount { get; set; }
    }

    public class Appearance6
    {
    }

    public class Wrist
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int quality { get; set; }
        public int itemLevel { get; set; }
        public TooltipParams6 tooltipParams { get; set; }
        public List<Stat6> stats { get; set; }
        public int armor { get; set; }
        public string context { get; set; }
        public List<int> bonusLists { get; set; }
        public int artifactId { get; set; }
        public int displayInfoId { get; set; }
        public int artifactAppearanceId { get; set; }
        public List<object> artifactTraits { get; set; }
        public List<object> relics { get; set; }
        public Appearance6 appearance { get; set; }
    }

    public class TooltipParams7
    {
        public int enchant { get; set; }
        public int transmogItem { get; set; }
        public int timewalkerLevel { get; set; }
    }

    public class Stat7
    {
        public int stat { get; set; }
        public int amount { get; set; }
    }

    public class Appearance7
    {
        public int itemId { get; set; }
        public int enchantDisplayInfoId { get; set; }
        public int itemAppearanceModId { get; set; }
    }

    public class Hands
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int quality { get; set; }
        public int itemLevel { get; set; }
        public TooltipParams7 tooltipParams { get; set; }
        public List<Stat7> stats { get; set; }
        public int armor { get; set; }
        public string context { get; set; }
        public List<int> bonusLists { get; set; }
        public int artifactId { get; set; }
        public int displayInfoId { get; set; }
        public int artifactAppearanceId { get; set; }
        public List<object> artifactTraits { get; set; }
        public List<object> relics { get; set; }
        public Appearance7 appearance { get; set; }
    }

    public class TooltipParams8
    {
        public int transmogItem { get; set; }
        public int timewalkerLevel { get; set; }
    }

    public class Stat8
    {
        public int stat { get; set; }
        public int amount { get; set; }
    }

    public class Appearance8
    {
        public int itemId { get; set; }
        public int itemAppearanceModId { get; set; }
    }

    public class Waist
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int quality { get; set; }
        public int itemLevel { get; set; }
        public TooltipParams8 tooltipParams { get; set; }
        public List<Stat8> stats { get; set; }
        public int armor { get; set; }
        public string context { get; set; }
        public List<int> bonusLists { get; set; }
        public int artifactId { get; set; }
        public int displayInfoId { get; set; }
        public int artifactAppearanceId { get; set; }
        public List<object> artifactTraits { get; set; }
        public List<object> relics { get; set; }
        public Appearance8 appearance { get; set; }
    }

    public class TooltipParams9
    {
        public int gem0 { get; set; }
        public int transmogItem { get; set; }
        public int timewalkerLevel { get; set; }
    }

    public class Stat9
    {
        public int stat { get; set; }
        public int amount { get; set; }
    }

    public class Appearance9
    {
        public int itemId { get; set; }
        public int itemAppearanceModId { get; set; }
    }

    public class Legs
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int quality { get; set; }
        public int itemLevel { get; set; }
        public TooltipParams9 tooltipParams { get; set; }
        public List<Stat9> stats { get; set; }
        public int armor { get; set; }
        public string context { get; set; }
        public List<int> bonusLists { get; set; }
        public int artifactId { get; set; }
        public int displayInfoId { get; set; }
        public int artifactAppearanceId { get; set; }
        public List<object> artifactTraits { get; set; }
        public List<object> relics { get; set; }
        public Appearance9 appearance { get; set; }
    }

    public class TooltipParams10
    {
        public int transmogItem { get; set; }
        public int timewalkerLevel { get; set; }
    }

    public class Stat10
    {
        public int stat { get; set; }
        public int amount { get; set; }
    }

    public class Appearance10
    {
        public int itemId { get; set; }
        public int itemAppearanceModId { get; set; }
    }

    public class Feet
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int quality { get; set; }
        public int itemLevel { get; set; }
        public TooltipParams10 tooltipParams { get; set; }
        public List<Stat10> stats { get; set; }
        public int armor { get; set; }
        public string context { get; set; }
        public List<int> bonusLists { get; set; }
        public int artifactId { get; set; }
        public int displayInfoId { get; set; }
        public int artifactAppearanceId { get; set; }
        public List<object> artifactTraits { get; set; }
        public List<object> relics { get; set; }
        public Appearance10 appearance { get; set; }
    }

    public class TooltipParams11
    {
        public int gem0 { get; set; }
        public int enchant { get; set; }
        public int timewalkerLevel { get; set; }
    }

    public class Stat11
    {
        public int stat { get; set; }
        public int amount { get; set; }
    }

    public class Appearance11
    {
        public int enchantDisplayInfoId { get; set; }
    }

    public class Finger1
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int quality { get; set; }
        public int itemLevel { get; set; }
        public TooltipParams11 tooltipParams { get; set; }
        public List<Stat11> stats { get; set; }
        public int armor { get; set; }
        public string context { get; set; }
        public List<int> bonusLists { get; set; }
        public int artifactId { get; set; }
        public int displayInfoId { get; set; }
        public int artifactAppearanceId { get; set; }
        public List<object> artifactTraits { get; set; }
        public List<object> relics { get; set; }
        public Appearance11 appearance { get; set; }
    }

    public class TooltipParams12
    {
        public int enchant { get; set; }
        public int timewalkerLevel { get; set; }
    }

    public class Stat12
    {
        public int stat { get; set; }
        public int amount { get; set; }
    }

    public class Appearance12
    {
        public int enchantDisplayInfoId { get; set; }
    }

    public class Finger2
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int quality { get; set; }
        public int itemLevel { get; set; }
        public TooltipParams12 tooltipParams { get; set; }
        public List<Stat12> stats { get; set; }
        public int armor { get; set; }
        public string context { get; set; }
        public List<int> bonusLists { get; set; }
        public int artifactId { get; set; }
        public int displayInfoId { get; set; }
        public int artifactAppearanceId { get; set; }
        public List<object> artifactTraits { get; set; }
        public List<object> relics { get; set; }
        public Appearance12 appearance { get; set; }
    }

    public class TooltipParams13
    {
        public int timewalkerLevel { get; set; }
    }

    public class Stat13
    {
        public int stat { get; set; }
        public int amount { get; set; }
    }

    public class Appearance13
    {
    }

    public class Trinket1
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int quality { get; set; }
        public int itemLevel { get; set; }
        public TooltipParams13 tooltipParams { get; set; }
        public List<Stat13> stats { get; set; }
        public int armor { get; set; }
        public string context { get; set; }
        public List<int> bonusLists { get; set; }
        public int artifactId { get; set; }
        public int displayInfoId { get; set; }
        public int artifactAppearanceId { get; set; }
        public List<object> artifactTraits { get; set; }
        public List<object> relics { get; set; }
        public Appearance13 appearance { get; set; }
    }

    public class TooltipParams14
    {
        public int timewalkerLevel { get; set; }
    }

    public class Stat14
    {
        public int stat { get; set; }
        public int amount { get; set; }
    }

    public class Appearance14
    {
    }

    public class Trinket2
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int quality { get; set; }
        public int itemLevel { get; set; }
        public TooltipParams14 tooltipParams { get; set; }
        public List<Stat14> stats { get; set; }
        public int armor { get; set; }
        public string context { get; set; }
        public List<int> bonusLists { get; set; }
        public int artifactId { get; set; }
        public int displayInfoId { get; set; }
        public int artifactAppearanceId { get; set; }
        public List<object> artifactTraits { get; set; }
        public List<object> relics { get; set; }
        public Appearance14 appearance { get; set; }
    }

    public class TooltipParams15
    {
        public int gem0 { get; set; }
        public int gem1 { get; set; }
        public int gem2 { get; set; }
        public int timewalkerLevel { get; set; }
    }

    public class Stat15
    {
        public int stat { get; set; }
        public int amount { get; set; }
    }

    public class Damage
    {
        public int min { get; set; }
        public int max { get; set; }
        public double exactMin { get; set; }
        public double exactMax { get; set; }
    }

    public class WeaponInfo
    {
        public Damage damage { get; set; }
        public double weaponSpeed { get; set; }
        public double dps { get; set; }
    }

    public class ArtifactTrait
    {
        public int id { get; set; }
        public int rank { get; set; }
    }

    public class Relic
    {
        public int socket { get; set; }
        public int itemId { get; set; }
        public int context { get; set; }
        public List<int> bonusLists { get; set; }
    }

    public class Appearance15
    {
        public int itemAppearanceModId { get; set; }
    }

    public class MainHand
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int quality { get; set; }
        public int itemLevel { get; set; }
        public TooltipParams15 tooltipParams { get; set; }
        public List<Stat15> stats { get; set; }
        public int armor { get; set; }
        public WeaponInfo weaponInfo { get; set; }
        public string context { get; set; }
        public List<int> bonusLists { get; set; }
        public int artifactId { get; set; }
        public int displayInfoId { get; set; }
        public int artifactAppearanceId { get; set; }
        public List<ArtifactTrait> artifactTraits { get; set; }
        public List<Relic> relics { get; set; }
        public Appearance15 appearance { get; set; }
    }

    public class Items
    {
        public int averageItemLevel { get; set; }
        public int averageItemLevelEquipped { get; set; }
        public Head head { get; set; }
        public Neck neck { get; set; }
        public Shoulder shoulder { get; set; }
        public Back back { get; set; }
        public Chest chest { get; set; }
        public Wrist wrist { get; set; }
        public Hands hands { get; set; }
        public Waist waist { get; set; }
        public Legs legs { get; set; }
        public Feet feet { get; set; }
        public Finger1 finger1 { get; set; }
        public Finger2 finger2 { get; set; }
        public Trinket1 trinket1 { get; set; }
        public Trinket2 trinket2 { get; set; }
        public MainHand mainHand { get; set; }
    }

    public class RootObjectItems
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
        public Items items { get; set; }
        public int totalHonorableKills { get; set; }
    }



    public class Achievements
    {
        public List<int> achievementsCompleted { get; set; }
        public List<object> achievementsCompletedTimestamp { get; set; }
        public List<int> criteria { get; set; }
        public List<long> criteriaQuantity { get; set; }
        public List<object> criteriaTimestamp { get; set; }
        public List<object> criteriaCreated { get; set; }
    }

    public class Emblem
    {
        public int icon { get; set; }
        public string iconColor { get; set; }
        public int iconColorId { get; set; }
        public int border { get; set; }
        public string borderColor { get; set; }
        public int borderColorId { get; set; }
        public string backgroundColor { get; set; }
        public int backgroundColorId { get; set; }
    }

    public class Realm
    {
        public string name { get; set; }
        public string slug { get; set; }
        public string battlegroup { get; set; }
        public string locale { get; set; }
        public string timezone { get; set; }
        public List<string> connected_realms { get; set; }
    }

    public class BronzeCriteria
    {
        public int time { get; set; }
        public int hours { get; set; }
        public int minutes { get; set; }
        public int seconds { get; set; }
        public int milliseconds { get; set; }
        public bool isPositive { get; set; }
    }

    public class SilverCriteria
    {
        public int time { get; set; }
        public int hours { get; set; }
        public int minutes { get; set; }
        public int seconds { get; set; }
        public int milliseconds { get; set; }
        public bool isPositive { get; set; }
    }

    public class GoldCriteria
    {
        public int time { get; set; }
        public int hours { get; set; }
        public int minutes { get; set; }
        public int seconds { get; set; }
        public int milliseconds { get; set; }
        public bool isPositive { get; set; }
    }

    public class Map
    {
        public int id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public bool hasChallengeMode { get; set; }
        public BronzeCriteria bronzeCriteria { get; set; }
        public SilverCriteria silverCriteria { get; set; }
        public GoldCriteria goldCriteria { get; set; }
    }

    public class Challenge
    {
        public Realm realm { get; set; }
        public Map map { get; set; }
        public List<object> groups { get; set; }
    }

    public class RootObjectGuild
    {
        public long lastModified { get; set; }
        public string name { get; set; }
        public string realm { get; set; }
        public string battlegroup { get; set; }
        public int level { get; set; }
        public int side { get; set; }
        public int achievementPoints { get; set; }
        public Achievements achievements { get; set; }
        public Emblem emblem { get; set; }
        public List<Challenge> challenge { get; set; }
    }



    public class News
    {
        public string type { get; set; }
        public string character { get; set; }
        public object timestamp { get; set; }
        public int itemId { get; set; }
        public string context { get; set; }
        public List<object> bonusLists { get; set; }
        public Achievement achievement { get; set; }
    }

    public class RootObjectGuildNews
    {
        public long lastModified { get; set; }
        public string name { get; set; }
        public string realm { get; set; }
        public string battlegroup { get; set; }
        public int level { get; set; }
        public int side { get; set; }
        public int achievementPoints { get; set; }
        public Emblem emblem { get; set; }
        public List<News> news { get; set; }
    }


    public class Spec
    {
        public string name { get; set; }
        public string role { get; set; }
        public string backgroundImage { get; set; }
        public string icon { get; set; }
        public string description { get; set; }
        public int order { get; set; }
    }

    public class Character
    {
        public string name { get; set; }
        public string realm { get; set; }
        public string battlegroup { get; set; }
        public int @class { get; set; }
        public int race { get; set; }
        public int gender { get; set; }
        public int level { get; set; }
        public int achievementPoints { get; set; }
        public string thumbnail { get; set; }
        public Spec spec { get; set; }
        public string guild { get; set; }
        public string guildRealm { get; set; }
        public int lastModified { get; set; }
    }

    public class Member
    {
        public Character character { get; set; }
        public int rank { get; set; }
    }


    public class RootObjectGuildMembers
    {
        public long lastModified { get; set; }
        public string name { get; set; }
        public string realm { get; set; }
        public string battlegroup { get; set; }
        public int level { get; set; }
        public int side { get; set; }
        public int achievementPoints { get; set; }
        public List<Member> members { get; set; }
    }


    public class BonusStat
    {
        public int stat { get; set; }
        public int amount { get; set; }
    }


    public class ItemSource
    {
        public int sourceId { get; set; }
        public string sourceType { get; set; }
    }

    public class BonusSummary
    {
        public List<object> defaultBonusLists { get; set; }
        public List<object> chanceBonusLists { get; set; }
        public List<object> bonusChances { get; set; }
    }

    public class RootObjectItem
    {
        public int id { get; set; }
        public int disenchantingSkillRank { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public int stackable { get; set; }
        public int itemBind { get; set; }
        public List<BonusStat> bonusStats { get; set; }
        public List<object> itemSpells { get; set; }
        public int buyPrice { get; set; }
        public int itemClass { get; set; }
        public int itemSubClass { get; set; }
        public int containerSlots { get; set; }
        public WeaponInfo weaponInfo { get; set; }
        public int inventoryType { get; set; }
        public bool equippable { get; set; }
        public int itemLevel { get; set; }
        public int maxCount { get; set; }
        public int maxDurability { get; set; }
        public int minFactionId { get; set; }
        public int minReputation { get; set; }
        public int quality { get; set; }
        public int sellPrice { get; set; }
        public int requiredSkill { get; set; }
        public int requiredLevel { get; set; }
        public int requiredSkillRank { get; set; }
        public ItemSource itemSource { get; set; }
        public int baseArmor { get; set; }
        public bool hasSockets { get; set; }
        public bool isAuctionable { get; set; }
        public int armor { get; set; }
        public int displayInfoId { get; set; }
        public string nameDescription { get; set; }
        public string nameDescriptionColor { get; set; }
        public bool upgradable { get; set; }
        public bool heroicTooltip { get; set; }
        public string context { get; set; }
        public List<object> bonusLists { get; set; }
        public List<string> availableContexts { get; set; }
        public BonusSummary bonusSummary { get; set; }
        public int artifactId { get; set; }
    }


}
