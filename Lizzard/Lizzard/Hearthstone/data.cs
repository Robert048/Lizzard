using Newtonsoft.Json;
using System.Collections.Generic;

namespace Lizzard.Hearthstone
{

    public class Mechanic
    {
        public string name { get; set; }
    }

    public class Basic
    {
        public string cardId { get; set; }
        public string name { get; set; }
        public string cardSet { get; set; }
        public string type { get; set; }
        public string rarity { get; set; }
        public string text { get; set; }
        public string playerClass { get; set; }
        public string locale { get; set; }
        public List<Mechanic> mechanics { get; set; }
        public string faction { get; set; }
        public int? health { get; set; }
        public bool? collectible { get; set; }
        public string img { get; set; }
        public string imgGold { get; set; }
        public int? attack { get; set; }
        public string race { get; set; }
        public int? cost { get; set; }
        public string flavor { get; set; }
        public string artist { get; set; }
        public string howToGet { get; set; }
        public string howToGetGold { get; set; }
        public int? durability { get; set; }
    }

    public class Classic
    {
        public string cardId { get; set; }
        public string name { get; set; }
        public string cardSet { get; set; }
        public string type { get; set; }
        public string text { get; set; }
        public string playerClass { get; set; }
        public string locale { get; set; }
        public List<Mechanic> mechanics { get; set; }
        public string faction { get; set; }
        public string artist { get; set; }
        public string rarity { get; set; }
        public int? cost { get; set; }
        public string img { get; set; }
        public string imgGold { get; set; }
        public string flavor { get; set; }
        public bool? collectible { get; set; }
        public int? attack { get; set; }
        public int? health { get; set; }
        public string race { get; set; }
        public int? durability { get; set; }
        public bool? elite { get; set; }
    }

    public class Promo
    {
        public string cardId { get; set; }
        public string name { get; set; }
        public string cardSet { get; set; }
        public string type { get; set; }
        public string text { get; set; }
        public string playerClass { get; set; }
        public string locale { get; set; }
        public List<Mechanic> mechanics { get; set; }
        public int? cost { get; set; }
        public int? attack { get; set; }
        public int? health { get; set; }
        public string race { get; set; }
        public string img { get; set; }
        public string imgGold { get; set; }
        public string faction { get; set; }
        public string rarity { get; set; }
        public string flavor { get; set; }
        public string artist { get; set; }
        public bool? collectible { get; set; }
        public bool? elite { get; set; }
        public string howToGetGold { get; set; }
    }

    public class Reward
    {
        public string cardId { get; set; }
        public string name { get; set; }
        public string cardSet { get; set; }
        public string type { get; set; }
        public string rarity { get; set; }
        public int cost { get; set; }
        public int attack { get; set; }
        public int health { get; set; }
        public string text { get; set; }
        public string flavor { get; set; }
        public string artist { get; set; }
        public bool collectible { get; set; }
        public string race { get; set; }
        public string playerClass { get; set; }
        public string howToGet { get; set; }
        public string howToGetGold { get; set; }
        public string img { get; set; }
        public string imgGold { get; set; }
        public string locale { get; set; }
        public List<Mechanic> mechanics { get; set; }
        public string faction { get; set; }
        public bool? elite { get; set; }
    }

    public class Naxxrama
    {
        public string cardId { get; set; }
        public string name { get; set; }
        public string cardSet { get; set; }
        public string type { get; set; }
        public int health { get; set; }
        public string playerClass { get; set; }
        public string img { get; set; }
        public string imgGold { get; set; }
        public string locale { get; set; }
        public string text { get; set; }
        public List<Mechanic> mechanics { get; set; }
        public int? cost { get; set; }
        public string rarity { get; set; }
        public int? attack { get; set; }
        public bool? elite { get; set; }
        public string race { get; set; }
        public string flavor { get; set; }
        public string artist { get; set; }
        public bool? collectible { get; set; }
        public string howToGet { get; set; }
        public string howToGetGold { get; set; }
        public int? durability { get; set; }
    }

    public class GoblinsVsGnome
    {
        public string cardId { get; set; }
        public string name { get; set; }
        public string cardSet { get; set; }
        public string type { get; set; }
        public string text { get; set; }
        public string playerClass { get; set; }
        public string locale { get; set; }
        public List<Mechanic> mechanics { get; set; }
        public int? cost { get; set; }
        public string img { get; set; }
        public string imgGold { get; set; }
        public string artist { get; set; }
        public string rarity { get; set; }
        public int? attack { get; set; }
        public int? health { get; set; }
        public string flavor { get; set; }
        public bool? collectible { get; set; }
        public string race { get; set; }
        public int? durability { get; set; }
        public bool? elite { get; set; }
    }

    public class BlackrockMountain
    {
        public string cardId { get; set; }
        public string name { get; set; }
        public string cardSet { get; set; }
        public string type { get; set; }
        public int health { get; set; }
        public string playerClass { get; set; }
        public string img { get; set; }
        public string imgGold { get; set; }
        public string locale { get; set; }
        public string text { get; set; }
        public List<Mechanic> mechanics { get; set; }
        public int? cost { get; set; }
        public string rarity { get; set; }
        public int? attack { get; set; }
        public bool? elite { get; set; }
        public string race { get; set; }
        public string artist { get; set; }
        public string flavor { get; set; }
        public bool? collectible { get; set; }
        public string howToGet { get; set; }
        public string howToGetGold { get; set; }
        public int? durability { get; set; }
        public string faction { get; set; }
    }

    public class TheGrandTournament
    {
        public string cardId { get; set; }
        public string name { get; set; }
        public string cardSet { get; set; }
        public string type { get; set; }
        public string text { get; set; }
        public string playerClass { get; set; }
        public string locale { get; set; }
        public List<Mechanic> mechanics { get; set; }
        public int? attack { get; set; }
        public int? health { get; set; }
        public string img { get; set; }
        public string imgGold { get; set; }
        public int? cost { get; set; }
        public string rarity { get; set; }
        public string flavor { get; set; }
        public string artist { get; set; }
        public bool? collectible { get; set; }
        public string race { get; set; }
        public int? durability { get; set; }
        public bool? elite { get; set; }
    }

    public class TheLeagueOfExplorer
    {
        public string cardId { get; set; }
        public string name { get; set; }
        public string cardSet { get; set; }
        public string type { get; set; }
        public string text { get; set; }
        public string playerClass { get; set; }
        public string locale { get; set; }
        public int? health { get; set; }
        public string img { get; set; }
        public string imgGold { get; set; }
        public List<Mechanic> mechanics { get; set; }
        public int? attack { get; set; }
        public string race { get; set; }
        public int? cost { get; set; }
        public string artist { get; set; }
        public string rarity { get; set; }
        public string flavor { get; set; }
        public bool? collectible { get; set; }
        public string howToGet { get; set; }
        public string howToGetGold { get; set; }
        public int? durability { get; set; }
        public bool? elite { get; set; }
    }

    public class WhispersOfTheOldGod
    {
        public string cardId { get; set; }
        public string name { get; set; }
        public string cardSet { get; set; }
        public string type { get; set; }
        public string text { get; set; }
        public string playerClass { get; set; }
        public string locale { get; set; }
        public List<Mechanic> mechanics { get; set; }
        public string rarity { get; set; }
        public int? cost { get; set; }
        public string artist { get; set; }
        public string img { get; set; }
        public string imgGold { get; set; }
        public string flavor { get; set; }
        public bool? collectible { get; set; }
        public int? attack { get; set; }
        public int? health { get; set; }
        public string race { get; set; }
        public int? durability { get; set; }
        public bool? elite { get; set; }
        public string howToGet { get; set; }
        public string howToGetGold { get; set; }
    }

    public class Karazhan
    {
        public string cardId { get; set; }
        public string name { get; set; }
        public string cardSet { get; set; }
        public string type { get; set; }
        public string text { get; set; }
        public string playerClass { get; set; }
        public string locale { get; set; }
        public List<Mechanic> mechanics { get; set; }
        public string rarity { get; set; }
        public int? health { get; set; }
        public string img { get; set; }
        public string imgGold { get; set; }
        public string artist { get; set; }
        public int? attack { get; set; }
        public string race { get; set; }
        public int? cost { get; set; }
        public string faction { get; set; }
        public string flavor { get; set; }
        public bool? collectible { get; set; }
        public string howToGet { get; set; }
        public string howToGetGold { get; set; }
        public int? durability { get; set; }
        public bool? elite { get; set; }
    }

    public class MeanStreetsOfGadgetzan
    {
        public string cardId { get; set; }
        public string name { get; set; }
        public string cardSet { get; set; }
        public string type { get; set; }
        public string text { get; set; }
        public string artist { get; set; }
        public string playerClass { get; set; }
        public string locale { get; set; }
        public List<Mechanic> mechanics { get; set; }
        public string rarity { get; set; }
        public int? cost { get; set; }
        public string flavor { get; set; }
        public bool? collectible { get; set; }
        public string img { get; set; }
        public string imgGold { get; set; }
        public string faction { get; set; }
        public int? attack { get; set; }
        public int? health { get; set; }
        public string race { get; set; }
        public bool? elite { get; set; }
        public string multiClassGroup { get; set; }
        public List<string> classes { get; set; }
        public int? durability { get; set; }
    }

    public class TavernBrawl
    {
        public string cardId { get; set; }
        public string name { get; set; }
        public string cardSet { get; set; }
        public string type { get; set; }
        public string faction { get; set; }
        public string rarity { get; set; }
        public int health { get; set; }
        public string playerClass { get; set; }
        public string img { get; set; }
        public string imgGold { get; set; }
        public string locale { get; set; }
        public string text { get; set; }
        public int? attack { get; set; }
        public List<Mechanic> mechanics { get; set; }
        public int? cost { get; set; }
        public bool? elite { get; set; }
        public int? durability { get; set; }
        public string race { get; set; }
    }

    public class HeroSkin
    {
        public string cardId { get; set; }
        public string name { get; set; }
        public string cardSet { get; set; }
        public string type { get; set; }
        public string rarity { get; set; }
        public int health { get; set; }
        public bool collectible { get; set; }
        public string playerClass { get; set; }
        public string img { get; set; }
        public string imgGold { get; set; }
        public string locale { get; set; }
        public string faction { get; set; }
        public int? cost { get; set; }
        public string text { get; set; }
    }

    public class Mission
    {
        public string cardId { get; set; }
        public string name { get; set; }
        public string cardSet { get; set; }
        public string type { get; set; }
        public string text { get; set; }
        public string playerClass { get; set; }
        public string locale { get; set; }
        public string rarity { get; set; }
        public int? health { get; set; }
        public string img { get; set; }
        public string imgGold { get; set; }
        public List<Mechanic> mechanics { get; set; }
        public string faction { get; set; }
        public int? cost { get; set; }
        public int? attack { get; set; }
        public int? durability { get; set; }
    }

    public class Credit
    {
        public string cardId { get; set; }
        public string name { get; set; }
        public string cardSet { get; set; }
        public string type { get; set; }
        public string rarity { get; set; }
        public int cost { get; set; }
        public int attack { get; set; }
        public int health { get; set; }
        public string text { get; set; }
        public bool elite { get; set; }
        public string playerClass { get; set; }
        public string img { get; set; }
        public string imgGold { get; set; }
        public string locale { get; set; }
    }

    public class Debug
    {
        public string cardId { get; set; }
        public string name { get; set; }
        public string cardSet { get; set; }
        public string type { get; set; }
        public string playerClass { get; set; }
        public string locale { get; set; }
        public int? attack { get; set; }
        public int? health { get; set; }
        public string text { get; set; }
        public string img { get; set; }
        public string imgGold { get; set; }
        public string rarity { get; set; }
        public int? cost { get; set; }
        public List<Mechanic> mechanics { get; set; }
        public int? durability { get; set; }
        public string faction { get; set; }
        public string race { get; set; }
        public string flavor { get; set; }
        public bool? elite { get; set; }
    }

    public class RootObject
    {
        public List<Basic> Basic { get; set; }
        public List<Classic> Classic { get; set; }
        public List<Promo> Promo { get; set; }
        public List<Reward> Reward { get; set; }
        public List<Naxxrama> Naxxramas { get; set; }
        [JsonProperty("Goblins vs Gnomes")]
        public List<GoblinsVsGnome> GoblinsVSGnomes { get; set; }
        [JsonProperty("Blackrock Mountain")]
        public List<BlackrockMountain> BlackrockMountain { get; set; }
        [JsonProperty("The Grand Tournament")]
        public List<TheGrandTournament> TheGrandTournament { get; set; }
        [JsonProperty("The League of Explorers")]
        public List<TheLeagueOfExplorer> TheLeagueofExplorers { get; set; }
        [JsonProperty("Whispers of the Old Gods")]
        public List<WhispersOfTheOldGod> WhispersOfTheOldGods { get; set; }
        public List<Karazhan> Karazhan { get; set; }
        [JsonProperty("Mean Streets of Gadgetzan")]
        public List<MeanStreetsOfGadgetzan> MeanStreetsOfGadgetzan { get; set; }
        [JsonProperty("Tavern Brawl")]
        public List<TavernBrawl> TavernBrawl { get; set; }
        [JsonProperty("Hero Skins")]
        public List<HeroSkin> HeroSkins { get; set; }
        public List<Mission> Missions { get; set; }
        public List<Credit> Credits { get; set; }
        public List<object> System { get; set; }
        public List<Debug> Debug { get; set; }
    }
}
