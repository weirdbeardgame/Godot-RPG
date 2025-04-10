using Godot;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Core.Quests;

[GlobalClass]
public partial class Quest : Resource
{
    [ExportGroup("Quest Details")]
    [Export] public string Title;
    [Export] public string ImgPath;
    [ExportSubgroup("Extra Details")]
    [Export(PropertyHint.MultilineText)] public string Description;
    [Export(PropertyHint.MultilineText)] public string AlternateDescription;
    [Export] public string Hint;


    [ExportGroup("Quest Actions")]
    [Export] public Godot.Collections.Array<Condition> ToStart;
    [Export] public Godot.Collections.Array<Reward> OnStarted;
    [Export] public Godot.Collections.Array<Condition> ToComplete;
    [Export] public Godot.Collections.Array<Reward> OnCompleted;
    [Export] public Godot.Collections.Array<Condition> ToFailForever;
    [Export] public Godot.Collections.Array<Reward> OnFailed;


    [ExportGroup("Developer Notes")]
    [Export] public string CommentTitle1;
    [Export(PropertyHint.MultilineText)] public string CommentDetail1;
    [Export] public string CommentTitle2;
    [Export(PropertyHint.MultilineText)] public string CommentDetail2;
    [Export] public string CommentTitle3;
    [Export(PropertyHint.MultilineText)] public string CommentDetail3;
}
