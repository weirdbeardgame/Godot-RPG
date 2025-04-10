# Style Guide

----------------------------------------------------------------

### Naming rules
- Naming rules tend to follow the [Microsoft C# style guide](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/identifier-names)
- Otherwise if something's unspecified [Follow Godot C# Guide](https://docs.godotengine.org/en/stable/tutorials/scripting/c_sharp/c_sharp_style_guide.html)

### Project Organization
Source and Scene files should be seperated but in mirroed folders. IE.

- Source
  - Quests
    - Quest.cs

- Assets
  - Quests
    - QuestUI.tscn

All Addon's and Addon Gui's should follow this structure in their own seperate folders. IE.

- Addons
  - AddonName
    - Source
    - Assets

