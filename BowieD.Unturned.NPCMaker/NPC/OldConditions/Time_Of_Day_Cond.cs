﻿using System;
using BowieD.Unturned.NPCMaker.BetterForms;

namespace BowieD.Unturned.NPCMaker.NPC.Conditions
{
    public class Time_Of_Day_Cond : Condition, Condition.IHasLogic
    {
        public Time_Of_Day_Cond()
        {
            Type = Condition_Type.Time_Of_Day;
        }

        public Logic_Type Logic { get; set; }
        public ulong Second { get; set; }

        public override int Elements => 2;

        public override void Init(Universal_ConditionEditor uce)
        {
            uce.AddLabel(MainWindow.Localize("conditionEditor_LogicType"));
            uce.AddLogicBox();
            uce.AddLabel(MainWindow.Localize("conditionEditor_Second"));
            uce.AddTextBox(10);
        }
        public override void Init(Universal_ConditionEditor uce, Condition start)
        {
            Init(uce);
            if (start != null)
            {
                uce.SetMainValue(1, (start as Time_Of_Day_Cond).Logic);
                uce.SetMainValue(3, (start as Time_Of_Day_Cond).Second);
            }
        }

        public override T Parse<T>(object[] input)
        {
            return new Time_Of_Day_Cond
            {
                Logic = (Logic_Type)input[0],
                Second = ulong.Parse(input[1].ToString())
            } as T;
        }

        public override string GetFilePresentation(string prefix, int prefixIndex, int conditionIndex)
        {
            if (prefix.Length > 0)
                if (!prefix.EndsWith("_"))
                    prefix += "_";
            string output = "";
            output += ($"{prefix}{(prefix.Length > 0 ? $"{prefixIndex.ToString()}_" : "")}Condition_{conditionIndex}_Type Time_Of_Day");
            output += ($"{Environment.NewLine}{prefix}{(prefix.Length > 0 ? $"{prefixIndex}_" : "")}Condition_{conditionIndex}_Logic {this.Logic}");
            output += ($"{Environment.NewLine}{prefix}{(prefix.Length > 0 ? $"{prefixIndex}_" : "")}Condition_{conditionIndex}_Second {this.Second}");
            return output;
        }
    }
}