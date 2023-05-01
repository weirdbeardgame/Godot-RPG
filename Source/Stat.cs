using Godot;
using System;
using System.Collections.Generic;

public partial class Stat : Node
{
    public enum StatType { HEALTH, SPEED, STRENGTH, MAGIC, DEFENSE }

    public class Stats
    {
        int ID;
        public StatType currentStat;
        public float stat;

        public void CreateStats(StatType Stat, float Stats)
        {
            currentStat = Stat;
            stat = Stats;
        }

        public override string ToString()
        {
            // Return name and Value
            return currentStat.ToString() + ": " + stat.ToString();
        }
    }

    public class StatManager
    {
        public List<Stats> statList;
        private Stats statToCreate;

        float buff;

        public void Initalize()
        {
            statList = new List<Stats>();
            for (int i = 0; i < 5; i++)
            {
                statToCreate = new Stats();
                statToCreate.CreateStats((StatType)i, buff);
                statList.Add(statToCreate);
            }
        }

        // ToDo, add Buff / Debuff logic in here
    }
}
