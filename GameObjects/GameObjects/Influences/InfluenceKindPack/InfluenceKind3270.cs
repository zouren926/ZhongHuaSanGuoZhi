﻿namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind3270 : InfluenceKind
    {
        private int kind = 0;
        private float rate = 0f;

        public override void DoWork(Architecture architecture)
        {
            foreach (Military military in architecture.Militaries)
            {
                if ((military.Kind.ID == this.kind) && (military.InjuryQuantity == 0))
                {
                    architecture.RecruitmentMilitary(military, this.rate);
                }
            }
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.kind = int.Parse(parameter);
            }
            catch
            {
            }
        }

        public override void InitializeParameter2(string parameter)
        {
            try
            {
                this.rate = float.Parse(parameter);
            }
            catch
            {
            }
        }

        public override double AIFacilityValue(Architecture a)
        {
            return (a.FrontLine ? 1 : -1) * (a.FrontLine ? 2 : 1) * (a.HostileLine ? 2 : 1) * (a.CriticalHostile ? 2 : 1) * (this.rate * 10);
        }
    }
}
