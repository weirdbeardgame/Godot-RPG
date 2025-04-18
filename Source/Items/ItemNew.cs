using Godot;
using System;

[GlobalClass]
public partial class ItemNew : Resource
{
	public enum ItemCategory { Consumable, Equipment, Key, Material}
    public enum ItemUseScope { Always, InCombat, OutOfCombat }
    public enum ItemUsableOn { User, Allies, Opponents, AllSides }
    public enum ItemTargetCondition { Alive, Dead, Both }
    public enum ItemFeatures { Usable, Stackable, Sellable }

    [Export] public string itemName;
    [Export] public string itemDescription1;
	[Export] public string itemDescription2;
	[Export] public string itemDescription3;
    [Export] public ImageTexture itemImage;

    [ExportCategory("Item Properties")] // all of the values should probably be present inside the stat resource/object itself
    [Export] public float basePrice;
    [Export] public int maxStackCount;
	//[Export] public float critRate;
	//[Export] public float critRatio;
	//[Export] public float hitChance;
	//[Export] public resource effectSource;

    [ExportCategory("Usage Settings")]
	[Export] public ItemCategory category;
    [Export] public ItemUseScope useScope;
    [Export] public ItemUsableOn usableOn;
    [Export] public ItemTargetCondition targetCondition;
	
    [Export] public Godot.Collections.Dictionary<ItemFeatures, bool> features = new Godot.Collections.Dictionary<ItemFeatures, bool> //probably not needed
    {
        { ItemFeatures.Usable, true },
        { ItemFeatures.Stackable, true },
        { ItemFeatures.Sellable, true }
    };

    [Export] public Godot.Collections.Array<StatData> stats;
	[Export] public string calculationFormula; // can be an array<string> to support multiple stages of calculation
	//[Export] public Resource targetAreaContainer; // Resource of class TargetAreaContainer, TargetAreaContainer will contain TargetArea/s as well as their spawnrelation

    [ExportCategory("Custom Item Behvaiour")]
    [Export] protected Godot.Collections.Array<Resource> uniqueBehaviour; // Resource being extended by GameOutcome/Event/Reward class

    // Use method to be present inside the manager that handles battles, inventory and stuff and not in the item itself
    // public bool Use() { return false; }
}
    // private Guid _id = Guid.NewGuid();
    // public Guid ID => _id;
    // public void initializeID() { if (_id == Guid.Empty) { _id = Guid.NewGuid(); } }
