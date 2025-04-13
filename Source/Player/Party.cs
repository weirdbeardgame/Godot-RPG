using Core.Items;

public partial class Party : Node
{
    [Export] private Godot.Collections.Array<Player> _playerParty;

    private Inventory _playerInventory;
    public void RecieveSingleItem(Item it) => _playerInventory.Add(new List<Item> { it });
    public void RecieveMultipleItems(List<Item> items) => _playerInventory.Add(items);

    Player GetPlayer(int ID) => _playerParty[ID];

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // Read from data files to create and init player Party
        _playerParty = new();
    }

    // InGame party add
    public bool Add(Player p)
    {
        if (!_playerParty.Contains(p))
        {
            _playerParty.Add(p);
            return true;
        }

        GD.Print("Party already contains player");
        return false;
    }

    // InGame party remove. Some character was a temp or was taken out for some story reason
    public void Remove(Player p)
    {
        if (_playerParty.Contains(p))
        {
            _playerParty.Remove(p);
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
