﻿namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind685 : InfluenceKind
    {
        private float rate;

        public override void ApplyInfluenceKind(Troop troop)
        {
            troop.OffenceRateDecrementInViewArea += this.rate;
        }

        public override void PurifyInfluenceKind(Troop troop)
        {
            troop.OffenceRateDecrementInViewArea -= this.rate;
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.rate = float.Parse(parameter);
            }
            catch
            {
            }
        }


        public override void ApplyInfluenceKind(Architecture architecture)
        {
            foreach (Microsoft.Xna.Framework.Point point in architecture.ViewArea.Area)
            {
                Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                if ((troopByPosition != null) && !architecture.IsFriendly(troopByPosition.BelongedFaction))
                {
                    troopByPosition.RateOfOffence -= this.rate;
                }
            }
        }

        public override void PurifyInfluenceKind(Architecture architecture)
        {
            foreach (Microsoft.Xna.Framework.Point point in architecture.ViewArea.Area)
            {
                Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                if ((troopByPosition != null) && !architecture.IsFriendly(troopByPosition.BelongedFaction))
                {
                    troopByPosition.RateOfOffence += this.rate;
                }
            }
        }
    }
}

