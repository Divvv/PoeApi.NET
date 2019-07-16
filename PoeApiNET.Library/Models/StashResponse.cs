using System;
using System.Collections.Generic;

namespace PoeApiNET.Library.Models
{
    public class StashResponse
    {
        public string next_change_id { get; set; }
        public List<Stash> stashes { get; set; }
    }

    public class Stash
    {
        public string accountName { get; set; }
        public string lastCharacterName { get; set; }
        public string id { get; set; }
        public string stash { get; set; }
        public string stashType { get; set; }
        public List<Item> items { get; set; }
        public bool @public { get; set; }
    }
    
    public class Item
    {
        public bool abyssJewel { get; set; }
        public List<Property> additionalProperties { get; set; }
        public string artFilename { get; set; }
        // public string category { get; set; } // todo: revisit
        public bool corrupted { get; set; }
        public List<string> cosmeticMods { get; set; }
        public List<string> craftedMods { get; set; }
        public string descrText { get; set; }
        public bool duplicated { get; set; }
        public bool elder { get; set; }
        public List<string> enchantMods { get; set; }
        public List<string> explicitMods { get; set; }
        public List<string> flavourText { get; set; }
        public int frameType { get; set; } // todo: enum?
        public int h { get; set; }
        public string icon { get; set; }
        public string id { get; set; }
        public bool identified { get; set; }
        public int ilvl { get; set; }
        public List<string> implicitMods { get; set; }
        public string inventoryId { get; set; }
        public bool isRelic { get; set; }
        public string league { get; set; }
        public bool lockedToCharacter { get; set; }
        public int maxStackSize { get; set; }
        public string name { get; set; }
        public List<Property> nextLevelRequirements { get; set; }
        public string note { get; set; }
        public List<Property> properties { get; set; }
        public string prophecyDiffText { get; set; }
        public string prophecyText { get; set; }
        public List<Property> requirements { get; set; }
        public string secDescrText { get; set; }
        public bool shaper { get; set; }
        public List<Item> socketedItems { get; set; }
        public List<Socket> sockets { get; set; }
        public int stackSize { get; set; }
        public bool support { get; set; }
        public int talismanTier { get; set; }
        public string typeLine { get; set; }
        public List<string> utilityMods { get; set; }
        public bool verified { get; set; }
        public int w { get; set; }
        public int x { get; set; }
        public int y { get; set; }

        // rare race rewards, ignore it atm
    }

    public class Property // todo: property/requirement ?
    {
        public string name { get; set; }
        public List<List<string>> values { get; set; } // array[0] is value, array[1] is valueTypes
        public int displayMode { get; set; }
        public int type { get; set; }
        public float? progress { get; set; }
    }

    public class Socket
    {
        public int group { get; set; }
        public string attr { get; set; } //S, I, D, G, false (type is boolean for abyss). Stands for str, int, dex, generic?. G - white socket.
        public string sColour { get; set; }
    }
}