using Godot;
using System;

// this is supposed to be the main Global Database that takes instances of different databases
public partial class Database
{
    public static Database Instance { get; } = new Database();

    public QuestDatabase QuestDB { get; set; }
    
    public void InjectQuestDatabase(QuestDatabase questDatabase)
    {
        QuestDB = questDatabase;
        LoadDatabase(questDatabase);
    }

    public void LoadDatabase(Object someDatabase) // should probably make all the database inherit from a single base class
    {
        switch (someDatabase)
        {
            case QuestDatabase questDb:
                // Loading logic here
                break;

            default:
                GD.PrintErr("Database Loading Failed");
                break;
        }
    }

}