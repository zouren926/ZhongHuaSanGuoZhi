﻿namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind1004 : ConditionKind
    {
        public override bool CheckConditionKind(Troop troop)
        {
            return (troop.Morale == troop.Army.MoraleCeiling);
        }
    }
}

