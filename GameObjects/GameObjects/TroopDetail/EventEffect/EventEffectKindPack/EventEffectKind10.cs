﻿namespace GameObjects.TroopDetail.EventEffect.EventEffectKindPack
{
    using GameObjects;
    using GameObjects.TroopDetail.EventEffect;
    using System;

    internal class EventEffectKind10 : EventEffectKind
    {
        private int increment;

        public override void ApplyEffectKind(Person person)
        {
            if (person.LocationTroop != null)
            {
                person.LocationTroop.IncreaseMorale(this.increment);
            }
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.increment = int.Parse(parameter);
            }
            catch
            {
            }
        }
    }
}

