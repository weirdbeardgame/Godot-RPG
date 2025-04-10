# State Machine:

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

The State Machine is a simple yet flexible design that revolves around ```State : Node``` State is a generic type that all State's that instance of the State Machine will have should inherit from. State's will use GetNode to attempt to find the StateMachine they belong too and assign themselves to it.

```csharp
    // An example state that implements Walking for Player
    public partial class ExampleWalkState : State
    {
        public  override  void  _EnterTree()
        {
            StateName  =  "WALK";
            Player  = (Player)GetParent<Player>(); 
            // Note that each state needs this seperately to account for the tree they belong too
            StateMachine = (StateMachine)GetParent<Player>().GetNode<StateMachine>("StateMachine");
            StateMachine.AddState(this, StateName);
        }

        public override void Start()
        {
        }
    
        public override void Stop()
        {
        }
    };
```
Any major game functionality can and should use StateMachine at some point. An example of a good State Machine is as follows

- ### Root Node With script or whatever else attached
    - **StateMachineNode**
    - **NodeThatInheritsFromState**

### State.cs feature's the following functions: 
- **Sart**: Ran after EnterTree of State. Is called in StateMachine when State is first activated but can be called manually after. Paramaters : None
- **GetInput**: Optional function for States that affect Player or otherwise accept an input like Pause menu if you so desire. 
    GetInput returns Vector3 that can be downcase to Vector2 for 2D scenarios Paramaters : None
- **Update**: FixedUpdate, called in StateMachine's process and PhysicsProcess. Naming scheme set to match Unity. Paramaters : None
- **Stop**: Used for State stop logic. Including saving data from sate. Clearing data from state, this is used to ensure clean State shutdown or reset if State will repeat.
    Paramaters : None

### StateMachine.cs features the following functions:
- **AddState**: Called only by states in the same Tree as this instance of StateMachine. Paramaters : state, string
- **InitDefaultState**: Called only at beginning to start state machine. Paramaters : string
- **UpdateState**: Used to change the currently active state. Paramaters : string
- **ResetState**: Resets the currently active state back to the start. Paramaters : None
- **ResetToOldState**: Resets the current state back to the one before it. IE. `Jump -> UpdateState -> Fall -> ResetToOldState -> Jump`
    Paramaters : None