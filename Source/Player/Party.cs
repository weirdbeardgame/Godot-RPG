using System.Linq;
using Core.Items;

public partial class Party : Node
{
    [Export] private Godot.Collections.Array<Creature> _party;

    private Inventory _inventory;
    public void RecieveSingleItem(Item it) => _inventory.Add(new List<Item> { it });
    public void RecieveMultipleItems(List<Item> items) => _inventory.Add(items);

    Player GetPlayer(int ID) => (Player)_party[ID];

    Enemy GetEnemy(int EID) => (Enemy)_party[EID];

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // Read from data files to create and init player Party
        _party = new();
    }

    // InGame party add
    public bool Add(Creature p)
    {
        if (!_party.Contains(p))
        {
            _party.Add(p);
            return true;
        }

        GD.Print("Party already contains player");
        return false;
    }

    // InGame party remove. Some character was a temp or was taken out for some story reason
    public void Remove(Player p)
    {
        if (_party.Contains(p))
        {
            _party.Remove(p);
        }
    }

    public bool IsDead => _party.All(c => c.IsAlive == LivingStatus.DEAD);

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
