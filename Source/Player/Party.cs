

public partial class Party : Node
{
    public List<Player> PlayerParty;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // Read from data files to create and init player Party
        PlayerParty = new();

    }

    public bool Add(Player p)
    {

        return false;
    }

    Player GetPlayer(int pID) => PlayerParty[pID];

    public void Remove(Player p)
    {
    }


    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
